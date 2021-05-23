using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.Models
{
    public class Hashtag
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("text")]
        public string text { get; set; }
        [BsonElement("referencedIn")]
        public ICollection<Post> referencedIn { get; set; }
    }
}
