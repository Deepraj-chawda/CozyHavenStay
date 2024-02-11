using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class HotelOwner
    {
        public HotelOwner()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? AccountType { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
