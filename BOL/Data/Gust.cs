using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class Gust
    {
        public Gust()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
