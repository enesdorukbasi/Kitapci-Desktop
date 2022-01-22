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

namespace KitapciApp.Wpf.Views.YoneticiViews.TurViews
{
    /// <summary>
    /// Interaction logic for TurView.xaml
    /// </summary>
    public partial class TurView : Window
    {
        public TurView()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
            txtTurAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            DialogResult = true;
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
