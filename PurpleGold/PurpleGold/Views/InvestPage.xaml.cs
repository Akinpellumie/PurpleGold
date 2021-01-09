using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvestPage : ContentPage
    {
        public InvestPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.FadeTo(1, 250, Easing.Linear);
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await this.FadeTo(1, 250, Easing.Linear);
        }

        public void AmountInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(((Entry)sender).Text))
                {


                    var pee = double.Parse(((Entry)sender).Text.Replace("NGN ", CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol), NumberStyles.Currency).ToString("C", CultureInfo.GetCultureInfo("en-us")).Replace("$", "N  ");
                    ((Entry)sender).Text = pee;
                    ((Entry)sender).CursorPosition = pee.Length - 3;
                    if (pee != null)
                    {

                        int TargetDefect;

                        if (int.TryParse(pee, out TargetDefect))
                        {
                            double Per = ((double)TargetDefect) * 0.2;
                            interest.Text = Per.ToString();
                        }

                    }
                    else if (tag.Text == null)
                    {
                        interest.Text = "";
                    }
                    if (string.IsNullOrEmpty(tag.Text))
                    {
                        interest.Text = "";
                    }
                }

            }
            catch (Exception)
            {
                return;
            }

        }
    }
}