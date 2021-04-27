using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToqaMongoDbNew.Helper
{
    public static class SuccessHelper
    {
        public static SuccessOperationResult<T> Warp<T>(T result)
        {
            return new SuccessOperationResult<T>(result);
        }
    }
}
