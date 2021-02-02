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
    public partial class GetStartedPage : ContentPage
    {
        SplashViewModel splashViewModel;
        public GetStartedPage()
        {
            splashViewModel = new SplashViewModel(Navigation);
            InitializeComponent();
            BindingContext = splashViewModel;
        }

        public async void Skip_Clicked(object sender, EventArgs e)
        {
            //var want = "switch to sign up view";
            //MessagingCenter.Send<object, string>(this, "wanted", want);
            //MessagingCenter.Send(this, "showSignUp");
            //MessagingCenter.Send(this, "Hi");
            //Settings.FirstTime = true;
            await Navigation.PushAsync(new LoginSignUpPage());

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.FadeTo(1, 500, Easing.SpringIn);
        }
    }
}