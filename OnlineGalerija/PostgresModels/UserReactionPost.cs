using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class UserReactionPost
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int? ReactionId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
