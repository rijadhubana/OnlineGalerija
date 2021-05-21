using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class Reaction
    {
        public int Id { get; set; }
        public string ReactionName { get; set; }
        public byte[] ReactionImageData { get; set; }
    }
}
