using System;
using System.Collections.Generic;

namespace CozyHavenStay.Models
{
    public partial class Refund
    {
        public int RefundId { get; set; }
        public int? BookingId { get; set; }
        public decimal RefundAmount { get; set; }
        public string? Reason { get; set; }
        public DateTime? RefundDate { get; set; }
        public string? RefundStatus { get; set; }

        public virtual Booking? Booking { get; set; }
    }
}
