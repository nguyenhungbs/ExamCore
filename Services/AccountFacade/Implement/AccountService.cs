using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Exam.CoreData.Data.Entities;
using Exam.CoreData.Models.Accounts;
using Exam.CoreData.Repository.Common;
using Exam.Libraries.Utils;
using Microsoft.EntityFrameworkCore;

namespace Exam.Services.AccountFacade.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountModel GetById(string userName)
        {
            var res = _accountRepository.FindById(userName);
            return res.CloneToModel<Account, AccountModel>();
        }

        public bool CheckLogin(AccountModel model)
        {
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter("@result", SqlDbType.Int) {Direction = ParameterDirection.Output},
                new SqlParameter("@UserName", model.UserName),
                new SqlParameter("@Password", model.Password)
            };

            var query = "exec @result=sp_Check_Login @UserName, @Password";
            _accountRepository.GetDBContext().Database.ExecuteSqlCommand(query, sqlParams);
            var result = sqlParams[0].Value;

            return Convert.ToBoolean(result);
        }
    }
}
