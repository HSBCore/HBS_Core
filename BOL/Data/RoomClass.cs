using System;
using System.Collections.Generic;

namespace BOL.Data
{
    public partial class RoomClass
    {
        public RoomClass()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
