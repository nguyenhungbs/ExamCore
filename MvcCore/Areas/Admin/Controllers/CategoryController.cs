using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.CoreData.Models.Categories;
using Exam.CoreData.Models.PagingInfo;
using Exam.Services.CategoryFacade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public IActionResult Index()
        {
            var result = _categoryService.SearchDepartment(new SearchModel { PageIndex = 1, PageSize = 10 });

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel model)
        {
            return View();
        }
    }
}