using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Exam.Api.Helpers
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var status = HttpStatusCode.Accepted;
            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = new {
                success = false,
                message = context.Exception.Message,
                exception = context.Exception.ToString()
            };
            response.WriteAsync(JsonConvert.SerializeObject(err));
        }
    }
}
