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
            if(Settings.FirstTime == true)
            {
                CallSignUp();
            }
            else
            {
                Settings.FirstTime = false;
            }
            MessagingCenter.Subscribe(this, "accountCreated", (object obj, string AccountCreated) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    SuccessCall();
                });

            });
            MessagingCenter.Subscribe(this, "showPass", (object obj, string forgotPassClicked) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var result = forgotPassStack;
                    loginStack.IsVisible = false;
                    login.Text = "Back to Login";
                    forgotPassStack.IsVisible = true;
                });

            });
        }

        public async void SuccessCall()
        {
            if (login.Text.Contains("Back to Login"))
            {
                login.Text = "Login";
            }
            LogActive.IsVisible = true;
            login.TextColor = Color.FromHex("9E079E");
            signup.TextColor = Color.FromHex("CC97CC");
            active.IsVisible = false;
            await first.ScaleTo(1, 250, Easing.BounceIn);
            loginStack.IsVisible = true;
            forgotPassStack.IsVisible = false;
            signUpStack.IsVisible = false;
            await loginStack.FadeTo(1, 250, Easing.SinInOut);
        }
       
        private async void LoginStack_Tapped(object sender, EventArgs e)
        {
            if(login.Text.Contains("Back to Login"))
            {
                login.Text = "Login";
            }
            LogActive.IsVisible = true;
            login.TextColor = Color.FromHex("9E079E");
            signup.TextColor = Color.FromHex("CC97CC");
            active.IsVisible = false;
            await first.ScaleTo(1, 250, Easing.BounceIn);
            loginStack.IsVisible = true;
            forgotPassStack.IsVisible = false;
            signUpStack.IsVisible = false;
            await loginStack.FadeTo(1, 250, Easing.SinInOut);
        }

        public async void CallSignUp()
        {
            LogActive.IsVisible = false;
            login.TextColor = Color.FromHex("CC97CC");
            signup.TextColor = Color.FromHex("9E079E");
            active.IsVisible = true;
            await second.ScaleTo(1, 250, Easing.BounceIn);
            signUpStack.IsVisible = true;
            forgotPassStack.IsVisible = false;
            loginStack.IsVisible = false;
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
            forgotPassStack.IsVisible = false;
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