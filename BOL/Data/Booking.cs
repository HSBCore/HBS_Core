using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class Booking
    {
        public int Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? DateRange { get; set; }
        public int? GustId { get; set; }
        public int? RoomId { get; set; }
        public int? StaffId { get; set; }

        public virtual Gust? Gust { get; set; }
        public virtual Room? Room { get; set; }
        public virtual staff? Staff { get; set; }
    }
}
