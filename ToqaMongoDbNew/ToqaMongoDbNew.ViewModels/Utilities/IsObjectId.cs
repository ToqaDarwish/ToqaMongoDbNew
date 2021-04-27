using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace ToqaMongoDbNew.ViewModels.Utilities
{
    public class IsObjectId : ValidationAttribute
    {
        private readonly string Id;
        public IsObjectId(string ID)
        {
            this.Id = ID;
        }
        public override bool IsValid(object value)
        {
            string result = value.ToString();
            var Id = new ObjectId();
            if (!ObjectId.TryParse(result, out Id))
                return false;
            return true;
        }
    }
}
