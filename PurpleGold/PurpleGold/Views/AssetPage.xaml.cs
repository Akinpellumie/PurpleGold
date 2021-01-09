using PurpleGold.Helpers;
using PurpleGold.Models;
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
    public partial class AssetPage : ContentPage
    {
        public AssetPage()
        {
            InitializeComponent();
            string mee = Constant.FormatAmount;
            string nee = mee.Split(new char[] { ',','.'}).First();
            Font.SystemFontOfSize(20);
            //nee = Font.FontSize(20);


            //    string entry = assetView.FormatAmount;
            //List<string> arrayfromEntry = new List<string>();
            //if (entry.Contains(",") && entry.Contains(".") == true)
            //{
            //    arrayfromEntry = entry.Split(new char[] { ',' }).ToList();
            //    arrayfromEntry = entry.Split(new char[] { '.' }).ToList();
            //}
            //else
            //{
            //    arrayfromEntry = entry.Split(new char[] { ',' }).ToList();
            //}
            //for (int i = 0; i < arrayfromEntry.Count(); i++)
            //{
            //    arrayfromEntry[i] = '"' + arrayfromEntry[i] + '"';
            //}
            //string f = (string.Join(", ", arrayfromEntry));
            //f = f.Remove(f.Count() - 2, 2);
            //f = f + '"';
            //assetView.FormatAmount = f;
        }

        private async void AssetStack_Tapped(object sender, EventArgs e)
        {
            //LogActive.IsVisible = true;
            activeTxt.TextColor = Color.FromHex("FFFFFF");
            active.BackgroundColor = Color.FromHex("9E079E");
            history.BackgroundColor = Color.FromHex("FFFFFF");
            histTxt.TextColor = Color.FromHex("939393");
            //active.IsVisible = false;
            //await active.TranslateTo(+90, 0, 0, Easing.BounceIn);
            assetStack.IsVisible = true;
            historyStack.IsVisible = false;
            await assetStack.ScrollToAsync(histView, ScrollToPosition.End, true);
            await assetStack.ScaleYTo(1, 600, Easing.Linear);
        }

        private async void HistoryStack_Tapped(object sender, EventArgs e)
        {
            //LogActive.IsVisible = false;
            histTxt.TextColor = Color.FromHex("FFFFFF");
            history.BackgroundColor = Color.FromHex("9E079E");
            active.BackgroundColor = Color.FromHex("FFFFFF");
            activeTxt.TextColor = Color.FromHex("939393");
            //active.IsVisible = true;
           // await history.TranslateTo(-90, 0, 0, Easing.BounceIn);
            historyStack.IsVisible = true;
            assetStack.IsVisible = false;
            await historyStack.ScrollToAsync(histView, ScrollToPosition.Start, true);
            await historyStack.ScaleYTo(1, 600, Easing.Linear);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //assetView.FormatAmount =  "<span  style='color: green'><small>N52,</small></span><span style='color:green'><big>O3O.</big></span><span style='color:red'><small>60</small></span>";
            await this.FadeTo(1, 550, Easing.SinInOut);
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await this.FadeTo(1, 550, Easing.SinInOut);
        }
    }
}