using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Exam.Libraries.Utils
{
    public static class EncryptHelper
    {
        public static string SecurityKey = "default";

        public static string EncryptMD5(string context)
        {
            UTF8Encoding Unic = new UTF8Encoding();

            byte[] bytes = Unic.GetBytes(context);

            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] result = md5.ComputeHash(bytes);

            return BitConverter.ToString(result);

        }
    }
}
