using PurpleGold.PopUps;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepositPage : ContentPage
    {
        string successMsg;
        public DepositPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe(this, "showBtn", (object obj, string ShowBtn) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    backBtn.BackBtn = true;
                });

            });
        }

        public async void CopyClicked(object sender, EventArgs e)
        {
            try
            {
                successMsg = "Account Number Copied";
                await Clipboard.SetTextAsync(acctnum.Text);
                MessagingCenter.Send<object, string>(this, "done", successMsg);
                await PopupNavigation.Instance.PushAsync(new DepositPopUp());
            }
            catch (Exception)
            {
                return;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync("//main");
                //if (result) await this.Navigation.PopAsync(); // or anything else
            });

            return true;
        }
    }
}