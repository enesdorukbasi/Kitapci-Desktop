using KitapciApp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KitapciApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Kullanıcı Kullanıcı { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Window yoneticiMain = new Views.MainViews.YoneticiMainView();
            Window saticiMain = new Views.MainViews.SaticiMainView();

            Views.LoginView.LoginView view = new Views.LoginView.LoginView();
            if (view.ShowDialog() == true)
            {

                if (Kullanıcı.Yetki == Yetkiler.Yonetici)
                {
                    MainWindow = yoneticiMain;
                    saticiMain.Close();
                }
                else
                {
                    MainWindow = saticiMain;
                    yoneticiMain.Close();
                }

                MainWindow.Show();
            }
        }
    }
}
