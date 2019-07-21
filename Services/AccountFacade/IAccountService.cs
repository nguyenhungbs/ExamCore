using Exam.CoreData.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Services.AccountFacade
{
    public interface IAccountService
    {
        AccountModel GetById(string userName);

        bool CheckLogin(AccountModel model);
    }
}
