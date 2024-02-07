﻿using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? AccountType { get; set; }
    }
}
