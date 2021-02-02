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
    public partial class CustomerSupportPage : ContentPage
    {
        public CustomerSupportPage()
        {
            InitializeComponent();
        }

        public void PlacePhoneCall(object sender, EventArgs e)
        {
            try
            {
                string number = phone.Text;

                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
                return;
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
                return;
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                return;
            }
        }

        public async void SendEmail(object sender, EventArgs e)
        {
            try
            {
                await Email.ComposeAsync("","",email.Text);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
                return;
            }
            catch (Exception ex)
            {
                // Some other exception occurred
                return;
            }
        }
    }
}