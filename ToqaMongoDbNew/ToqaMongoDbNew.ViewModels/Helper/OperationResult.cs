using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToqaMongoDbNew.Helper
{
    public class OperationResult<T>
    {
        public bool Status { get; set; }

        public T result { get; set; }
    }
}
