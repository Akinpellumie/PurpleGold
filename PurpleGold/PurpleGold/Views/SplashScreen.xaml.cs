using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            logo.FadeTo(360, 3000);
            logo.FadeAnimationDuration = 300;
            logo.FadeAnimationEnabled = true;
            await logo.ScaleTo(1, 2000, Easing.SinIn);
            await logo.ScaleTo(1, 1000, Easing.SinInOut);
            Application.Current.MainPage = new NavigationPage(new LoginSignUpPage());
        }
    }
}