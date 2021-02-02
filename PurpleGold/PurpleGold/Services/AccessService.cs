using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PurpleGold.Services
{
    public class AccessService
    {
        bool Response;
        string myId;

        public async Task<bool> RegisterUser(CreateUser registerData)
        {
            Response = false;
            try
            {
                await Task.Run(async () =>
                {
                    string url = Constant.SignUpUrl;


                    var json = JsonConvert.SerializeObject(registerData);

                    var client = new RestClient(url);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("appId", Settings.AppId);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("application/json", json, ParameterType.RequestBody);
                    IRestResponse response = await client.ExecuteAsync(request);
                    Console.WriteLine(response.Content);
                    var res = response.Content;

                    RegisterInvestor newUser = JsonConvert.DeserializeObject<RegisterInvestor>(res);
                    var msg = newUser.message;
                    var stat = newUser.status;
                    var vex = newUser.createUserData.id;

                    if (response.IsSuccessful)
                    {

                        MessagingCenter.Send(this, "SuccessRegister");
                        Response = true;
                        Settings.UserId = newUser.createUserData.id;
                        Settings.UserCreated = true;
                        //AppShell fpm = new AppShell();
                        //Application.Current.MainPage = fpm;
                    }
                   else if(stat.Contains("400"))
                    {
                        MessagingCenter.Send<object, string>(this, "error", msg);
                        Response = false;
                    }
                    else
                    {
                        MessagingCenter.Send<object, string>(this, "error", msg);
                        return;
                    }
                });
                return Response;
            }
            catch (Exception)
            {
                var msgg = "Server error!!! Please try again later.";
                MessagingCenter.Send<object, string>(this, "errorrr", msgg);
                return false;
            }

        }


        public async Task<bool> LoginUser(LoginUser userData)
        {
            Response = true;
            try
            {
                await Task.Run(async () =>
                {
                    String url = Constant.LoginUrl;
                    

                    var json = JsonConvert.SerializeObject(userData);
                    HttpContent contents = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("appId", Settings.AppId);
                    
                    var response = client.PostAsync(url, contents);
                    var result = response.GetAwaiter().GetResult();
                    var resContent = result.Content.ReadAsStringAsync();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        Response = true;

                        Person personProfile = JsonConvert.DeserializeObject<Person>(result.Content.ReadAsStringAsync().Result);
                        var msg = personProfile.message;
                        myId = personProfile.personData.id;
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


                        
                        
                    }
                    else
                    {
                        MessagingCenter.Send(this, "LoginFailed");
                        await PopupNavigation.Instance.PopAsync(true);
                    }
                });
                return Response;
            }
            catch (Exception)
            {
                return false;
            }

        }


        //async void GetUserBalance()
        //{
        //    try
        //    {
        //        //await SecureStorage.SetAsync("Token", personProfile.personData.Token);
        //        HttpClient client = new HttpClient();
        //        var getWallUrl = Constant.GetWalletUrl + myId;

        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Add("Authorization", Settings.Token);
        //        client.DefaultRequestHeaders.Add("appId", Settings.AppId);

        //        var response = client.GetAsync(getWallUrl);
        //        var result = response.GetAwaiter().GetResult();
        //        var resContent = result.Content.ReadAsStringAsync();

        //        if (response.Result.IsSuccessStatusCode)
        //        {
        //            Wallet bal = JsonConvert.DeserializeObject<Wallet>(result.Content.ReadAsStringAsync().Result);
        //            var msg = bal.message;
        //            var sorted = bal.wallets[0].balance;
        //            MessagingCenter.Send<object, string>(this, "balance", sorted);
        //            //getTrans = userTransactions
        //            //var questions = new ObservableCollection<SecurityQuestion>(sorted);
        //            //QuestionModelList = questions;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // Possible that device doesn't support secure storage on device.
        //    }
        //}
    }
}
