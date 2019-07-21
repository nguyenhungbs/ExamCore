using Exam.CoreData.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exam.CoreData.Entities
{
    public class Patient
    {
        public string PatientId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public PatientStatus? Status { get; set; }

    }
}
