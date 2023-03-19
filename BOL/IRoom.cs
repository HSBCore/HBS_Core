using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public interface IRoom
    {
        void Add(Room room);
        void Update(Room room);
        void Delete(int id);
        Room GetRoom(int id);

        List<Room> GetAllRoom();
    }
}
