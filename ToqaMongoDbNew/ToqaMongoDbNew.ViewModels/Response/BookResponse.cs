using System.Collections.Generic;

namespace ToqaMongoDbNew.Models
{
    public class BookResponse
    {
        public string Id { get; set; }

        public string BookName { get; set; }

        public string Description { get; set; }

        public List<string> ListOfTags { get; set; }
        public string Tags { get; set; }
    }
}
