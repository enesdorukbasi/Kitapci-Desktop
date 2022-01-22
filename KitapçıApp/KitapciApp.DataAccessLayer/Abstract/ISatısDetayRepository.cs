using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.DataAccessLayer.Abstract
{
    public interface ISatısDetayRepository : IRepository<SatısDetay>
    {
        IEnumerable<SatısDetay> GetAllWithUrun();
        IEnumerable<SatısDetay> GetAllWithUrun(int satıs_id);
    }
}
