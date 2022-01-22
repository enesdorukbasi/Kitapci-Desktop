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
    public class KullanıcıRepository : Repository<Kullanıcı>, IKullanıcıRepository
    {
        public KullanıcıRepository(DbContext context) : base(context)
        {
        }

        public bool Login(string kullaniciNo, string parola)
        {
            return (context.Set<Kullanıcı>().FirstOrDefault(x => x.KullanıcıNo.ToLower().Equals(kullaniciNo.ToLower()) && x.Parola.Equals(parola)) != null);
        }
    }
}
