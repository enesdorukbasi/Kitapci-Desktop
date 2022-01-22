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
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        public KitapRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Kitap> GetAllWithTur()
        {
            return context.Set<Kitap>().Include(x => x.Tur).ToList();
        }

        public Kitap GetItemWithTur(string barkod)
        {
            return context.Set<Kitap>().Include(x => x.Tur).FirstOrDefault(x => x.Barkod.Equals(barkod));
        }

        public Kitap GetItemWithTur(int id)
        {
            return context.Set<Kitap>().Include(x => x.Tur).FirstOrDefault(x => x.Id == id);
        }
    }
}
