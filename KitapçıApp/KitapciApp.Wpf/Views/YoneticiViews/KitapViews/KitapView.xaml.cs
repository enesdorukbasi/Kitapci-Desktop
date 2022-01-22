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

namespace KitapciApp.Wpf.Views.YoneticiViews.KitapViews
{
    /// <summary>
    /// Interaction logic for KitapView.xaml
    /// </summary>
    public partial class KitapView : Window
    {
        public KitapView()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
            txtBarkod.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtKitapAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtYazar.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtFiyat.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtAdet.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cbTur.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();

            DialogResult = true;
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
