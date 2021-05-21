using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
            PostHashtags = new HashSet<PostHashtag>();
            UserReactionPosts = new HashSet<UserReactionPost>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<PostHashtag> PostHashtags { get; set; }
        public virtual ICollection<UserReactionPost> UserReactionPosts { get; set; }
    }
}
