using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Helpers.Sessions
{
    public class SessionHelper : ISessionHelper
    {
        private static IHttpContextAccessor _contextAccessor;
        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public void SetSession(string key, object value)
        {
            _contextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public T GetSession<T>(string key)
        {
            var value = _contextAccessor.HttpContext.Session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
