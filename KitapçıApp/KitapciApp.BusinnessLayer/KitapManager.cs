using KitapciApp.DataAccessLayer;
using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.BusinnessLayer
{
    public class KitapManager : IDisposable
    {
        private UnitOfWork work;

        public KitapManager()
        {
            work = new UnitOfWork();
        }

        public List<Kitap> Listele()
        {
            return work.KitapRepo.GetAllWithTur().ToList();
        }

        public Kitap GetKitap(int id)
        {
            return work.KitapRepo.GetItemWithTur(id);
        }

        public Kitap GetKitap(string barkod)
        {
            return work.KitapRepo.GetItemWithTur(barkod);
        }

        public int Ekle(Kitap kitap)
        {
            if (work.KitapRepo.GetItemWithTur(kitap.Barkod) != null)
                throw new ArgumentException(kitap.Barkod + " barkodlu kitap zaten var...");
            work.KitapRepo.Add(kitap);
            return work.Save();
        }

        public int Sil(int id)
        {
            work.KitapRepo.Remove(id);
            return work.Save();

        }
        public int Sil(Kitap kitap)
        {
            work.KitapRepo.Remove(kitap);
            return work.Save();
        }

        public int Guncelle(string oldBarkod, Kitap kitap)
        {
            if (kitap.Barkod != oldBarkod)
            {
                if (work.KitapRepo.GetItemWithTur(kitap.Barkod) != null)
                    throw new ArgumentException(kitap.Barkod + " barkodlu kitap zaten var...");
            }
            work.KitapRepo.Update(kitap);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
