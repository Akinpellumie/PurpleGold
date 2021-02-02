using PurpleGold.Models;
using PurpleGold.Services;
using PurpleGold.ViewModel;
using PurpleGold.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private AccessService accessService;
        public Command LoginCommand { get; }
        public Command ContinueCommand { get; }
        public Command SignUpCommand { get; }


        public string email;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
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
        public string fullName;

        public string FullName
        {
            get { return fullName; }
            set { SetProperty(ref fullName, value); }
        }

        public string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { SetProperty(ref phoneNumber, value); }
        }
        
        public string refCode;
        public string RefCode
        {
            get { return refCode; }
            set { SetProperty(ref refCode, value); }
        }

        public string otp;
        public string OTP
        {
            get { return otp; }
            set { SetProperty(ref otp, value); }
        }

        public string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        
        public DateTime dob;
        public DateTime DOB
        {
            get { return dob; }
            set { SetProperty(ref dob, value); }
        }
        
        public string secQue;
        public string SecQuestion
        {
            get { return secQue; }
            set { SetProperty(ref secQue, value); }
        }
        public string answer;
        public string Answer
        {
            get { return answer; }
            set { SetProperty(ref answer, value); }
        }

        public RegisterViewModel()
        {
            ContinueCommand = new Command(() => OnContinue_Clicked());
            SignUpCommand = new Command(() => OnSignUpClicked());
        }


        public void OnContinue_Clicked()
        {
            if (Email == null || Firstname == null || Lastname == null || PhoneNumber == null )
            {
                var req = "Input fields empty.";
                MessagingCenter.Send<object, string>(this, "FillAll", req);
            }
            else
            {

                var beginRegistration = "start register process";
                MessagingCenter.Send<object, string>(this, "registerStart", beginRegistration);
                var registerData = new CreateUser()
                {
                    email = Email.Trim(),
                    referralCode = RefCode,
                    firstname = Firstname.Trim(),
                    lastname = Lastname.Trim(),
                };
                //var slm = DOB.ToString();
                //DateTime date = DateTime.Parse(slm.Replace("[UTC]", ""));
                string newDate = DOB.ToLocalTime().ToString("yyyy-MM-dd");
                registerData.dob = newDate;
                //string fullName = FullName;
                //var names = fullName.Split(' ');
                //string firstName = names[0];
                //string lastName = names[1];
                //registerData.firstname = firstName;
                //registerData.lastname = lastName;
                if (PhoneNumber.Length == 11)
                {
                    var cut = PhoneNumber.Substring(1);
                    var newCut = cut;
                    var newPhne = "+234" + newCut;
                    registerData.phoneNumber = newPhne;
                }
                else
                {
                    var newPhne = "+234" + PhoneNumber;
                    registerData.phoneNumber = newPhne;
                }

                accessService = new AccessService();
                UserRegister(registerData);
            }

        }

        private async void UserRegister(CreateUser registerData)
        {
            bool res = await accessService.RegisterUser(registerData);
            //MessagingCenter.Send(this, "SuccessRegister");
            ////if (res.Equals(true))
            //{
            //    Application.Current.MainPage = new AppShell();
            //    await Shell.Current.GoToAsync("//main");
            //}
            //if (res == true)
            //{
            //    Application.Current.MainPage = new AppShell();
            //    await Shell.Current.GoToAsync("//main");
            //}
        }

        private void OnSignUpClicked()
        {
            Application.Current.MainPage = new NavigationPage(new LoginSignUpPage());
        }
    }
}
