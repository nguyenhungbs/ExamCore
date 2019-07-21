using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Helpers.Sessions
{
    public interface ISessionHelper
    {
        void SetSession(string key, object value);

        T GetSession<T>(string key);
    }
}
