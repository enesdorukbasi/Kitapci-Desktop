using KitapciApp.Wpf.ViewModels.SatısViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KitapciApp.Wpf.Views.YoneticiViews.SatisViews
{
    /// <summary>
    /// Interaction logic for SatısListView.xaml
    /// </summary>
    public partial class SatısListView : Page
    {
        public SatısListView()
        {
            InitializeComponent();
            DataContext = new SatısListViewModel();
        }

        private void btnSatis_Click(object sender, RoutedEventArgs e)
        {
            SatisView satisView = new SatisView();
            satisView.ShowDialog();
        }
    }
}
