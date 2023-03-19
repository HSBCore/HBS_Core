using BOL;
using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StaffDAL : Istaff
    {

        private HBS_DBContext _db;
        public StaffDAL()
        {
            _db = new HBS_DBContext();
        }

        public List<staff> GetStaff()
        {
            return _db.staff.ToList();
        }

        public staff login(string username, string password)
        {
            var staff = _db.staff.SingleOrDefault(x => x.Username == username && x.Password == password);
            
            if(staff == null)
            {
                return null;
            }
            else
            {
                return staff;
            }
        }

        public bool Register(staff staff)
        {
            if(userexit(staff.Username) == false)
            {
                _db.staff.Add(staff);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool userexit(string user)
        {
            return _db.staff.Count(x => x.Username == user) > 0; 
        }
    }
}
