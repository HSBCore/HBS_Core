using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string? Descrption { get; set; }
        public decimal? Price { get; set; }
        public int? RoomClassId { get; set; }

        public virtual RoomClass? RoomClass { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
