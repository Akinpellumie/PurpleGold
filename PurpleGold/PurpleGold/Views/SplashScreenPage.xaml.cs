using PurpleGold.ViewModels;
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
    public partial class SplashScreenPage : ContentPage
    {
        SplashViewModel splashViewModel;
        public SplashScreenPage()
        {
            splashViewModel = new SplashViewModel(Navigation);
            InitializeComponent();
            BindingContext = splashViewModel;
        }

        private async void Skip_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginSignUpPage());
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.FadeTo(1, 500, Easing.SpringIn);
        }
    }
}