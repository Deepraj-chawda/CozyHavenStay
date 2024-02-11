using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            HotelImages = new HashSet<HotelImage>();
            Reviews = new HashSet<Review>();
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public int? OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Amenities { get; set; } = null!;

        public virtual HotelOwner? Owner { get; set; }
        public virtual ICollection<HotelImage> HotelImages { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
