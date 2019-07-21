using Exam.CoreData.Entities;
using Exam.CoreData.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.CoreData.Data.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Alias { get; set; }

        public int? CategoryId { get; set; }

        public string Images { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal? Price { get; set; }

        public string Detail { get; set; }

        public bool? Status { get; set; }

    }
}
