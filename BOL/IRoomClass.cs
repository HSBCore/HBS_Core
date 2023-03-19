using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public interface IRoomClass
    {
        void Add(RoomClass roomclass);
        void Update(RoomClass roomClass);
        void Delete(int id);
        RoomClass GetRoomClass(int id);

        List<RoomClass> GetAllRoomClass();
    }
}
