using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class Hashtag
    {
        public Hashtag()
        {
            PostHashtags = new HashSet<PostHashtag>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<PostHashtag> PostHashtags { get; set; }
    }
}
