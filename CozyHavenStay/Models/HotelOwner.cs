using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class HotelOwner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? HotelId { get; set; }
        public string? AccountType { get; set; }

        public virtual Hotel? Hotel { get; set; }
    }
}
