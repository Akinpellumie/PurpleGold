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
    public partial class KYCPage : ContentPage
    {
        public KYCPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.FadeTo(1, 250, Easing.SinInOut);
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await this.FadeTo(1, 250, Easing.SinInOut);
        }
    }
}