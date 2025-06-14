using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4_Zykova_Sofya
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Установка темной темы
            Application.Current.UserAppTheme = OSAppTheme.Dark;

            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart(){}

        protected override void OnSleep(){}

        protected override void OnResume(){}
    }
}
