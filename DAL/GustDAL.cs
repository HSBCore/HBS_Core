using BOL;
using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GustDAL : IGust
    {
        private HBS_DBContext _db;
        public GustDAL()
        {
            _db = new HBS_DBContext();
        }
        public void Add(Gust gust)
        {
            _db.Gusts.Add(gust);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var gt = _db.Gusts.Find(id);
            _db.Gusts.Remove(gt);
            _db.SaveChanges();
        }

        public List<Gust> GetAllGust()
        {
            return _db.Gusts.ToList();
        }

        public Gust GetGust(int id)
        {
            return _db.Gusts.Find(id);
        }

        public void Update(Gust gust)
        {
            _db.Gusts.Update(gust);
            _db.SaveChanges();
        }
    }
}
