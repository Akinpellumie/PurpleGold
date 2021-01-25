using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PurpleGold.Services
{
    public class InvestService
    {
        bool Response;

        public async Task<bool> CreateInvestment(CreateInvestment investData)
        {
            Response = true;
            try
            {
                await Task.Run(async () =>
                {
                    String url = Constant.InvestUrl;


                    var json = JsonConvert.SerializeObject(investData);

                    var client = new RestClient(url);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("appId", Settings.AppId);
                    request.AddHeader("Authorization", Settings.Token);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("application/json", json , ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    var res = response.Content;
                    if (response.IsSuccessful)
                    {
                        Response = true;
                        MessagingCenter.Send(this, "Investment CreatedLogin");
                        //Person personProfile = JsonConvert.DeserializeObject<Person>(result.Content.ReadAsStringAsync().Result);
                        //var msg = personProfile.message;
                    }
                    else
                    {
                        MessagingCenter.Send(this, "InvestFailed");
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
    }
}
