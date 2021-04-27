using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToqaMongoDbNew.Utilities
{
    public class IsEqualToqa: ValidationAttribute
    {
        private readonly string allowedName;
        public IsEqualToqa(string allowedName)
        {
            this.allowedName = allowedName;
        }
        public override bool IsValid(object value)
        {
            string result = value.ToString();
            if (result.Equals("toqa")||result.Equals("Toqa"))
                return true;
            else
                return false;
        }
    }
}
