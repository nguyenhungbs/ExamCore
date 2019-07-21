using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Libraries.Utils
{
    public class EnumDescriptionAttribute : Attribute
    {
        private string _description;

        public EnumDescriptionAttribute(string description)
        {
            _description = description;
        }
        public string Description { get; set; }
        
    }
}
