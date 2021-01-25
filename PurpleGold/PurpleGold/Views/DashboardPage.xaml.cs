using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.ViewModels;
using RestSharp;
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
    public partial class DashboardPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public DashboardPage()
        {
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            UpdateMe();
            CheckBalance();
            this.BindingContext = loginViewModel;
            
        }

        public void UpdateMe()
        {
            var name = Settings.Firstname + " " + Settings.Lastname;
            myName.Text = name;
            //var bal = Settings.Balance;
            //acctBal.Text = bal;
            if (string.IsNullOrEmpty(Settings.AccountNumber))
            {
                myAcct.Text = "xxxxxxxxxx";
            }
            else
            {
                myAcct.Text = Settings.AccountNumber;
            }

            if (string.IsNullOrEmpty(Settings.ImageUrl))
            {
                usrIcon.Source = "undrawPro.svg";
            }
            else
            {
                usrIcon.Source = Settings.ImageUrl;
            }
        }

        public async void CheckBalance()
        {
            string url = Constant.GetWalletUrl + Settings.UserId;

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("appId", Settings.AppId);
            request.AddHeader("Authorization", Settings.Token);
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            var res = response.Content;
            RootWallet wallets = JsonConvert.DeserializeObject<RootWallet>(res);
            var sorted = wallets.Wallets;
            Settings.balance = sorted[0].balance;
        }

        public async void WithdrawBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WithdrawPage());
            var ShowBtn = "Show Back Button";
            MessagingCenter.Send<object, string>(this, "showBtn", ShowBtn);
        }
        
        public async void InvestBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InvestPage());
            var ShowBtn = "Show Back Button";
            MessagingCenter.Send<object, string>(this, "showBtn", ShowBtn);
        }
        
        public async void DepositBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DepositPage());
            var ShowBtn = "Show Back Button";
            MessagingCenter.Send<object, string>(this, "showBtn", ShowBtn);
        }
        
        public async void AssetBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssetPage());
            var ShowBtn = "Show Back Button";
            MessagingCenter.Send<object, string>(this, "showBtn", ShowBtn);
        }
        
        public async void FaqBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FAQPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.FadeTo(1, 250, Easing.SinInOut);
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await this.FadeTo(1, 250, Easing.SinInOut);
        }

        
        public async void TransferBtn_Clicked(object sender, EventArgs e)
        {
            transIcon.IsVisible = false;
            TransLbl.IsVisible = true;
            await TransLbl.FadeTo(0, 2000, Easing.BounceOut);
            await Task.Delay(2000);
            TransLbl.IsVisible = false;
            transIcon.IsVisible = true;

        }
        
        public async void SwapBtn_Clicked(object sender, EventArgs e)
        {
            swapIcon.IsVisible = false;
            swapLbl.IsVisible = true;
            await swapLbl.FadeTo(0, 2000, Easing.BounceOut);
            await Task.Delay(2000);
            swapLbl.IsVisible = false;
            swapIcon.IsVisible = true;

        }


        public void ShowCloseTapped(object sender, EventArgs e)
        {
            if (showClose.Text.StartsWith("Show"))
            {
                acctBal.Text = Settings.Balance;
                showClose.Text = "Hide Balance";
            }
            else if (showClose.Text.StartsWith("Hide"))
            {
                acctBal.Text = "NXX,XXX.XX";
                showClose.Text = "Show Balance";
            }
        }
    }
}