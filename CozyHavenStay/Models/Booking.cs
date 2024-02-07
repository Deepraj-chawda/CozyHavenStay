using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? UserId { get; set; }
        public int? RoomId { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalFare { get; set; }
        public string Status { get; set; } = null!;

        public virtual Room? Room { get; set; }
        public virtual User? User { get; set; }
    }
}
