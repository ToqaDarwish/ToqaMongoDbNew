using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToqaMongoDbNew.Helper
{
    public class SuccessOperationResult<T>: OperationResult<T>
    {
        public SuccessOperationResult(T result)
        {
            this.Status = true;
            this.result = result;
        }
    }
}
