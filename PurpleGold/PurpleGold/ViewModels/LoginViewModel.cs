using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.Services;
using PurpleGold.ViewModel;
using PurpleGold.Views;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private AccessService accessService;
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }


        public string email;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public string fullName;

        public string FullName
        {
            get { return fullName; }
            set { SetProperty(ref fullName, value); }
        }

        public string firstName;

        public string Firstname
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        public string lastName;

        public string Lastname
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        public string phoneNo;
        public string PhoneNo
        {
            get { return phoneNo; }
            set { SetProperty(ref phoneNo, value); }
        }

        public string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public LoginViewModel()
        {
            //CheckBalance();
            LoginCommand = new Command(() => OnLoginBtn_Clicked());
            SignUpCommand = new Command(() => OnSignUpClicked());
        }


        public void OnLoginBtn_Clicked()
        {
            if (Email == null || Password == null)
            {
                var required = "Fill all fields.";
                MessagingCenter.Send<object, string>(this, "FillAllFields", required);
            }
            else
            {
                
                var beginLogin = "start login process";
                MessagingCenter.Send<object, string>(this, "loginStart", beginLogin);
                var loginData = new LoginUser()
                {
                    //email = Email,
                    password = Password
                };
                var ema = Email.Split(' ');
                loginData.email = ema[0];
                accessService = new AccessService();
                UserLogin(loginData);
            }

        }

        private async void UserLogin(LoginUser loginData)
        {
            bool res = await accessService.LoginUser(loginData);

            if (res.Equals(true))
            {
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync("//main");
            }
            if (res == true)
            {
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync("//main");
            }
        }


        private void OnSignUpClicked()
        {
            Application.Current.MainPage = new NavigationPage(new LoginSignUpPage());
        }
    }
}
