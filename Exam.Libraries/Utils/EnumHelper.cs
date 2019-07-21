using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Exam.Libraries.Utils
{
    public static class EnumHelper
    {
        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((EnumDescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }
    }
}
