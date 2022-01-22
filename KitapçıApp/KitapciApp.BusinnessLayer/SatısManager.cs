using KitapciApp.DataAccessLayer;
using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.BusinnessLayer
{
    public class SatısManager : IDisposable
    { 
        private UnitOfWork work;

        public SatısManager()
        {
            work = new UnitOfWork();
        }

        public List<Satıs> Listele()
        {
            return work.SatısRepo.GetAll().ToList();
        }

        public int Ekle(Satıs satıs)
        {
            foreach (var detay in satıs.Detaylar)
            {
                Kitap kitap = work.KitapRepo.GetItem(detay.KitapId);
                kitap.Adet -= detay.Adet;
                work.KitapRepo.Update(kitap);
            }
            work.SatısRepo.Add(satıs);
            return work.Save();
        }

        public int Sil(int id)
        {
            work.SatısRepo.Remove(id);
            return work.Save();
        }

        public int Sil(Satıs satıs)
        {
            work.SatısRepo.Remove(satıs);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
