using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class staff
    {
        public staff()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? JobTitle { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
