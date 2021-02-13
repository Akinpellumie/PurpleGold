using PurpleGold.Services;
using PurpleGold.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginTemplate : ContentView
    {
        public LoginTemplate()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            MessagingCenter.Subscribe<AccessService>(this, "LoginFailed", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() => 
                {
                    errorMsg.IsVisible = true;
                    usrEmail.IsReadOnly = false;
                    usrPass.IsReadOnly = false;
                    idleBtn.IsVisible = true;
                    loadingBtn.IsVisible = false;
                    errorLabel.Text = "Invalid Credentials, please try again!";
                });
            });
            
            //MessagingCenter.Subscribe<AccessService>(this, "SuccessLogin", (sender) =>
            //{
            //    Device.BeginInvokeOnMainThread(async () => 
            //    {
            //        Application.Current.MainPage = new AppShell();
            //        await Shell.Current.GoToAsync("//main");
            //    });
            //});

            MessagingCenter.Subscribe(this, "FillAllFields", (object obj, string required) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    errorMsg.IsVisible = true;
                    errorLabel.Text = "Kindly input your Email and Password";
                });

            });
            
            MessagingCenter.Subscribe(this, "FirstTime", (object obj, string firstTimer) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    errorMsg.IsVisible = true;
                    errorLabel.Text = "No Registered Credentials. Login with Email and Password to register Credentials";
                });

            });
            
            MessagingCenter.Subscribe(this, "loginStart", (object obj, string beginLogin) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    usrEmail.IsReadOnly = true;
                    usrPass.IsReadOnly = true;
                    idleBtn.IsVisible = false;
                    loadingBtn.IsVisible = true;
                    errorMsg.IsVisible = false;
                });

            });
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(usrEmail.Text) || string.IsNullOrEmpty(usrPass.Text))
            {
                errorMsg.IsVisible = true;
                errorLabel.Text = "Kindly input your Email and Password";
            }
            else
            {
                idleBtn.IsVisible = false;
                loadingBtn.IsVisible = true;
                await Task.Delay(300);
                await this.FadeTo(1, 250, Easing.SinInOut);
                AppShell fpm = new AppShell();
                Application.Current.MainPage = fpm;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var forgotPassClicked  = "ShowPassView";
            MessagingCenter.Send<object, string>(this, "showPass", forgotPassClicked);
        }

        protected async override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            await this.FadeTo(1, 250, Easing.SinInOut);
            try
            {
                var password = await SecureStorage.GetAsync("password");
                //usrPass.Text = password;
                var email = await SecureStorage.GetAsync("email");
                usrEmail.Text = email;
            }
            catch (Exception)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }
        protected async override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            await this.FadeTo(1, 250, Easing.SinInOut);
            try
            {
                var password = await SecureStorage.GetAsync("password");
                //usrPass.Text = password;
                var email = await SecureStorage.GetAsync("email");
                usrEmail.Text = email;
            }
            catch (Exception)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        private void usrPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorMsg.IsVisible = false;
            usrPass.TextColor = Color.FromHex("000000");
        }

        private void usrEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorMsg.IsVisible = false;
            usrEmail.TextColor = Color.FromHex("000000");
        }
    }
}