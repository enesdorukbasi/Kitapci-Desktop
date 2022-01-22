using KitapciApp.DataAccessLayer;
using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.BusinnessLayer
{
    public class TurManager : IDisposable
    {
        private UnitOfWork work;

        public TurManager()
        {
            work = new UnitOfWork();
        }

        public List<Tur> Listele()
        {
            return work.TurRepo.GetAll().ToList();
        }

        public Tur GetTur(int id)
        {
            return work.TurRepo.GetItem(id);
        }

        public int Ekle(Tur tur)
        {
            work.TurRepo.Add(tur);
            return work.Save();
        }

        public int Sil(int id)
        {
            work.TurRepo.Remove(id);
            return work.Save();
        }

        public int Guncelle(Tur tur)
        {
            work.TurRepo.Update(tur);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
