using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public interface IBooking
    {
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete (int id);
        Booking GetBooking(int id);
        List<Booking> GetAllBooking();
        
    }
}
