using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.CoreData.Models.Accounts;
using Exam.CoreData.Models.PagingInfo;
using Exam.Services.AccountFacade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Helpers;
using MvcCore.Helpers.Sessions;
using Services.DepartmentFacade;

namespace MvcCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IDepartmentService _departmentService;
        private readonly ISessionHelper _sessionHelper;

        public LoginController(IAccountService accountService,
            IDepartmentService departmentService,
            ISessionHelper sessionHelper)
        {
            _accountService = accountService;
            _departmentService = departmentService;
            _sessionHelper = sessionHelper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AccountModel model)
        {
            //if (!ModelState.IsValid) throw new Exception(ModelState.GetErrorsMessage());
            var checkLogin = _accountService.CheckLogin(model);
            if(checkLogin)
            {
                _sessionHelper.SetSession("loginSession", new UserSession { UserName = model.UserName });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không tồn tại");
            }
            var ses = _sessionHelper.GetSession<UserSession>("loginSession");
            return View();
        }
    }
}