using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.DataAccessLayer.Abstract
{
    public interface IKitapRepository : IRepository<Kitap>
    {
        IEnumerable<Kitap> GetAllWithTur();

        Kitap GetItemWithTur(string barkod);
        Kitap GetItemWithTur(int id);
    }
}
