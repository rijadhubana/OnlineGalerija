using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class Comment
    {
        public Comment()
        {
            UserReactionComments = new HashSet<UserReactionComment>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserReactionComment> UserReactionComments { get; set; }
    }
}
