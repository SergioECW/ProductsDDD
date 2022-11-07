using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Exceptions
{
    public class BusinessExceptions
    {
        public class BusinessException : Exception
        {
            public BusinessException()
            {

            }

            public BusinessException(string message) : base(message)
            {

            }
        }
    }
}
