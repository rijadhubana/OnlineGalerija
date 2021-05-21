using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class PostHashtag
    {
        public int PostId { get; set; }
        public int HashtagId { get; set; }

        public virtual Hashtag Hashtag { get; set; }
        public virtual Post Post { get; set; }
    }
}
