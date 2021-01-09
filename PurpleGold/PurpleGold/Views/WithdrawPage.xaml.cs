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
    public partial class WithdrawPage : ContentPage
    {
        public WithdrawPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.FadeTo(1, 300, Easing.Linear);
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await this.FadeTo(1, 300, Easing.Linear);
        }
    }
}