using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGalerija.PostgresModels
{
    public partial class Image
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public int? PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
