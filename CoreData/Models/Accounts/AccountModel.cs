using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exam.CoreData.Models.Accounts
{
    public class AccountModel
    {
        [Required(ErrorMessage ="Tên đăng nhập không được để trống")]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
