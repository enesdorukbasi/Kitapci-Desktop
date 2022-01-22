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
using System.Windows.Shapes;

namespace KitapciApp.Wpf.Views.YoneticiViews.SatisViews
{
    /// <summary>
    /// Interaction logic for SatisView.xaml
    /// </summary>
    public partial class SatisView : Window
    {
        public SatisView()
        {
            InitializeComponent();
            DataContext = new SatısViewModel();
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
