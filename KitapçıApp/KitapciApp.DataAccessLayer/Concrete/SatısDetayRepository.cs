using KitapciApp.DataAccessLayer.Abstract;
using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.DataAccessLayer.Concrete
{
    public class SatısDetayRepository : Repository<SatısDetay>, ISatısDetayRepository
    {
        public SatısDetayRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SatısDetay> GetAllWithUrun()
        {
            return context.Set<SatısDetay>().Include(x => x.Kitap).ToList();
        }

        public IEnumerable<SatısDetay> GetAllWithUrun(int satıs_id)
        {
            return context.Set<SatısDetay>().Include(x => x.Kitap).Where(x => x.SatısId == satıs_id).ToList();
        }
    }
}
