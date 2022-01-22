using KitapciApp.BusinnessLayer;
using KitapciApp.EntityLayer;
using KitapciApp.Wpf.Commands;
using KitapciApp.Wpf.ViewModels.SatısDetayViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KitapciApp.Wpf.ViewModels.SatısViewModels
{
    public class SatısViewModel : BaseViewModel
    {
        private KitapManager kitapManager;
        private SatısManager satısManager;

        private ObservableCollection<SatısDetayViewModel> items;
        private SatısDetayViewModel selectedItem;
        private string barkod = "";
        private decimal toplamTutar = 0;

        public ObservableCollection<SatısDetayViewModel> Items
        {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged();
                }
            }
        }

        public SatısDetayViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Barkod
        {
            get { return barkod; }
            set
            {
                if (barkod != value)
                {
                    barkod = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal ToplamTutar
        {
            get { return toplamTutar; }
            set
            {
                if (toplamTutar != value)
                {
                    toplamTutar = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand EkleCommand { get; set; }

        public ICommand TamamlaCommand { get; set; }


        public SatısViewModel()
        {
            satısManager = new SatısManager();
            kitapManager = new KitapManager();

            EkleCommand = new RelayCommand(o => { OnEkle(); }, o => { return barkod.Length > 0; });
            TamamlaCommand = new RelayCommand(o => { OnTamamla(); }, o => { return items.Count > 0; });
            items = new ObservableCollection<SatısDetayViewModel>();
        }

        private void OnEkle()
        {
            Kitap kitap = kitapManager.GetKitap(barkod);
            if (kitap == null)
            {
                MessageBox.Show(barkod + " barkodlu kitap yok!!!");
            }
            else if(kitap.Adet <= 0)
            {
                MessageBox.Show(barkod + "barkodlu ürünün stoğu tükendi!!!");
            }
            else
            {
                SatısDetayViewModel detay = items.FirstOrDefault(x => x.Kitap.Barkod == barkod);
                if (detay == null)
                {
                    //yeni
                    SatısDetayViewModel item = new SatısDetayViewModel { KitapId = kitap.Id, Adet = 1, Tutar = kitap.Fiyat, Kitap = kitap };
                    Items.Add(item);
                }
                else
                {
                    //adet artır
                    detay.Adet++;
                    detay.Tutar += kitap.Fiyat;
                }
                ToplamTutar += kitap.Fiyat;
            }
            Barkod = "";
        }

        private void OnTamamla()
        {
            Satıs satıs = new Satıs() { TarihSaat = DateTime.Now, ToplamTutar = toplamTutar, KullanıcıNo = App.Kullanıcı.KullanıcıNo };
            foreach (var item in items)
            {
                SatısDetay detay = new SatısDetay
                {
                    KitapId = item.Kitap.Id,
                    Adet = item.Adet,
                    Tutar = item.Tutar
                };
                satıs.Detaylar.Add(detay);
            }

            if (satısManager.Ekle(satıs) > 0)
            {
                Items.Clear();
                ToplamTutar = 0;
            }
            else
            {
                MessageBox.Show("Satış Eklenemedi...");
            }
        }

    }
}
