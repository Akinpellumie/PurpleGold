using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.PopUps;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvestPage : ContentPage
    {
        string MyPlan;
        string MyPlanIcon;
        string gelato;
        string honorable;
        string midas;
        string planId;
        string mouUrl;

        public InvestPage()
        {
            InitializeComponent();
            var date = DateTime.Today;
            var newDate = date.ToLocalTime().ToString("ddd, MMM d, yyyy");
            startDate.Text = newDate;

            MessagingCenter.Subscribe(this, "selectedPlan", (object obj, string SelectedPlan) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MyPlan = SelectedPlan;
                    myPlan.Text = SelectedPlan;
                    myPlan.HorizontalTextAlignment = TextAlignment.Start;
                    if (SelectedPlan.StartsWith("Gel"))
                    {
                        gelato = "1";
                        var dDate = DateTime.Today.AddDays(31);
                        var newDdate = dDate.ToLocalTime().ToString("ddd, MMM d, yyyy");
                        endDate.Text = newDdate;
                    }
                    else if (SelectedPlan.StartsWith("Hon"))
                    {
                        honorable = "3";
                        var dDate = DateTime.Today.AddDays(93);
                        var newDdate = dDate.ToLocalTime().ToString("ddd, MMM d, yyyy");
                        endDate.Text = newDdate;
                    }
                    else if (SelectedPlan.StartsWith("Mid"))
                    {
                        midas = "6";
                        var dDate = DateTime.Today.AddDays(186);
                        var newDdate = dDate.ToLocalTime().ToString("ddd, MMM d, yyyy");
                        endDate.Text = newDdate;
                    }

                });

            });

            MessagingCenter.Subscribe(this, "showBtn", (object obj, string ShowBtn) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    backBtn.BackBtn = true;
                });

            });

            MessagingCenter.Subscribe(this, "selectedPlanIcon", (object obj, ImageSource SelectedPlanIcon) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //MyPlanIcon = SelectedPlanIcon;
                    planIcon.Source = SelectedPlanIcon;

                });

            });
            
            MessagingCenter.Subscribe(this, "selectedPlanId", (object obj, string SelectedPlanId) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    planId = SelectedPlanId;

                });

            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.FadeTo(1, 500, Easing.Linear);
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await this.FadeTo(1, 500, Easing.Linear);
        }

        public void Interest_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(((Entry)sender).Text))
            {
                try
                {
                    var ti = double.Parse(((Entry)sender).Text.Replace("N", CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol), NumberStyles.Currency).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "N");
                    ((Entry)sender).Text = ti;
                    ((Entry)sender).CursorPosition = ti.Length - 3;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            AmterrorMsg.IsVisible = false;
            errorMsg.IsVisible = false;
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


        public void CalcInterest_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                var pee = double.Parse(amount.Text.Replace
                    ("N", CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol),
                    NumberStyles.Currency).ToString();
                if (pee != null)
                {
                    int TargetDefect;
                    if (MyPlan.StartsWith("Gel"))
                    {
                        if (int.TryParse(pee, out TargetDefect))
                        {
                            double Per = ((double)TargetDefect) * 0.2;
                            double pel = Per + TargetDefect;
                            interest.Text = pel.ToString();
                        }
                    }
                    else if (MyPlan.StartsWith("Hon"))
                    {
                        if (int.TryParse(pee, out TargetDefect))
                        {
                            double Per = ((double)TargetDefect) * 0.2;
                            double perrr = Per * 3;
                            double pel = perrr + TargetDefect;

                            interest.Text = pel.ToString();
                        }
                    }
                    else if (MyPlan.StartsWith("Mid"))
                    {
                        if (int.TryParse(pee, out TargetDefect))
                        {
                            //first month
                            double per = ((double)TargetDefect) * 0.2;
                            double pel = per + TargetDefect;

                            //second month
                            double per2 = pel * 0.2;
                            double pel2 = per2 + pel;

                            //third month
                            double per3 = pel2 * 0.2;
                            double pel3 = per3 + pel2;

                            //fourth month
                            double per4 = pel3 * 0.2;
                            double pel4 = per4 + pel3;

                            //fifth month
                            double per5 = pel4 * 0.2;
                            double pel5 = per5 + pel4;

                            //sixth month
                            double per6 = pel5 * 0.2;
                            double pel6 = per6 + pel5;

                            interest.Text = pel6.ToString();
                        }
                    }
                    

                }
                else if (amount.Text == null)
                {
                    interest.Text = "";
                }
                if (string.IsNullOrEmpty(amount.Text))
                {
                    interest.Text = "";
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        #region download MOU pdf
        public void PdfClickHandler()
        {
            string filename = Settings.Firstname + " " + Settings.Lastname + "MOU";
            var webClient = new WebClient();

            webClient.DownloadDataCompleted += (s, e) => {
                var data = e.Result;
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string localFilename = $"{filename}.pdf";
                System.IO.File.WriteAllBytes(Path.Combine(documentsPath, localFilename), data);
                Device.BeginInvokeOnMainThread(async () => {
                    //new displa("Done", "File downloaded and saved", null, "OK", null).Show();
                    await DisplayAlert("Done!", "File downladed and saved successfully","Ok");
                });
            };
            string urlee = Constant.DownloadUrl + mouUrl;
            var url = new Uri(urlee);
            webClient.DownloadDataAsync(url);
        }
        #endregion
        #region PickerCalls
        public async void CallPickerScreen_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PlanPopUp());
        }
        #endregion

        #region create investment
        public async void CreateInvestment_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amount.Text))
            {
                AmterrorMsg.IsVisible = true;
                AmterrorLabel.Text = "Kindly fill all entries to  coninue!";
                return;
            }
            try
            {
                string pt = double.Parse(amount.Text.Replace
                    ("N", CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol),
                    NumberStyles.Currency).ToString();
                double amt = double.Parse(pt);

                double relAmt = 25000;
                if (amt < relAmt)
                {
                    AmterrorMsg.IsVisible = true;
                    AmterrorLabel.Text = "Investment requires a minimum of N25,000.00";
                    return;
                }
                if(check.IsChecked != true)
                {
                    errorMsg.IsVisible = true;
                    errorLabel.Text = "Kindly agree to Terms and Condition to continue!";
                    return;
                }
                else if (string.IsNullOrEmpty(amount.Text) || string.IsNullOrEmpty(interest.Text) || string.IsNullOrEmpty(MyPlan))
                {
                    errorMsg.IsVisible = true;
                    errorLabel.Text = "Kindly fill all entries to  coninue!";
                    return;
                }
                else
                {
                    try
                    {

                        await PopupNavigation.Instance.PushAsync(new Loader());

                        CreateInvestment invest = new CreateInvestment()
                        {
                            planId = planId,
                            roi = "20",
                            amount = pt
                        };
                        if (MyPlan.StartsWith("Gela"))
                        {
                            invest.duration = "1";
                        }
                        else if (MyPlan.StartsWith("Hon"))
                        {
                            invest.duration = "3";
                        }
                        else if (MyPlan.StartsWith("Mid"))
                        {
                            invest.duration = "6";
                        }
                        String url = Constant.InvestUrl;


                        var json = JsonConvert.SerializeObject(invest);

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

                        Invest investRes = JsonConvert.DeserializeObject<Invest>(res);
                        var msg = investRes.message;
                        var stats = investRes.status;
                        mouUrl = investRes.Investments[0].MouUrl;

                        if (response.IsSuccessful)
                        {
                            await PopupNavigation.Instance.PopAsync(true);
                            await PopupNavigation.Instance.PushAsync(new SuccessPopUp());
                            mainView.IsVisible = false;
                            MouView.IsVisible = true;
                            //Settings.UserId = newUser.createUserData.id;
                            //AppShell fpm = new AppShell();
                            //Application.Current.MainPage = fpm;
                        }
                        else if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            await PopupNavigation.Instance.PopAsync(true);
                            MessagingCenter.Send<object, string>(this, "error", msg);
                            await PopupNavigation.Instance.PushAsync(new FailPopUp());
                        }
                        else if (stats.Contains("500"))
                        {
                            await PopupNavigation.Instance.PopAsync(true);
                            MessagingCenter.Send<object, string>(this, "error", msg);
                            await PopupNavigation.Instance.PushAsync(new FailPopUp());
                        }
                        else
                        {
                            await PopupNavigation.Instance.PopAsync(true);
                            MessagingCenter.Send<object, string>(this, "error", msg);
                            await PopupNavigation.Instance.PushAsync(new FailPopUp());
                        }
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion

        public void DownLoadMouClicked(object sender, EventArgs e)
        {
            PdfClickHandler();
        }
    }
}