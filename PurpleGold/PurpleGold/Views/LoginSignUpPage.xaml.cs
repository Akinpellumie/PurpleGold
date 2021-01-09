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
    public partial class LoginSignUpPage : ContentPage
    {
        public LoginSignUpPage()
        {
            InitializeComponent();
        }

        private async void LoginStack_Tapped(object sender, EventArgs e)
        {
            LogActive.IsVisible = true;
            login.TextColor = Color.FromHex("9E079E");
            signup.TextColor = Color.FromHex("CC97CC");
            active.IsVisible = false;
            await first.ScaleTo(1, 250, Easing.BounceIn);
            loginStack.IsVisible = true;
            signUpStack.IsVisible = false;
            await loginStack.FadeTo(1, 250, Easing.SinInOut);
        }

        private async void SignUpStack_Tapped(object sender, EventArgs e)
        {
            LogActive.IsVisible = false;
            login.TextColor = Color.FromHex("CC97CC");
            signup.TextColor = Color.FromHex("9E079E");
            active.IsVisible = true;
            await second.ScaleTo(1, 250, Easing.BounceIn);
            signUpStack.IsVisible = true;
            loginStack.IsVisible = false;
            await loginStack.FadeTo(1, 250, Easing.SinInOut);
        }

        private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            LogActive.IsVisible = false;
            login.TextColor = Color.FromHex("CC97CC");
            signup.TextColor = Color.FromHex("9E079E");
            active.IsVisible = true;
            await second.ScaleTo(1, 250, Easing.BounceIn);
            signUpStack.IsVisible = true;
            loginStack.IsVisible = false;
            await loginStack.FadeTo(1, 250, Easing.SinInOut);
        }
    }
}