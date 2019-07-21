using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.CoreData.Models.Categories
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public int? ParentId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Order { get; set; }

        public bool? Status { get; set; }
    }
}
