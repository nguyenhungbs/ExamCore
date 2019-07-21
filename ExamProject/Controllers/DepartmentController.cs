using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Api.Helpers;
using Exam.CoreData.Models.Departments;
using Exam.CoreData.Models.PagingInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DepartmentFacade;
using Swashbuckle.AspNetCore.Annotations;

namespace ExamProject.Controllers
{
    [Produces("application/json")]
    [Route("api/Department")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// Department list
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/department/search")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(BaseSearchResult<DepartmentModel>))]
        public IActionResult SearchDepartment([FromBody] SearchModel search)
        {
            var result = _departmentService.SearchDepartment(search);
            return Json(new { success = true, data = result});
        }

        /// <summary>
        /// Department Info by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/department/info/{id}")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(DepartmentModel))]
        public IActionResult GetInfoById(int id)
        {
            var result = _departmentService.GetInfoById(id);
            return Json(new { success = true, data = result });
        }

        /// <summary>
        /// Save department
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/department/save")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(bool))]
        public IActionResult SaveDepartment([FromBody] SaveDepartmentModel model)
        {
            if (!ModelState.IsValid) throw new Exception(ModelState.GetErrorsMessage());
            var result = _departmentService.SaveDepartment(model);
            return Json(new { success = result });
        }

        /// <summary>
        /// Delete one department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/department/delete/{id}")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(bool))]
        public IActionResult DeleteOneDepartment(int id)
        {
            var result = _departmentService.DeleteOneDepartment(id);
            return Json(new { success = result });
        }

        /// <summary>
        /// Delete many department
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("/api/department/delete-many")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(bool))]
        public IActionResult DeleteManyDepartment([FromBody] DeleteManyDepartmentModel model)
        {
            var result = _departmentService.DeleteManyDepartment(model);
            return Json(new { success = result });
        }
    }
}