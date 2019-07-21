using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exam.CoreData.Data.Entities
{
    public class Account
    {
        [Key]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
