using KitapciApp.BusinnessLayer;
using KitapciApp.EntityLayer;
using KitapciApp.Wpf.ViewModels.TurViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.Wpf.ViewModels.KitapViewModels
{
    public class KitapViewModel : BaseViewModel
    {
        private Kitap _kitap;
        public Kitap Kitap
        {
            get { return _kitap; }
        }

        public int Id
        {
            get { return _kitap.Id; }
            set
            {
                if (_kitap.Id != value)
                {
                    _kitap.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Barkod
        {
            get { return _kitap.Barkod; }
            set
            {
                if (_kitap.Barkod != value)
                {
                    _kitap.Barkod = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad
        {
            get { return _kitap.KitapAd; }
            set
            {
                if (_kitap.KitapAd != value)
                {
                    _kitap.KitapAd = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Yazar
        {
            get { return _kitap.Yazar; }
            set
            {
                if (_kitap.Yazar != value)
                {
                    _kitap.Yazar = value;
                    OnPropertyChanged();
                }
            }
        }

        public int TurId
        {
            get { return _kitap.TurId; }
            set
            {
                if (_kitap.TurId != value)
                {
                    _kitap.TurId = value;
                    Tur = new TurViewModel(turler.First(x => x.Id == _kitap.TurId));
                }
            }
        }
        private TurViewModel _tur;
        public TurViewModel Tur
        {
            get { return _tur; }
            set
            {
                if (_tur != value)
                {
                    _tur = value;
                    OnPropertyChanged();
                }
            }
        }


        public int Adet
        {
            get { return _kitap.Adet; }
            set
            {
                if(_kitap.Adet != value)
                {
                    _kitap.Adet = value;
                    OnPropertyChanged();
                }
            }
        }
        public decimal Fiyat
        {
            get { return _kitap.Fiyat; }
            set
            {
                if (_kitap.Fiyat != value)
                {
                    _kitap.Fiyat = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Tur> turler;
        public ObservableCollection<Tur> Turler
        {
            get { return turler; }
            set
            {
                if (turler != value)
                {
                    turler = value;
                    OnPropertyChanged();
                }
            }
        }

        public KitapViewModel() : this(new Kitap()) { }
        public KitapViewModel(Kitap kitap)
        {
            this._kitap = kitap;
            this._tur = new TurViewModel(kitap.Tur);

            using (TurManager manager = new TurManager())
            {
                Turler = new ObservableCollection<Tur>(manager.Listele());
            }
        }
    }
}
