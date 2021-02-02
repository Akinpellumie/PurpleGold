using PurpleGold.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            VersionTracking.Track();
            if (VersionTracking.IsFirstLaunchEver == true)
            {
                MainPage = new NavigationPage(new GetStartedPage());
                Settings.FirstTime = true;
            }
            else
            {
                MainPage = new NavigationPage(new SplashScreen());
                Settings.FirstTime = false;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
