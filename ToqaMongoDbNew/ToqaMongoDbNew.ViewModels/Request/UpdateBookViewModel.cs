using System.Collections.Generic;

namespace ToqaMongoDbNew.Models
{
    public class UpdateBookViewModel
    {
        public string Id { get; set; }
        public string BookName { get; set; }

        public List<string> ListOfTags { get; set; }
    }
}
