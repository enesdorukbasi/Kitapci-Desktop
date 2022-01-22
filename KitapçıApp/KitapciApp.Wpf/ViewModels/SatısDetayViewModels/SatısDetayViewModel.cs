using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.Wpf.ViewModels.SatısDetayViewModels
{
    public class SatısDetayViewModel : BaseViewModel
    {
        private SatısDetay _detay;
        public SatısDetay Detay
        {
            get { return _detay; }
        }

        public int Id
        {
            get { return _detay.Id; }
            set
            {
                if (_detay.Id != value)
                {
                    _detay.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public int KitapId
        {
            get { return _detay.KitapId; }
            set
            {
                if (_detay.KitapId != value)
                {
                    _detay.KitapId = value;
                    OnPropertyChanged();
                }
            }
        }

        public Kitap Kitap
        {
            get { return _detay.Kitap; }
            set
            {
                if (_detay.Kitap != value)
                {
                    _detay.Kitap = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Adet
        {
            get { return _detay.Adet; }
            set
            {
                if (_detay.Adet != value)
                {
                    _detay.Adet = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Tutar
        {
            get { return _detay.Tutar; }
            set
            {
                if (_detay.Tutar != value)
                {
                    _detay.Tutar = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SatısId
        {
            get { return _detay.SatısId; }
            set
            {
                if (_detay.SatısId != value)
                {
                    _detay.SatısId = value;
                    OnPropertyChanged();
                }
            }
        }

        public Satıs Satıs
        {
            get { return _detay.Satıs; }
            set
            {
                if (_detay.Satıs != value)
                {
                    _detay.Satıs = value;
                    OnPropertyChanged();
                }
            }
        }

        public SatısDetayViewModel() : this(new SatısDetay()) { }
        public SatısDetayViewModel(SatısDetay detay)
        {
            this._detay = detay;
        }

    }
}
