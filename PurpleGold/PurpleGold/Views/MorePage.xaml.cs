using PurpleGold.PopUps;
using Rg.Plugins.Popup.Services;
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
    public partial class MorePage : ContentPage
    {
        public MorePage()
        {
            InitializeComponent();
        }

        public async void OnAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KYCPage());
            var ShowBtn = "Show Back Button";
            MessagingCenter.Send<object, string>(this, "showBtn", ShowBtn);
        }

        public async void SignOutClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new LogoutPopUp());
        }

        public async void ChangePassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePasswordPage());
        }

        public async void Privacy_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrivacyPolicyPage());
        }

        public async void CustomerSupport_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerSupportPage());
        }
    }
}