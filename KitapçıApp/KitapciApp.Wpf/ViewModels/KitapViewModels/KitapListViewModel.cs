using KitapciApp.BusinnessLayer;
using KitapciApp.EntityLayer;
using KitapciApp.Wpf.Commands;
using KitapciApp.Wpf.Views.YoneticiViews.KitapViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KitapciApp.Wpf.ViewModels.KitapViewModels
{
    public class KitapListViewModel : BaseViewModel
    {
        private KitapManager manager;

        private ObservableCollection<KitapViewModel> _items;
        private KitapViewModel _selectedItem;

        public ObservableCollection<KitapViewModel> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        public KitapViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
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

        public KitapListViewModel()
        {
            manager = new KitapManager();
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand((parameter) => { OnDelete(parameter); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand((parameter) => { OnUpdate(parameter); }, o => { return _selectedItem != null; });
        }

        private void OnRefresh()
        {
            Items = new ObservableCollection<KitapViewModel>();
            List<Kitap> kitaplar = manager.Listele();
            foreach (var item in kitaplar)
            {
                Items.Add(new KitapViewModel(item));
            }
        }

        private void OnInsert()
        {
            KitapViewModel vm = new KitapViewModel();
            KitapView view = new KitapView() { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Ekle(vm.Kitap) > 0)
                {
                    vm = new KitapViewModel(manager.GetKitap(vm.Barkod));
                    Items.Add(vm);
                }
                else
                    MessageBox.Show("Ekleme yapılamadı...");
            }
        }

        private void OnDelete(object parameter)
        {
            KitapViewModel vm = parameter as KitapViewModel;
            if (MessageBox.Show(vm.Barkod + " adlı kitabı silmek istiyor musunuz?", "Kitap Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manager.Sil(vm.Id) > 0)
                {
                    Items.Remove(vm);
                }
                else
                    MessageBox.Show("Silinemedi...");
            }
        }

        private void OnUpdate(object parameter)
        {
            KitapViewModel vm = parameter as KitapViewModel;
            string oldBarkod = vm.Kitap.Barkod;
            KitapView view = new KitapView { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Guncelle(oldBarkod, vm.Kitap) == 0)
                    MessageBox.Show("Güncelleme Yapılamadı...");
                else
                    vm = new KitapViewModel(manager.GetKitap(vm.Barkod));
            }
        }
    }
}
