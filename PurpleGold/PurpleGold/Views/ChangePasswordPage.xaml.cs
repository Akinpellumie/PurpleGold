using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PurpleGold.Helpers;
using PurpleGold.Models;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestSharp;
using Newtonsoft.Json;

namespace PurpleGold.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private void usrPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= 1)
            {
                pswdMsg.IsVisible = true;
            }

        }

        private void usrVerPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= 1)
            {
                verPswdMsg.IsVisible = true;
            }
        }

        private void usrVerPass_Unfocused(object sender, FocusEventArgs e)
        {
            verPswdMsg.IsVisible = false;
        }
        
        private void usrPass_Unfocused(object sender, FocusEventArgs e)
        {
            pswdMsg.IsVisible = false;
        }

        public async void ChangePassClicked(object sender, EventArgs e)
        {
            try
            {
                notClicked.IsVisible = false;
                clicked.IsVisible = true;
                usrPass.IsReadOnly = true;
                newPass.IsReadOnly = true;
                usrVerPass.IsReadOnly = true;
                ChangePassword change = new ChangePassword()
                {
                    oldPassword = usrPass.Text,
                    newPassword = newPass.Text
                };

                string url = Constant.ResetPasswordUrl;

                var json = JsonConvert.SerializeObject(change);
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", Settings.Token);
                request.AddHeader("appId", Settings.AppId);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                var res = response.Content;

                RootChangePassword withdrawRes = JsonConvert.DeserializeObject<RootChangePassword>(res);
                var msg = withdrawRes.message;
                var stat = withdrawRes.status;

                if (response.IsSuccessful)
                {
                    changePassStack.IsVisible = false;
                    SuccessStack.IsVisible = true;
                    await Task.Delay(500);
                    SignOutClicked();

                }
                else if (stat.Contains("400"))
                {
                    notClicked.IsVisible = true;
                    clicked.IsVisible = false;
                    errorMsg.IsVisible = true;
                    errorLabel.Text = msg;
                    usrPass.IsReadOnly = false;
                    newPass.IsReadOnly = false;
                    usrVerPass.IsReadOnly = false;
                }
                else
                {
                    notClicked.IsVisible = true;
                    clicked.IsVisible = false;
                    errorMsg.IsVisible = true;
                    errorLabel.Text = msg;
                    usrPass.IsReadOnly = false;
                    newPass.IsReadOnly = false;
                    usrVerPass.IsReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                var exe = ex.Message.ToString();
                notClicked.IsVisible = true;
                clicked.IsVisible = false;
                errorMsg.IsVisible = true;
                errorLabel.Text = exe;
                usrPass.IsReadOnly = false;
                newPass.IsReadOnly = false;
                usrVerPass.IsReadOnly = false;
                return;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        public void SignOutClicked()
        {
            try
            {
                Application.Current.MainPage = new NavigationPage(new LoginSignUpPage());
                Settings.Token = "";
                Settings.InvestmentList = null;
                Settings.Id = "";
                Settings.UserId = "";
                Settings.Lastname = "";
                Settings.Firstname = "";
                Settings.Email = "";
                Settings.ReferralCode = "";
                Settings.PhoneNumber = "";
                Settings.ImageUrl = "";
                Settings.Title = "";
                Settings.BankName = "";
                Settings.AccountNumber = "";
                Settings.AccountName = "";
                Settings.State = "";
                Settings.Address = "";

            }
            catch (Exception)
            {
                return;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}