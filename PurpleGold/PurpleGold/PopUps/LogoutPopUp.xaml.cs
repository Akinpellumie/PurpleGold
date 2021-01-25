using PurpleGold.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogoutPopUp
    {
        public LogoutPopUp()
        {
            InitializeComponent();
        }

        public async void SignOutClicked(object sender, EventArgs e)
        {
            try
            {
                    Application.Current.MainPage = new NavigationPage(new LoginSignUpPage());
                await PopupNavigation.Instance.PopAsync(true);
                Settings.Token = "";
                    Settings.InvestmentList = null;
                    Settings.Id = "";
                    Settings.UserId = "";
                    Settings.Lastname = "";
                    Settings.Firstname = "";
                    Settings.Email = "";
                    Settings.ReferralCode = "";
                    Settings.PhoneNumber = "";
                    Settings.ImageUrl = "";
                    Settings.Title = "";
                    Settings.BankName = "";
                    Settings.AccountNumber = "";
                    Settings.AccountName = "";
                    Settings.State = "";
                    Settings.Address = "";

            }
            catch (Exception)
            {
                return;
            }
        }

        public async void CancelClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}