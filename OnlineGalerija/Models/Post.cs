using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("title")]
        public string name { get; set; }
        [BsonElement("text")]
        public string text { get; set; }
        [BsonElement("created_at")]
        public DateTime created_at { get; set; }
        [BsonElement("updated_at")]
        public DateTime updated_at { get; set; }
        [BsonElement("hashtags")]
        public ICollection<Hashtag> hashtags { get; set; }
        [BsonElement("images")]
        public ICollection<Image> images { get; set; }
        [BsonElement("reactions")]
        public ICollection<ReactionPost> reactions { get; set; }
        [BsonElement("user")]
        public User user { get; set; }
    }
}
