﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Services
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string message) : base(message)
        {
        }

        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
