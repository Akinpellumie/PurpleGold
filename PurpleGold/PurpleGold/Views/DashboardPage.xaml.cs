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
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        public async void WithdrawBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WithdrawPage());
        }
        
        public async void InvestBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InvestPage());
        }
        
        public async void DepositBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DepositPage());
        }
        
        public async void AssetBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssetPage());
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