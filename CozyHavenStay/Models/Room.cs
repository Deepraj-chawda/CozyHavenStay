using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public int? HotelId { get; set; }
        public string RoomType { get; set; } = null!;
        public int MaxOccupancy { get; set; }
        public string BedType { get; set; } = null!;
        public decimal BaseFare { get; set; }
        public string RoomSize { get; set; } = null!;
        public string Acstatus { get; set; } = null!;

        public virtual Hotel? Hotel { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
