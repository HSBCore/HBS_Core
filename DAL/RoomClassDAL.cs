using BOL;
using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomClassDAL : IRoomClass
    {
        private HBS_DBContext _db;
        public RoomClassDAL()
        {
            _db = new HBS_DBContext();
        }
        public void Add(RoomClass roomclass)
        {
            _db.RoomClasses.Add(roomclass);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var rc = _db.RoomClasses.Find(id);
            _db.RoomClasses.Remove(rc);
            _db.SaveChanges();
        }

        public List<RoomClass> GetAllRoomClass()
        {
            return _db.RoomClasses.ToList();
        }

        public RoomClass GetRoomClass(int id)
        {
            return _db.RoomClasses.Find(id);
        }

        public void Update(RoomClass roomClass)
        {
            _db.RoomClasses.Update(roomClass);
            _db.SaveChanges();
        }
    }
}
