using PurpleGold.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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
            AppCenter.Start("android=ba867121-4dc6-4e23-a6cc-40fc792b11ad;" +
                  "uwp={Your UWP App secret here};" +
                  "ios=bb671908-0277-4c8b-b1ab-e59b2909f2cb",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
