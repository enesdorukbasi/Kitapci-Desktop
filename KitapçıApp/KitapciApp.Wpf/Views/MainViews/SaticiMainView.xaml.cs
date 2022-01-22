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
    /// Interaction logic for SaticiMainView.xaml
    /// </summary>
    public partial class SaticiMainView : Window
    {
        public SaticiMainView()
        {
            InitializeComponent();
        }

        private void btnKitapList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrm.Source = new Uri("/Views/SaticiViews/KitapViews/KitapListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnSatisList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrm.Source = new Uri("/Views/YoneticiViews/SatisViews/SatısListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
