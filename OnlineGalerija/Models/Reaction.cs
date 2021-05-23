using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.Models
{
    public class Reaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("reaction_name")]
        public string reaction_name { get; set; }
        [BsonElement("reaction_image_data")]
        public byte[] reaction_image_data { get; set; }
        [BsonElement("referencedinRC")]
        public ICollection<ReactionComment> referencedinRC { get; set; }
        [BsonElement("referencedinRP")]
        public ICollection<ReactionPost> referencedinRP { get; set; }
    }
}
