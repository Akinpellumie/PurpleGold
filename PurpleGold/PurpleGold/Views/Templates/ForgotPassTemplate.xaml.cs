using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassTemplate : ContentView
    {
        public ForgotPassTemplate()
        {
            InitializeComponent();
        }

        protected async override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            await this.FadeTo(1, 250, Easing.SinInOut);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SecurFrame.IsVisible = false;
            forgSec.IsVisible = true;
            remQue.IsVisible = false;
        }

        public async void ForgotPasswordClicked(object sender, EventArgs e)
        {
            try
            {
                usrEmail.IsReadOnly = true;
                answer.IsReadOnly = true;
                BtnLbl.IsVisible = false;
                load.IsVisible = true;
                ResetPassword reset = new ResetPassword()
                {
                    email = usrEmail.Text.Trim(),
                    securityQuestionAnswer = answer.Text.Trim()
                };
                string url = Constant.ForgotUrl;

                var json = JsonConvert.SerializeObject(reset);

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("appId", Settings.AppId);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                var res = response.Content;

                RootResetPass rootReset = JsonConvert.DeserializeObject<RootResetPass>(res);
                var msg = rootReset.message;

                if (response.IsSuccessful)
                {
                    BtnLbl.IsVisible = true;
                    load.IsVisible = false;
                    forgotPassView.IsVisible = false;
                    successView.IsVisible = true;
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    errorMsg.IsVisible = true;
                    errLbl.Text = msg;
                    usrEmail.IsReadOnly = false;
                    answer.IsReadOnly = false;
                    BtnLbl.IsVisible = true;
                    load.IsVisible = false;
                }
                else
                {
                    BtnLbl.IsVisible = true;
                    load.IsVisible = false;
                    usrEmail.IsReadOnly = false;
                    answer.IsReadOnly = false;
                    errorMsg.IsVisible = true;
                    errLbl.Text = msg;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            forgotPassView.IsVisible = true;
            successView.IsVisible = false;
            SecurFrame.IsVisible = true;
            forgSec.IsVisible = true;
            remQue.IsVisible = true;
        }
    }
}