using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.DataAccessLayer.Abstract
{
    public interface ISatısRepository : IRepository<Satıs>
    {
        IEnumerable<Satıs> GetAllWithKullanıcı(string kullaniciNo);
    }
}
