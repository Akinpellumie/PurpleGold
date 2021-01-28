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
    public partial class SuccessPopUp
    {
        public SuccessPopUp()
        {
            InitializeComponent();
            MessagingCenter.Subscribe(this, "done", (object obj, string successMsg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    successLbl.Text = successMsg;
                });

            });
        }

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}