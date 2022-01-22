using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapciApp.Wpf.ViewModels.TurViewModels
{
    public class TurViewModel : BaseViewModel
    {
        private Tur _tur;

        public Tur Tur
        {
            get { return _tur; }
        }

        public int Id
        {
            get { return _tur.Id; }
            set
            {
                if(_tur.Id != value)
                {
                    _tur.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad
        {
            get { return _tur.Ad; }
            set
            {
                if(_tur.Ad != value)
                {
                    _tur.Ad = value;
                    OnPropertyChanged();
                }
            }
        }

        public TurViewModel() : this(new Tur()) { }
        public TurViewModel(Tur tur)
        {
            this._tur = tur;
        }
    }
}
