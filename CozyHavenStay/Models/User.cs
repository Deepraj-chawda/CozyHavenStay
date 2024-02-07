using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Logs = new HashSet<Log>();
            Reviews = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? AccountType { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
