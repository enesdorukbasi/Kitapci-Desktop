using KitapciApp.BusinnessLayer;
using KitapciApp.EntityLayer;
using KitapciApp.Wpf.ViewModels.KullanıcıViewModels;
using KitapciApp.Wpf.Views.YoneticiViews.KullaniciViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KitapciApp.Wpf.Views.LoginView
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public string kullaniciNo;
        public LoginView()
        {
            InitializeComponent();
            DataContext = new KullanıcıListViewModel();

            using (KullanıcıManager manager = new KullanıcıManager())
            {
                if (manager.Listele().Count() <= 0)
                {
                    btnKayıt.Visibility = Visibility.Visible;
                }
                else
                {
                    btnKayıt.Visibility = Visibility.Hidden;
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (KullanıcıManager manager = new KullanıcıManager())
            {
                if (manager.Login(txtUserNumber.Text, pswUserPassword.Password))
                {
                    App.Kullanıcı = manager.GetKullanıcı(txtUserNumber.Text);
                    kullaniciNo = txtUserNumber.Text.ToLower();
                    DialogResult = true;
                }
                else
                {
                    txtHata.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
