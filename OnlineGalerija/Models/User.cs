using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("username")]
        public string username { get; set; }
        [BsonElement("passwordhash")]
        public string passwordhash { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        [BsonElement("namesurname")]
        public string namesurname { get; set; }
        [BsonElement("profile_photo_data")]
        public byte[] profile_photo_data { get; set; }
        [BsonElement("dateofbirth")]
        public DateTime dateofbirth { get; set; }
        [BsonElement("created_at")]
        public DateTime created_at { get; set; }
        [BsonElement("updated_at")]
        public DateTime updated_at { get; set; }
        [BsonElement("role")]
        public Role role { get; set; }
        [BsonElement("followers")]
        public ICollection<User> followers { get; set; }
        [BsonElement("posts")]
        public ICollection<Post> posts { get; set; }
        [BsonElement("comments")]
        public ICollection<Comment> comments { get; set; }
        [BsonElement("reaction_comments")]
        public ICollection<ReactionComment> reaction_comments { get; set; }
        [BsonElement("reaction_posts")]
        public ICollection<ReactionPost> reaction_posts { get; set; }
    }
}
