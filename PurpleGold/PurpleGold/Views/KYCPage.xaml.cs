using Newtonsoft.Json;
using Plugin.FilePicker;
using Plugin.FileUploader.Abstractions;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.PopUps;
using PurpleGold.ViewModels;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KYCPage : ContentPage
    {
        string BankCode;
        string BankName;
        PersonViewModel personViewModel;
        string filename;
        FileBytesItem bfitem;
        private string fileName;
        string UserImage;

        public KYCPage()
        {
            personViewModel = new PersonViewModel(Navigation);
            InitializeComponent();
            UpdateMe();
            this.BindingContext = personViewModel;
            
            MessagingCenter.Subscribe(this, "bankName", (object obj, string selectedBank) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    BankName = selectedBank;
                    bankName.Text = selectedBank;
                    bankName.HorizontalTextAlignment = TextAlignment.Start;

                });

            });
            
            MessagingCenter.Subscribe(this, "selectedBankCode", (object obj, string SelectedBankCode) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    BankCode = SelectedBankCode;

                });

            });
            
            MessagingCenter.Subscribe(this, "selectedTitle", (object obj, string SelectedTitle) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //BankCode = SelectedBankCode;
                    desgn.Text = SelectedTitle;
                    bankName.HorizontalTextAlignment = TextAlignment.Start;

                });

            });
            
            MessagingCenter.Subscribe(this, "stateName", (object obj, string StateName) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //BankCode = SelectedBankCode;
                    state.Text = StateName;
                    state.HorizontalTextAlignment = TextAlignment.Start;

                });

            });
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

        public void UpdateMe()
        {
            if (string.IsNullOrEmpty(Settings.BankName))
            {
                bankName.Text = "Bank";
            }
            else
            {
                bankName.Text = Settings.BankName;
            }
            if (string.IsNullOrEmpty(Settings.Title))
            {
                desgn.Text = "None";
            }
            else
            {
                desgn.Text = Settings.Title;
            }
            
            if (string.IsNullOrEmpty(Settings.AccountNumber))
            {
                usracctno.Text = "";
            }
            else
            {
                usracctno.Text = Settings.AccountNumber;
            }
            
            if (string.IsNullOrEmpty(Settings.AccountName))
            {
                usracctname.Text = "";
            }
            else
            {
                usracctname.Text = Settings.AccountName;
            }
            
            if (string.IsNullOrEmpty(Settings.State))
            {
                state.Text = "";
            }
            else
            {
                state.Text = Settings.State;
            }
            
            if (string.IsNullOrEmpty(Settings.Address))
            {
                usraddr.Text = "";
            }
            else
            {
                usraddr.Text = Settings.Address;
            }

            if (string.IsNullOrEmpty(Settings.ImageUrl))
            {
                userImagePro.Source = "undrawPro.svg";
            }
            else
            {
                userImagePro.Source = Settings.ImageUrl;
            }
        }

        #region PickerCalls
        public async void CallPickerScreen_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new TitlePicker());
        }
        
        public async void CallBankListScreen_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new BankPicker());
        }
        #endregion

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new StatePopUp());
        }

        public async void CallPrfUploadAsync(object sender, EventArgs e)
        {
            try
            {
                var file2 = await CrossFilePicker.Current.PickFile();

                bfitem = new FileBytesItem("fileName", file2.DataArray, file2.FileName);

                FilePathItem fpitem = new FilePathItem("fileName", file2.FilePath);

                userImagePro.Source = ImageSource.FromStream(() => file2.GetStream());

                if (file2 != null)
                {
                    filename = file2.FilePath;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        async Task
        IconImg_Clicked()
        {
            try
            {

                FileUploadResponse k = null;
                try
                {


                    k = await Plugin.FileUploader.CrossFileUploader.Current.UploadFileAsync(Constant.UploadUrl, bfitem, new Dictionary<string, string>() { { "Authorization", Settings.Token } }, new Dictionary<string, string>() { { "fileName", this.fileName } });
                }
                catch (Exception)
                {
                    return;
                }
                var res = k.Message;
                File upload = JsonConvert.DeserializeObject<File>(res);
                var msg = upload.message;
                var fileUp = upload.data;
                //string responset = res;
                if (k.StatusCode == 200)
                {

                    UserImage = fileUp;

                }
                else if (k.StatusCode == 401)
                {
                    await DisplayAlert("Oops!", "Server error, please try again later", "ok");
                }
                else
                {
                    await DisplayAlert("Whoops!", "Seems the server is unavailable at the moment!", "ok");
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        async


Task
UpdateMemberClicked()
        {

            try
            {
                UpdateUser update = new UpdateUser()
                {
                    phoneNumber = Settings.PhoneNumber,
                    title = desgn.Text,
                    houseResidence = usraddr.Text,
                    state = state.Text,
                    bank = bankName.Text,
                    accountNumber = usracctno.Text,
                    accountName = usracctname.Text,
                    firstname = Settings.Firstname,
                    lastname = Settings.Lastname
                };

                if (string.IsNullOrEmpty(UserImage))
                {
                    update.imageUrl = Settings.ImageUrl;
                }
                else
                {
                    update.imageUrl = UserImage;
                }

                string url = Constant.UpdateUser;


                var jsonUpd = JsonConvert.SerializeObject(update);

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.PATCH);
                request.AddHeader("appId", Settings.AppId);
                request.AddHeader("Authorization", Settings.Token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", jsonUpd, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                Person personProfile = JsonConvert.DeserializeObject<Person>(response.Content);
                var err = personProfile.message;

                if (response.IsSuccessful)
                {
                    
                    await PopupNavigation.Instance.PopAsync(true);
                    await PopupNavigation.Instance.PushAsync(new SuccessPopUp());
                    //Settings.BankName = bankName.Text;
                    //Settings.AccountNumber = usracctno.Text;
                    //Settings.AccountName = usracctname.Text;
                    GetUserById();
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        await PopupNavigation.Instance.PopAsync(true);
                        MessagingCenter.Send<object, string>(this, "error", err);
                        await PopupNavigation.Instance.PushAsync(new FailPopUp());

                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await PopupNavigation.Instance.PopAsync(true);
                        await DisplayAlert("Oops!", "Session expired. Kindly Login again.", "Ok");
                        Application.Current.MainPage = new NavigationPage(new LoginSignUpPage());

                    }
                    else
                    {
                        await PopupNavigation.Instance.PopAsync(true);
                        await DisplayAlert("Oops!", "Please try again later.", "Ok");
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }


        public async void UpdateUserClicked(object sender, EventArgs e)
        {
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.None)
                {
                    await DisplayAlert("Oops!","Please check your internet connection","Ok");
                    return;
                }
                else if(desgn.Text.Contains("None") || string.IsNullOrEmpty(usracctname.Text) || string.IsNullOrEmpty(usracctno.Text) || bankName.Text.StartsWith("Bank"))
                {
                    await DisplayAlert("Oops!","Kindly fill all inputs to continue!","Ok");
                    return;
                }

                await PopupNavigation.Instance.PushAsync(new Loader());
                if (string.IsNullOrEmpty(Settings.ImageUrl) && string.IsNullOrEmpty(filename))
                {
                    await UpdateMemberClicked();
                }
                else if (string.IsNullOrEmpty(Settings.ImageUrl) && !string.IsNullOrEmpty(filename))
                {
                    await IconImg_Clicked();
                    await UpdateMemberClicked();
                }
                else if (!string.IsNullOrEmpty(Settings.ImageUrl) && !string.IsNullOrEmpty(filename))
                {
                    await IconImg_Clicked();
                    //await Task.CompletedTask;
                    //{ { await IconImg_Clicked(); } }
                    await UpdateMemberClicked();
                }
                else if (!string.IsNullOrEmpty(Settings.ImageUrl) && string.IsNullOrEmpty(filename))
                {
                    await UpdateMemberClicked();
                }
                await PopupNavigation.Instance.PopAsync(true);
            }
            catch (Exception)
            {
                return;
            }
         }

        public void GetUserById()
        {
            try
            {
                string url = Constant.GetInvestorByIdUrl + Settings.UserId;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("appid", Settings.AppId);
                request.AddHeader("Authorization", Settings.Token);
                IRestResponse response = client.Execute(request);
                var res = response.Content;
                Console.WriteLine(response.Content);
                //IsBusy = false;

                GetInvestor person = JsonConvert.DeserializeObject<GetInvestor>(res);
                Settings.CurrentInvestor = person;
                var currentUser = person.data[0];

                Settings.Id = currentUser.id;
                Settings.UserId = currentUser.bank;
                Settings.Lastname = currentUser.lastname;
                Settings.Firstname = currentUser.firstname;
                Settings.Email = currentUser.email;
                Settings.ReferralCode = currentUser.referralCode;
                Settings.PhoneNumber = currentUser.phoneNumber;
                Settings.ImageUrl = currentUser.imageUrl;
                Settings.Title = currentUser.title;
                Settings.AccountNumber = currentUser.accountNumber;
                Settings.AccountName = currentUser.accountName;
                Settings.State = currentUser.state;
                Settings.Address = currentUser.houseOfResidence;

            }
            catch (Exception)
            {
                return;
            }
        }
    }
}