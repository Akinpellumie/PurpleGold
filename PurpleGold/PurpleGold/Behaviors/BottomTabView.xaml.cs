using PurpleGold.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Behaviors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomTabView : ContentView
    {
        public BottomTabView()
        {
            InitializeComponent();
        }

        #region home click
        public async void Home_Clicked (object sender, EventArgs e)
        {
            HomeTitle.TextColor = Color.FromHex("6F34BF");
            HomeIcon.Source = "homeActive.svg";
            HomeCircle.IsVisible = true;

            InvestCircle.IsVisible = false;
            InvestIcon.Source = "investInactive.svg";
            InvestTitle.TextColor = Color.FromHex("939393");

            DepositCircle.IsVisible = false;
            DepositIcon.Source = "depositInactive.svg";
            DepositTitle.TextColor = Color.FromHex("939393");

            AssetCircle.IsVisible = false;
            AssetIcon.Source = "assetInactive.svg";
            AssetTitle.TextColor = Color.FromHex("939393");

            ProfileCircle.IsVisible = false;
            ProfileTitle.TextColor = Color.FromHex("939393");

            await Home.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await Home.ScaleTo(1, 50, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new DashboardPage());

        }
        #endregion
        
        #region invest click
        public async void Invest_Clicked (object sender, EventArgs e)
        {
            InvestTitle.TextColor = Color.FromHex("6F34BF");
            InvestIcon.Source = "investActive.svg";
            InvestCircle.IsVisible = true;

            HomeCircle.IsVisible = false;
            HomeIcon.Source = "homeInactive.svg";
            HomeTitle.TextColor = Color.FromHex("939393");

            DepositCircle.IsVisible = false;
            DepositIcon.Source = "depositInactive.svg";
            DepositTitle.TextColor = Color.FromHex("939393");

            AssetCircle.IsVisible = false;
            AssetIcon.Source = "assetInactive.svg";
            AssetTitle.TextColor = Color.FromHex("939393");

            ProfileCircle.IsVisible = false;
            ProfileTitle.TextColor = Color.FromHex("939393");

            await Invest.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await Invest.ScaleTo(1, 50, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new InvestPage());

        }
        #endregion
        
        #region deposit click
        public async void Deposit_Clicked (object sender, EventArgs e)
        {
            DepositTitle.TextColor = Color.FromHex("6F34BF");
            DepositIcon.Source = "depositActive.svg";
            DepositCircle.IsVisible = true;

            HomeCircle.IsVisible = false;
            HomeIcon.Source = "homeInactive.svg";
            HomeTitle.TextColor = Color.FromHex("939393");

            InvestCircle.IsVisible = false;
            InvestIcon.Source = "investInactive.svg";
            InvestTitle.TextColor = Color.FromHex("939393");

            AssetCircle.IsVisible = false;
            AssetIcon.Source = "assetInactive.svg";
            AssetTitle.TextColor = Color.FromHex("939393");

            ProfileCircle.IsVisible = false;
            ProfileTitle.TextColor = Color.FromHex("939393");

            await Deposit.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await Deposit.ScaleTo(1, 50, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new DepositPage());

        }
        #endregion
        
        #region asset click
        public async void Asset_Clicked (object sender, EventArgs e)
        {
            AssetTitle.TextColor = Color.FromHex("6F34BF");
            AssetIcon.Source = "assetActive.svg";
            AssetCircle.IsVisible = true;

            HomeCircle.IsVisible = false;
            HomeIcon.Source = "homeInactive.svg";
            HomeTitle.TextColor = Color.FromHex("939393");

            InvestCircle.IsVisible = false;
            InvestIcon.Source = "investInactive.svg";
            InvestTitle.TextColor = Color.FromHex("939393");

            DepositCircle.IsVisible = false;
            DepositIcon.Source = "depositInactive.svg";
            DepositTitle.TextColor = Color.FromHex("939393");

            ProfileCircle.IsVisible = false;
            ProfileTitle.TextColor = Color.FromHex("939393");

            await Asset.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await Asset.ScaleTo(1, 50, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new AssetPage());

        }
        #endregion
        
        #region account click
        public async void Account_Clicked (object sender, EventArgs e)
        {
            ProfileTitle.TextColor = Color.FromHex("6F34BF");
            ProfileCircle.IsVisible = true;

            HomeCircle.IsVisible = false;
            HomeIcon.Source = "homeInactive.svg";
            HomeTitle.TextColor = Color.FromHex("939393");

            InvestCircle.IsVisible = false;
            InvestIcon.Source = "investInactive.svg";
            InvestTitle.TextColor = Color.FromHex("939393");

            DepositCircle.IsVisible = false;
            DepositIcon.Source = "depositInactive.svg";
            DepositTitle.TextColor = Color.FromHex("939393");

            AssetCircle.IsVisible = false;
            AssetTitle.TextColor = Color.FromHex("939393");
            AssetIcon.Source = "assetInactive.svg";

            await Account.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await Account.ScaleTo(1, 50, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new KYCPage());

        }
        #endregion
    }
}