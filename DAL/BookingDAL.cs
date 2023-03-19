using BOL;
using BOL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingDAL : IBooking
    {
        private HBS_DBContext _db;
        public BookingDAL()
        {
            _db = new HBS_DBContext();
        }
        public void Add(Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var bok = _db.Bookings.Find(id);
            _db.Bookings.Remove(bok);
            _db.SaveChanges();
        }

        public List<Booking> GetAllBooking()
        {
            return _db.Bookings.Include(x => x.Gust).Include(x => x.Room).Include(x => x.Staff).Include(x => x.Room.RoomClass).ToList();
        }

        public Booking GetBooking(int id)
        {
            return _db.Bookings.Find(id);
        }

        public void Update(Booking booking)
        {
            _db.Bookings.Update(booking);
            _db.SaveChanges();
        }
    }
}
