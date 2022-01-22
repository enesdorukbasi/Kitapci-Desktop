using KitapciApp.DataAccessLayer;
using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.BusinnessLayer
{

    public class KullanıcıManager : IDisposable
    {
        public string oldKullanıcıNo = "";
        private UnitOfWork work;

        public KullanıcıManager()
        {
            work = new UnitOfWork();
        }

        public bool Login(string kullaniciNo, string parola)
        {
            oldKullanıcıNo = kullaniciNo;
            return work.KullanıcıRepo.Login(kullaniciNo, parola);
        }

        public List<Kullanıcı> Listele()
        {
            return work.KullanıcıRepo.GetAll().ToList();
        }

        public Kullanıcı GetKullanıcı(string kullaniciNo)
        {
            return work.KullanıcıRepo.GetItem(kullaniciNo);
        }

        public int Ekle(Kullanıcı kullanıcı)
        {
            if (work.KullanıcıRepo.GetItem(kullanıcı.KullanıcıNo) != null)
                throw new ArgumentException(kullanıcı.KullanıcıNo + " bu numaraya sahip kullanıcı zaten var...");

            work.KullanıcıRepo.Add(kullanıcı);
            return work.Save();
        }

        public int Sil(Kullanıcı kullanıcı)
        {
            work.KullanıcıRepo.Remove(kullanıcı);
            return work.Save();
        }

        public int Sil(string kullaniciNo)
        {
            work.KullanıcıRepo.Remove(kullaniciNo);
            return work.Save();
        }

        public int Guncelle(string oldKullaniciNo, Kullanıcı kullanıcı)
        {
            if (kullanıcı.KullanıcıNo != oldKullaniciNo)
            {
                if (work.KullanıcıRepo.GetItem(kullanıcı.KullanıcıNo) != null)
                    throw new ArgumentException(kullanıcı.KullanıcıNo + " bu numaraya sahip kullanıcı zaten var...");
            }
            work.KullanıcıRepo.Update(kullanıcı);
            return work.Save();
        }


        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
