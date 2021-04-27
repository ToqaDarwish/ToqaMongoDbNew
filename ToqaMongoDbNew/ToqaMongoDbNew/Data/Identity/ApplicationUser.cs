using IdentityMongo.Model;

namespace ToqaMongoDbNew.Services.Identity
{
    public class ApplicationUser : MongoUser
    {
        public int? Age { get; set; }
    }
}
