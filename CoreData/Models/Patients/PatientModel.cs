using Exam.CoreData.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.CoreData.Models.Patients
{
    public class PatientModel
    {
        public string PatientId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public PatientStatus? Status { get; set; }

        public string StatusDescription { get; set; }
    }
}
