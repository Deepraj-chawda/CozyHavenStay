using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class HotelImage
    {
        public int ImageId { get; set; }
        public int? HotelId { get; set; }
        public string? ImageUrl { get; set; }

        public virtual Hotel? Hotel { get; set; }
    }
}
