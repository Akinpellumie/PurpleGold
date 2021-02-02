using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace PurpleGold.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExitAppPopUp
    {
        public ExitAppPopUp()
        {
            InitializeComponent();
        }

        public async void ExitAppClicked(object sender, EventArgs e)
        {
            try
            {
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
                await PopupNavigation.Instance.PopAsync(true);
                if (Device.RuntimePlatform == Device.Android)
                {
                    //Application.Current.Quit();
                    Process.GetCurrentProcess().CloseMainWindow();
                    Process.GetCurrentProcess().Close();
                }
                else if (Device.RuntimePlatform == Device.iOS)
                {
                    await PopupNavigation.Instance.PopAsync(true);
                    return;
                }

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