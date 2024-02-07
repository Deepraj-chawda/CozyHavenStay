using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? HotelId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; } = null!;

        public virtual Hotel? Hotel { get; set; }
        public virtual User? User { get; set; }
    }
}
