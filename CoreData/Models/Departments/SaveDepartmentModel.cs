using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exam.CoreData.Models.Departments
{
    public class SaveDepartmentModel
    {
        public int? Id { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull =false)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The department name cannot be empty")]
        [MaxLength(50, ErrorMessage = "The department name cannot be greater than 50 characters")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
