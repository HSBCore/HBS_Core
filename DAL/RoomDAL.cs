using BOL;
using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomDAL : IRoom
    {
        private HBS_DBContext _db;
        public RoomDAL()
        {
            _db = new HBS_DBContext();
        }
        public void Add(Room room)
        {
            _db.Rooms.Add(room);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
           var rm =  _db.Rooms.Find(id);
            _db.Rooms.Remove(rm);
            _db.SaveChanges();
        }

        public List<Room> GetAllRoom()
        {
            return _db.Rooms.ToList();
        }

        public Room GetRoom(int id)
        {
            return _db.Rooms.Find(id);
        }

        public void Update(Room room)
        {
            _db.Rooms.Update(room);
            _db.SaveChanges();  
        }
    }
}
