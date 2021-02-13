using Newtonsoft.Json;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.PopUps;
using PurpleGold.Services;
using PurpleGold.ViewModel;
using PurpleGold.Views;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private AccessService accessService;
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }
        public Command FingerPrintCommand { get; }


        public string email = Preferences.Get(nameof(Email), string.Empty);

        public string Email
        {
            get { return email; }
            set 
            { 
                SetProperty(ref email, value);
                Preferences.Set(nameof(Email), value);
                OnPropertyChanged(nameof(Email));
                //SecureStorage.SetAsync("email", Email);
            }
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

        private bool fingerPrint;
        public bool FingerPrint
        {
            get => fingerPrint;
            set
            {
                fingerPrint = value;
                OnPropertyChanged(nameof(FingerPrint));
            }
        }

        public string password;
        public string Password
        {
            get { return password; }
            set 
            { 
                SetProperty(ref password, value);
                //OnPropertyChanged(nameof(Password));
               // SecureStorage.SetAsync("password", Password);
            }
        }

        public LoginViewModel()
        {
            //CheckBalance();
            Permission();
            LoginCommand = new Command(() => OnLoginBtn_Clicked());
            SignUpCommand = new Command(() => OnSignUpClicked());
            FingerPrintCommand = new Command(() => FingerPrint_Clicked());
        }

        public async void Permission()
        {
            try
            {
                await Permissions.RequestAsync<Permissions.Camera>();
                await Permissions.RequestAsync<Permissions.StorageRead>();
                await Permissions.RequestAsync<Permissions.StorageWrite>();
                await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                await Permissions.RequestAsync<Permissions.LocationAlways>();
                await Permissions.RequestAsync<Permissions.NetworkState>();
            }
            catch (Exception)
            {
                return;
            }

        }
        public void FingerPrint_Clicked()
        {
            FingerPrint = true;
            FingerprintAuth();
        }
        public async void FingerprintAuth()
        {
            bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);
            if (!isFingerprintAvailable)
            {
                await PopupNavigation.Instance.PushAsync(new FingerPermission());
                return;
            }

            var request = new AuthenticationRequestConfiguration("Biometric Login", "Please tap your fingerprint sensor to continue");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            if (result.Authenticated)
            {
                // do secret stuff :)
                //Success
                var password = await SecureStorage.GetAsync("password");
                Password = password;
                var username = await SecureStorage.GetAsync("email");
                Email = username;

                var authSuccess = "Authentication Successful";
                MessagingCenter.Send<object, string>(this, "authS", authSuccess);
                await PopupNavigation.Instance.PushAsync(new FingerPrintPopUp());
                await Task.Delay(200);
                await PopupNavigation.Instance.PopAsync(true);
                OnLoginBtn_Clicked();
            }
            else
            {
                // not allowed to do secret stuff :(
                var authFail = "Authentication Failed";
                MessagingCenter.Send<object, string>(this, "authF", authFail);
                await PopupNavigation.Instance.PushAsync(new FingerPermission());
            }


            //AuthenticationRequestConfiguration conf =
            //    new AuthenticationRequestConfiguration("Authentication",
            //    "Authenticate access to your personal data");

            //var authResult = await CrossFingerprint.Current.AuthenticateAsync(conf);
            //if (authResult.Authenticated)
            //{


            //}
            //else
            //{

            //}
        }
        async void LoginDetails()
        {
            try
            {
                await SecureStorage.SetAsync("password", Password);
                await SecureStorage.SetAsync("email", Email);
            }
            catch (Exception)
            {
                return;
            }
        }
        public void OnLoginBtn_Clicked()
        {
            if (Email == null || Password == null && FingerPrint == true)
            {
                var firstTimer = "first time login";
                MessagingCenter.Send<object, string>(this, "FirstTime", firstTimer);
            }
            if (Email == null || Password == null)
            {
                var required = "Fill all fields.";
                MessagingCenter.Send<object, string>(this, "FillAllFields", required);
            }
            else if(Email != null && Password != null)
            {
                LoginDetails();
                var beginLogin = "start login process";
                MessagingCenter.Send<object, string>(this, "loginStart", beginLogin);
                var loginData = new LoginUser()
                {
                    email = Email.Trim(),
                    password = Password
                };
                accessService = new AccessService();
                UserLogin(loginData);
            }
            else if (FingerPrint == true)
            {
                var beginLogin = "start login process";
                MessagingCenter.Send<object, string>(this, "loginStart", beginLogin);
                var loginData = new LoginUser()
                {
                    email = Email.Trim(),
                    password = Password
                };
                accessService = new AccessService();
                UserLogin(loginData);
            }

        }

        private async void UserLogin(LoginUser loginData)
        {
            bool res = await accessService.LoginUser(loginData);

            //if (res.Equals(true))
            //{
            //    Application.Current.MainPage = new AppShell();
            //    await Shell.Current.GoToAsync("//main");
            //}
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
