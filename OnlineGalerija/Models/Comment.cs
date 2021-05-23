using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("text")]
        public string text { get; set; }
        [BsonElement("created_at")]
        public DateTime created_at { get; set; }
        [BsonElement("post")]
        public Post post { get; set; }
        [BsonElement("user")]
        public User user { get; set; }
        [BsonElement("reactions")]
        public ICollection<ReactionComment> reactions { get; set; }
    }
}
