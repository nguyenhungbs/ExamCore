using Exam.CoreData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.CoreData.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Alias { get; set; }

        public int? ParentId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Order { get; set; }

        public bool? Status { get; set; }
    }
}
