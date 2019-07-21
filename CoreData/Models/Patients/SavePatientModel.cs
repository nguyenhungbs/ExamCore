using Exam.CoreData.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exam.CoreData.Models.Patients
{
    public class SavePatientModel
    {
        [MaxLength(50, ErrorMessage = "PatientId field cannot be greater than 50 characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PatientId field cannot be empty")]
        public string PatientId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname field cannot be empty")]
        [MaxLength(25, ErrorMessage = "Firstname field cannot be greater than 20 characters")]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lastname field cannot be empty")]
        [MaxLength(25, ErrorMessage = "Lastname field cannot be greater than 20 characters")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Birhday field cannot be empty")]
        public DateTime Birthday { get; set; }

        [MaxLength(10, ErrorMessage = "Gender field cannot be greater than 10 characters")]
        public string Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The department name cannot be empty")]
        [MaxLength(20, ErrorMessage = "Phone field cannot be greater than 20 characters")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public PatientStatus? Status { get; set; }
    }
}
