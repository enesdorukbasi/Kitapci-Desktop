using KitapciApp.Wpf.ViewModels.TurViewModels;
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

namespace KitapciApp.Wpf.Views.YoneticiViews.TurViews
{
    /// <summary>
    /// Interaction logic for TurListView.xaml
    /// </summary>
    public partial class TurListView : Page
    {
        public TurListView()
        {
            InitializeComponent();
            DataContext = new TurListViewModel();
        }
    }
}
