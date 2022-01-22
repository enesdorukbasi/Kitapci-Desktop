using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.DataAccessLayer
{
    public class DatabeseContext : DbContext
    {
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<Satıs> Satıslar { get; set; }
        public DbSet<SatısDetay> SatısDetaylar { get; set; }

        public DatabeseContext() : base("GorselKitapciAppDB")
        {
            Database.SetInitializer<DatabeseContext>(new CreateDatabaseIfNotExists<DatabeseContext>());
        }
    }
}
