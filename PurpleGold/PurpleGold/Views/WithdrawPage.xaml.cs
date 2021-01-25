using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.PopUps;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WithdrawPage : ContentPage
    {
        public WithdrawPage()
        {
            InitializeComponent();
            UpdateHere();
            MessagingCenter.Subscribe(this, "showBtn", (object obj, string ShowBtn) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    backBtn.BackBtn = true;
                });

            });
        }

        public void UpdateHere()
        {
            if (string.IsNullOrEmpty(Settings.AccountName))
            {
                usrname.Text = "---------------------------------------------------";
            }
            else
            {
                usrname.Text = Settings.AccountName;
            }
            
            if (string.IsNullOrEmpty(Settings.AccountNumber))
            {
                usracctno.Text = "---------------------------------------------------";
            }
            else
            {
                usracctno.Text = Settings.AccountNumber;
            }
            
            if (string.IsNullOrEmpty(Settings.BankName))
            {
                usrbnk.Text = "---------------------------------------------------";
            }
            else
            {
                usrbnk.Text = Settings.BankName;
            }


            if(string.IsNullOrEmpty(Settings.BankName) || string.IsNullOrEmpty(Settings.AccountNumber) || string.IsNullOrEmpty(Settings.AccountName))
            {
                errorMsg.IsVisible = true;
                errorLabel.Text = "Kindly Update your Bank Details on your profile to access this feature!!";
                withBtn.IsVisible = false;
                empBtn.IsVisible = true;
            }
            else
            {
                errorMsg.IsVisible = false;
                withBtn.IsVisible = true;
                empBtn.IsVisible = false;
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.FadeTo(1, 300, Easing.Linear);
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await this.FadeTo(1, 300, Easing.Linear);
        }

        public void Amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(((Entry)sender).Text))
            {
                try
                {
                    var t = double.Parse(((Entry)sender).Text.Replace("N", CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol), NumberStyles.Currency).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "N");
                    ((Entry)sender).Text = t;
                    ((Entry)sender).CursorPosition = t.Length - 3;

                }
                catch (Exception)
                {
                    return;
                }
            }

        }

        public async void MakeWithdrawal_Clicked(object sender, EventArgs e)
        {
            double bal = double.Parse(Settings.balance);
            string pet = double.Parse(Amount.Text.Replace
                          ("N", CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol),
                          NumberStyles.Currency).ToString();

            double amt = double.Parse(pet);

            if (string.IsNullOrEmpty(Amount.Text) || string.IsNullOrEmpty(pswd.Text))
            {
                errorMsg.IsVisible = true;
                errorLabel.Text = "Kindly enter amount and password to continue!";
                return;
            }
           
            else if (bal<amt)
            {
                errorMsg.IsVisible = true;
                errorLabel.Text = "Insufficient Balance...";
                return;
            }
           
            else
            {
                try
                {
                    await PopupNavigation.Instance.PushAsync(new Loader());

                    Withdraw withdraw = new Withdraw()
                    {
                        password = pswd.Text
                    };
                    string pt = double.Parse(Amount.Text.Replace
                           ("N", CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol),
                           NumberStyles.Currency).ToString();
                    withdraw.amount = pt;
                    string url = Constant.WithdrawUrl;

                    var json = JsonConvert.SerializeObject(withdraw);

                    var client = new RestClient(url);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("appId", Settings.AppId);
                    request.AddHeader("Authorization", Settings.Token);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("application/json", json, ParameterType.RequestBody);
                    IRestResponse response = await client.ExecuteAsync(request);

                    Console.WriteLine(response.Content);
                    var res = response.Content;

                    RootWallet withdrawRes = JsonConvert.DeserializeObject<RootWallet>(res);
                    var msg = withdrawRes.message;

                    if (response.IsSuccessful)
                    {
                        await PopupNavigation.Instance.PopAsync(true);
                        Amount.Text = "";
                        pswd.Text = "";
                        await DisplayAlert("Success!!!", "Withdrawal request sent successfully!", "Ok");
                        
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        await PopupNavigation.Instance.PopAsync(true);
                        await DisplayAlert("Success!!!", msg, "Ok");
                    }
                    else
                    {
                        await PopupNavigation.Instance.PopAsync(true);
                        
                        await DisplayAlert("Server error!!!", msg, "Ok");
                    }

                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}