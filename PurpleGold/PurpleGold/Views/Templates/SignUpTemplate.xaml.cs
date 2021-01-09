using PurpleGold.PopUps;
using Rg.Plugins.Popup.Services;
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
    public partial class SignUpTemplate : ContentView
    {
        string securityQuestion;
        public SignUpTemplate()
        {
            InitializeComponent();
            MessagingCenter.Subscribe(this, "secQuestion", (object obj, string secQuestion) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    securityQuestion = secQuestion;
                    usrSecQue.Text = secQuestion;
                    usrSecQue.TextColor = Color.FromHex("000000");

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

        private async void CompleteBtn_Clicked(object sender, EventArgs e)
        {
            await this.FadeTo(1, 250, Easing.SinInOut);
            await Navigation.PushAsync(new DashboardPage());
        }

        #region PickerCalls
        public async void CallPickerScreen_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new SecurityQuePopUp());
        }
        #endregion
    }
}