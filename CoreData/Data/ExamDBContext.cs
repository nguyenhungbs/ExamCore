using Exam.CoreData.Data.Entities;
using Exam.CoreData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.CoreData
{
    public partial class ExamDBContext : DbContext
    {
        public ExamDBContext(DbContextOptions<ExamDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(c => new { c.Id });               
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(c => new { c.PatientId });
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(c => new { c.Id });
            });

            modelBuilder.Entity<Account>(entity =>entity.ToTable("T_Account"));
            modelBuilder.Entity<Product>(entity => entity.ToTable("T_Products"));
            modelBuilder.Entity<Category>(entity => entity.ToTable("T_Categories"));

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>(entity => { entity.ToTable("Users", "OtherSchema"); });
        }
    }
}
