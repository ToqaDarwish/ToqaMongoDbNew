﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToqaMongoDbNew.Models
{
    public class CreateBookViewModel
    {
        [BsonElement("Name")]
        public string BookName { get; set; }

        public string Description { get; set; }

        public List<string> ListOfTags { get; set; }
        
    }
}
