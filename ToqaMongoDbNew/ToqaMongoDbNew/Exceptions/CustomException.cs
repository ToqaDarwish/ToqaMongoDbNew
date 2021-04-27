using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToqaMongoDbNew.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException()
            :base(String.Format("Invalid Book"))
        {

        }

        public CustomException(string bookName)
            : base(String.Format("Invalid empty Book Name you should enter a valid Name"))
        {
        }
        public CustomException(bool Description)
            : base(String.Format("Invalid empty Book Description you should enter a valid Description"))
        {

        }
        public CustomException(List<string> tags)
            : base(String.Format("Invalid empty Book Tag list you Must enter at least one Tag"))
        {

        }
    }
}
