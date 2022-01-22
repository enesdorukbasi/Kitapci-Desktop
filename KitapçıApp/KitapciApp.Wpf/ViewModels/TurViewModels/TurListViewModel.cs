using KitapciApp.BusinnessLayer;
using KitapciApp.EntityLayer;
using KitapciApp.Wpf.Commands;
using KitapciApp.Wpf.Views.YoneticiViews.TurViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KitapciApp.Wpf.ViewModels.TurViewModels
{
    public class TurListViewModel : BaseViewModel
    {
        private TurManager manager;

        private ObservableCollection<TurViewModel> _items;
        private TurViewModel _selectedItem;

        public ObservableCollection<TurViewModel> Items
        {
            get { return _items; }
            set
            {
                if(_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        public TurViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if(_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public TurListViewModel()
        {
            manager = new TurManager();
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand((parameter) => { OnDelete(parameter); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand((parameter) => { OnUpdate(parameter); }, o => { return _selectedItem != null; });
        }

        private void OnRefresh()
        {
            Items = new ObservableCollection<TurViewModel>();
            List<Tur> turler = manager.Listele();
            foreach(var item in turler)
            {
                Items.Add(new TurViewModel(item));
            }
        }

        private void OnInsert()
        {
            TurViewModel vm = new TurViewModel();
            TurView view = new TurView() { DataContext = vm };

            if (view.ShowDialog() == true)
            {
                if (manager.Ekle(vm.Tur) > 0)
                {
                    Items.Add(vm);
                }
                else
                    MessageBox.Show("Ekleme yapılamadı...");
            }
        }

        private void OnDelete(object parameter)
        {
            TurViewModel vm = parameter as TurViewModel;
            if (MessageBox.Show(vm.Ad + " adlı türü silmek istiyor musunuz?", "Tür Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manager.Sil(vm.Tur.Id) > 0)
                {
                    Items.Remove(vm);
                }
                else
                    MessageBox.Show("Silinemedi...");
            }
        }

        private void OnUpdate(object parameter)
        {
            TurViewModel vm = parameter as TurViewModel;
            TurView view = new TurView { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Guncelle(vm.Tur) == 0)
                    MessageBox.Show("Güncelleme Yapılamadı...");
            }
        }
    }
}
