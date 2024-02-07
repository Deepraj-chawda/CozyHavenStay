﻿using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class Log
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public string? Action { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual User? User { get; set; }
    }
}
