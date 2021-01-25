using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.PopUps;
using PurpleGold.Services;
using PurpleGold.ViewModels;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpTemplate : ContentView
    {
        string securityQuestion;
        string securityQuestionId;
        public SignUpTemplate()
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel();
            firstStep.Focus();
            secondStep.IsEnabled = false;
            thirdStep.IsEnabled = false;
            fourthStep.IsEnabled = false;
            fifthStep.IsEnabled = false;
            sixthStep.IsEnabled = false;
            MessagingCenter.Subscribe(this, "secQuestion", (object obj, string secQuestion) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    securityQuestion = secQuestion;
                    usrSecQue.Text = secQuestion;
                    usrSecQue.TextColor = Color.FromHex("000000");

                });

            });
            MessagingCenter.Subscribe(this, "secQuestionId", (object obj, string secQuestionId) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    securityQuestionId = secQuestionId;
                });

            });

            MessagingCenter.Subscribe<AccessService>(this, "SuccessRegister", (sender) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    FirstView.IsVisible = false;
                    SecondView.IsVisible = true;
                    ThirdView.IsVisible = false;
                    await SecondView.FadeTo(1, 250, Easing.SinInOut);
                });
            });
            
            MessagingCenter.Subscribe<AccessService>(this, "SuccessFailed", (sender) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    FirstView.IsVisible = false;
                    SecondView.IsVisible = true;
                    ThirdView.IsVisible = false;
                    await SecondView.FadeTo(1, 250, Easing.SinInOut);
                });
            });

            MessagingCenter.Subscribe(this, "error", (object obj, string msg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    FirstViewErrorMsg.IsVisible = true;
                    FirstErrorLabel.Text = msg;
                    FirstLoad.IsVisible = false;
                    FirstErrorLabel.IsVisible = true;
                    FirstView.IsVisible = true;
                    SecondView.IsVisible = false;
                    ThirdView.IsVisible = false;
                });

            });

            MessagingCenter.Subscribe(this, "FillAllFields", (object obj, string required) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    FirstViewErrorMsg.IsVisible = true;
                    FirstErrorLabel.Text = "Kindly fill input to continue!";
                });

            });

            MessagingCenter.Subscribe(this, "registerStart", (object obj, string beginRegistration) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    usrEmail.IsReadOnly = true;
                    usrRef.IsReadOnly = true;
                    usrFullname.IsReadOnly = true;
                    usrPhone.IsReadOnly = true;
                    FirstContBtnLbl.IsVisible = false;
                    FirstLoad.IsVisible = true;
                    FirstViewErrorMsg.IsVisible = false;
                });

            });
        }

        private async void FirstCont_Clicked(object sender, EventArgs e)
        {
            FirstView.IsVisible = false;
            SecondView.IsVisible = true;
            ThirdView.IsVisible = false;
            await SecondView.FadeTo(1, 250, Easing.SinInOut);
        }

        private async void SecondCont_Clicked(object sender, EventArgs e)
        {
            FirstView.IsVisible = false;
            SecondView.IsVisible = false;
            ThirdView.IsVisible = true;
            await SecondView.FadeTo(1, 250, Easing.SinInOut);
        }

        private async void BackBtn_Clicked(object sender, EventArgs e)
        {
            SecondView.IsVisible = false;
            ThirdView.IsVisible = false;
            backArr.IsVisible = false;
            FirstView.IsVisible = true;
            await ThirdView.FadeTo(1, 250, Easing.SinInOut);
        }

        #region PickerCalls
        public async void CallPickerScreen_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new SecurityQuePopUp());
        }
        #endregion

        #region otpStepper
        private void firstStep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                if (string.IsNullOrEmpty(secondStep.Text))
                {
                    secondStep.IsEnabled = true;
                    secondStep.Focus();
                }

            }
        }

        private void secondStep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                if (string.IsNullOrEmpty(thirdStep.Text))
                {
                    thirdStep.Focus();
                    thirdStep.IsEnabled = true;
                }

            }

            if (e.NewTextValue.Length == 0)
            {
                secondStep.OnBackspace += EntryBackspaceEventHandler2;

            }
        }



        private void thirdStep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                fourthStep.Focus();
                fourthStep.IsEnabled = true;


            }

            if (e.NewTextValue.Length == 0)
            {
                thirdStep.OnBackspace += EntryBackspaceEventHandler3;

            }
        }

        private void fourthStep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                fifthStep.Focus();
                fifthStep.IsEnabled = true;


            }

            if (e.NewTextValue.Length == 0)
            {
                fourthStep.OnBackspace += EntryBackspaceEventHandler4;

            }
        }
        
        private void fifthStep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                sixthStep.Focus();
                sixthStep.IsEnabled = true;


            }

            if (e.NewTextValue.Length == 0)
            {
                fourthStep.OnBackspace += EntryBackspaceEventHandler5;

            }
        }
        
        private void sixthStep_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (e.NewTextValue.Length == 0)
            {
                sixthStep.OnBackspace += EntryBackspaceEventHandler6;
                //fifthStep.Focus();

            }
        }

        public void EntryBackspaceEventHandler2(object sender, EventArgs e)
        {
            firstStep.Focus();
            firstStep.Text = string.Empty;
        }

        public void EntryBackspaceEventHandler3(object sender, EventArgs e)
        {
            secondStep.Focus();
            secondStep.Text = string.Empty;
        }

        public void EntryBackspaceEventHandler4(object sender, EventArgs e)
        {
            thirdStep.Focus();
            thirdStep.Text = string.Empty;
        }
        public void EntryBackspaceEventHandler5(object sender, EventArgs e)
        {
            fourthStep.Focus();
            fourthStep.Text = string.Empty;
        }
        
        public void EntryBackspaceEventHandler6(object sender, EventArgs e)
        {
            fifthStep.Focus();
            fifthStep.Text = string.Empty;
        }
        #endregion

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

        private void usrRef_TextChanged(object sender, TextChangedEventArgs e)
        {
            FirstViewErrorMsg.IsVisible = false;
        }

        private void usrPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            FirstViewErrorMsg.IsVisible = false;
            //if (!string.IsNullOrEmpty(((Entry)sender).Text))
            //{
            //    try
            //    {
            //        //var t = int.Parse(((Entry)sender).Text.Replace("+234", CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol), 
            //        //    NumberStyles.Currency).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "+234");
            //        var t = "+234" + ((Entry)sender).Text;
            //        ((Entry)sender).Text = t;
            //        //((Entry)sender).CursorPosition = t.Length - 3;

            //    }
            //    catch (Exception)
            //    {
            //        return;
            //    }
            //}

        }

        private void usrEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            FirstViewErrorMsg.IsVisible = false;
        }

        private void usrFullname_TextChanged(object sender, TextChangedEventArgs e)
        {
            FirstViewErrorMsg.IsVisible = false;
        }

        public async void VerifyOtpClicked(object sender, EventArgs e)
        {
            try
            {
                secondViewErrorMsg.IsVisible = false;
                ScndContBtnLbl.IsVisible = false;
                SecondLoad.IsVisible = true;
                firstStep.IsReadOnly = true;
                secondStep.IsReadOnly = true;
                thirdStep.IsReadOnly = true;
                fourthStep.IsReadOnly = true;
                fifthStep.IsReadOnly = true;
                sixthStep.IsReadOnly = true;
                OTP UserOtp = new OTP()
                {
                    userId = Settings.UserId
                };
                var newOtp = firstStep.Text + secondStep.Text + thirdStep.Text + fourthStep.Text + fifthStep.Text + sixthStep.Text;
                UserOtp.otp = newOtp;

                string url = Constant.VerifyOtpUrl;

                var json = JsonConvert.SerializeObject(UserOtp);
                HttpContent result = new StringContent(json);

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("appId", Settings.AppId);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                var res = response.Content;

                OTPResponse otpRes = JsonConvert.DeserializeObject<OTPResponse>(res);
                var msg = otpRes.message;

                if (response.IsSuccessful)
                    {
                        FirstView.IsVisible = false;
                        SecondView.IsVisible = false;
                        ThirdView.IsVisible = true;
                     
                    }
                else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest && msg.Contains("Invalid Otp"))
                {
                    secondViewErrorMsg.IsVisible = true;
                    secondErrorLabel.Text = "Invalid OTP. please click resend OTP to try again!";
                    SecondLoad.IsVisible = false;
                    ScndContBtnLbl.IsVisible = true;
                }
                else
                {
                    secondViewErrorMsg.IsVisible = true;
                    secondErrorLabel.Text = "Network Error! please click resend OTP to try again!";
                    SecondLoad.IsVisible = false;
                    ScndContBtnLbl.IsVisible = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        
        public async void VerifyUserSecurityClicked(object sender, EventArgs e)
        {
            try
            {
                thirdViewErrorMsg.IsVisible = false;
                usrPass.IsReadOnly = true;
                usrVerPass.IsReadOnly = true;
                usrSecQue.IsEnabled = false;
                usrAns.IsReadOnly = true;
                ThirdContBtnLbl.IsVisible = false;
                ThirdLoad.IsVisible = true;
                VerifyUserSecurity verifyUser = new VerifyUserSecurity()
                {
                    securityQuestionAnswer = usrAns.Text,
                    securityQuestionId = securityQuestionId,
                    password = usrPass.Text,
                    id = Settings.UserId
                };

                //var client = new HttpClient();
                var json = JsonConvert.SerializeObject(verifyUser);
                HttpContent result = new StringContent(json);

                var client = new RestClient(Constant.ConfirmRegUrl);
                client.Timeout = -1;
                var request = new RestRequest(Method.PUT);
                request.AddHeader("appId", Settings.AppId);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                var res = response.Content;

                Person personProfile = JsonConvert.DeserializeObject<Person>(res);
                var msg = personProfile.message;

                if (response.IsSuccessful)
                {
                    var bal = personProfile.personData.wallet[0].balance;
                    Settings.balance = bal;
                    MessagingCenter.Send<object, string>(this, "balance", bal);

                    //GetUserBalance();
                    Settings.PersonProfile = personProfile;

                    MessagingCenter.Send(this, "SuccessLogin");

                    Settings.Token = personProfile.personData.token;
                    Settings.Id = personProfile.personData.id;
                    Settings.UserId = personProfile.personData.id;
                    Settings.Lastname = personProfile.personData.lastname;
                    Settings.Firstname = personProfile.personData.firstname;
                    Settings.Email = personProfile.personData.email;
                    Settings.ReferralCode = personProfile.personData.referralCode;
                    Settings.PhoneNumber = personProfile.personData.phoneNumber;
                    Settings.ImageUrl = personProfile.personData.imageUrl;
                    Settings.Title = personProfile.personData.title;
                    Settings.BankName = personProfile.personData.bank;
                    Settings.AccountNumber = personProfile.personData.accountNumber;
                    Settings.AccountName = personProfile.personData.accountName;
                    Settings.State = personProfile.personData.state;
                    Settings.Address = personProfile.personData.houseOfResidence;

                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync("//main");
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    thirdViewErrorMsg.IsVisible = true;
                    thirdErrorLabel.IsVisible = true;
                    thirdErrorLabel.Text = "Network Error! Please Try again later";
                    ThirdLoad.IsVisible = false;
                    ThirdContBtnLbl.IsVisible = true;
                    backArr.IsVisible = true;
                }
                else
                {
                    thirdViewErrorMsg.IsVisible = true;
                    thirdErrorLabel.IsVisible = true;
                    thirdErrorLabel.Text = "Server Unavailable! Please Try again later!!!";
                    ThirdLoad.IsVisible = false;
                    ThirdContBtnLbl.IsVisible = true;
                    backArr.IsVisible = true;
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        public async void ResendOtpClicked(object sender, EventArgs e)
        {
            try
            {
                resend.IsVisible = false;
                resendOtp.IsVisible = true;
                ResendOTP UserOtp = new ResendOTP()
                {
                    userId = Settings.UserId,
                    email = usrEmail.Text
                };
                var client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("appId", Settings.AppId);

                var json = JsonConvert.SerializeObject(UserOtp);
                HttpContent result = new StringContent(json);
                result.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(Constant.ResendOtpUrl, result);

                if (response.IsSuccessStatusCode)
                {
                    resend.IsVisible = true;
                    resendOtp.IsVisible = false;
                    OTPResponse otpRes = JsonConvert.DeserializeObject<OTPResponse>(result.ReadAsStringAsync().Result);
                    var msg = otpRes.message;
                    //RegisterInvestor newUser = JsonConvert.DeserializeObject<RegisterInvestor>(result.Content.ReadAsStringAsync().Result);
                    //var msg = newUser.message;
                    //Settings.UserId = newUser.createUserData.id;
                    //AppShell fpm = new AppShell();
                    //Application.Current.MainPage = fpm;
                }
                else
                {
                    secondViewErrorMsg.IsVisible = true;
                    secondErrorLabel.Text = "Error sending OTP. please click resend OTP to try again!";
                    SecondLoad.IsVisible = false;
                    ScndContBtnLbl.IsVisible = true;
                }
            }
            catch (Exception)
            {
                return;

            }
        }
    }
}