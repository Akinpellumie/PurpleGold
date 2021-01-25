using PurpleGold;
using PurpleGold.Helpers;
using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FAQPage : ContentPage
    {
        public FAQPage()
        {
            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            InitializeComponent();
            var faqWeb = Constant.FaqUrl;
            FaqView.Source = faqWeb;
        }

        private void FaqView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Indic.IsVisible = true;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Indic.ProgressTo(0.9, 900, Easing.SpringIn);
        }

        private void FaqView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Indic.IsVisible = false;
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return false;
        }

    }
}