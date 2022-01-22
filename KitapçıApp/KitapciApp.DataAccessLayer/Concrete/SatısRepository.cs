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
    public class SatısRepository : Repository<Satıs>, ISatısRepository
    {
        public SatısRepository(DbContext context) : base(context)
        {
        }


        public IEnumerable<Satıs> GetAllWithKullanıcı(string kullaniciNo)
        {
            return context.Set<Satıs>().Include(x => x.Kullanıcı).Where(x => x.KullanıcıNo == kullaniciNo).ToList();
        }
    }
}
