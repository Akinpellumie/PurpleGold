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
                await Clipboard.SetTextAsync(acctnum.Text);
                await DisplayAlert("Yippee!","Account Number Copied","Ok");
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}