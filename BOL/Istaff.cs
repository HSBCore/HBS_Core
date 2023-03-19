using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public interface Istaff
    {
        bool Register(staff staff);
        staff login(string username, string password);

        List<staff> GetStaff(); 
    }
}
