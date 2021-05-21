using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class UserFollower
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }

        public virtual User Follower { get; set; }
        public virtual User User { get; set; }
    }
}
