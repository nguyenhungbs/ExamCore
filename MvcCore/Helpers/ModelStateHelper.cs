using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Helpers
{
    public static class ModelStateHelper
    {
        public static string GetErrorsMessage(this ModelStateDictionary modelState)
        {
            var errors = modelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            var message = string.Empty;
            foreach (var err in errors)
            {
                foreach (var e in err)
                {
                    message += e.ErrorMessage + " ";
                }
            }
            return message;
        }
    }
}
