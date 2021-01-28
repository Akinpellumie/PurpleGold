using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FingerPrintPopUp
    {
        public FingerPrintPopUp()
        {
            InitializeComponent();
            MessagingCenter.Subscribe(this, "authF", (object obj, string authFail) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    result.Text = authFail;
                    img.Source = "fingerFail.svg";
                    //try
                    //{
                    //    // Use default vibration length
                    //    //Vibration.Vibrate();

                    //    // Or use specified time
                    //    var duration = TimeSpan.FromSeconds(2);
                    //    Vibration.Vibrate(duration);
                    //}
                    //catch (FeatureNotSupportedException ex)
                    //{
                    //    // Feature not supported on device
                    //    return;
                    //}
                    //catch (Exception ex)
                    //{
                    //    // Other error has occurred.
                    //    return;
                    //}
                });

            });
            
            MessagingCenter.Subscribe(this, "authS", (object obj, string authSuccess) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    result.Text = authSuccess;
                    img.Source = "fingerSuccess.svg";
                });

            });
        }

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}