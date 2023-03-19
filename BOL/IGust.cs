using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public interface IGust
    {
        void Add(Gust gust);
        void Update(Gust gust);
        void Delete(int id);
        Gust GetGust(int id);

        List<Gust> GetAllGust();
    }
}
