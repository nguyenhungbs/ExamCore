using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Api.Helpers;
using Exam.CoreData.Models.PagingInfo;
using Exam.CoreData.Models.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.PatientFacade;
using Swashbuckle.AspNetCore.Annotations;

namespace ExamProject.Controllers
{
    [Produces("application/json")]
    [Route("api/Patient")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Patient list
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/patient/search")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(BaseSearchResult<PatientModel>))]
        public IActionResult SearchPatient([FromBody] SearchModel search)
        {
            var result = _patientService.SearchPatient(search);
            return Json(new { success = true, data = result });
        }

        /// <summary>
        /// Patient Info by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/patient/info/{id}")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(PatientModel))]
        public IActionResult GetInfoById(string id)
        {
            var result = _patientService.GetInfoById(id);
            return Json(new { success = true, data = result });
        }

        /// <summary>
        /// Add patient
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/patient/add")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(bool))]
        public IActionResult AddPatient([FromBody] SavePatientModel model)
        {
            if (!ModelState.IsValid) throw new Exception(ModelState.GetErrorsMessage());
            var result = _patientService.AddPatient(model);
            return Json(new { success = result });
        }

        /// <summary>
        /// Update patient
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/patient/update")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(bool))]
        public IActionResult UpdatePatient([FromBody] SavePatientModel model)
        {
            if (!ModelState.IsValid) throw new Exception(ModelState.GetErrorsMessage());
            var result = _patientService.UpdatePatient(model);
            return Json(new { success = result });
        }

        /// <summary>
        /// Delete one patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/patient/delete/{id}")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(bool))]
        public IActionResult DeleteOnePatient(int id)
        {
            var result = _patientService.DeleteOnePatient(id);
            return Json(new { success = result });
        }

        /// <summary>
        /// Delete many patient
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("/api/patient/delete-many")]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(bool))]
        public IActionResult DeleteManyPatient([FromBody] DeleteManyPatientModel model)
        {
            var result = _patientService.DeleteManyPatient(model);
            return Json(new { success = result });
        }
    }
}