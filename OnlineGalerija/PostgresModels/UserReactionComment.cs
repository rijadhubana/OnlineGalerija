using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class UserReactionComment
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public int? ReactionId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual User User { get; set; }
    }
}
