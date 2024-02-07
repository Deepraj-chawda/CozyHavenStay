using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            HotelOwners = new HashSet<HotelOwner>();
            Reviews = new HashSet<Review>();
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Amenities { get; set; } = null!;

        public virtual ICollection<HotelOwner> HotelOwners { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
