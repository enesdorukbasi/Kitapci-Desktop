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

namespace KitapciApp.Wpf.Views.MainViews
{
    /// <summary>
    /// Interaction logic for YoneticiMainView.xaml
    /// </summary>
    public partial class YoneticiMainView : Window
    {
        public YoneticiMainView()
        {
            InitializeComponent();
        }

        private void btnKitapList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrm.Source = new Uri("/Views/YoneticiViews/KitapViews/KitapListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnTurList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrm.Source = new Uri("/Views/YoneticiViews/TurViews/TurListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnSatisList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrm.Source = new Uri("/Views/YoneticiViews/SatisViews/SatısListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnKullaniciList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrm.Source = new Uri("/Views/YoneticiViews/KullaniciViews/KullaniciListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
