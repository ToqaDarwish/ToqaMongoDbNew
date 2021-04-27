using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToqaMongoDbNew.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string Message)
            : base(Message)
        {
        }
    }
}
