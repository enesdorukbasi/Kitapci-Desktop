using KitapciApp.DataAccessLayer.Concrete;
using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private DatabeseContext context;

        private KullanıcıRepository kullanıcı_repo;
        private Repository<Tur> tur_repo;
        private KitapRepository kitap_repo;
        private Repository<Satıs> satis_repo;
        private SatısDetayRepository satısDetay_repo;

        public KullanıcıRepository KullanıcıRepo
        {
            get
            {
                if (kullanıcı_repo == null)
                    kullanıcı_repo = new KullanıcıRepository(context);
                return kullanıcı_repo;
            }
        }

        public Repository<Tur> TurRepo
        {
            get
            {
                if (tur_repo == null)
                    tur_repo = new Repository<Tur>(context);
                return tur_repo;
            }
        }

        public KitapRepository KitapRepo
        {
            get
            {
                if (kitap_repo == null)
                    kitap_repo = new KitapRepository(context);
                return kitap_repo;
            }
        }

        public Repository<Satıs> SatısRepo
        {
            get
            {
                if (satis_repo == null)
                    satis_repo = new Repository<Satıs>(context);
                return satis_repo;
            }
        }

        public SatısDetayRepository SatısDetayRepo
        {
            get
            {
                if (satısDetay_repo == null)
                    satısDetay_repo = new SatısDetayRepository(context);
                return satısDetay_repo;
            }
        }

        public UnitOfWork()
        {
            context = new DatabeseContext();
        }

        public int Save()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int adet = context.SaveChanges();
                    transaction.Commit();
                    return adet;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Dispose()
        {
            kullanıcı_repo?.Dispose();
            tur_repo?.Dispose();
            kitap_repo?.Dispose();
            satis_repo?.Dispose();
            satısDetay_repo?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
