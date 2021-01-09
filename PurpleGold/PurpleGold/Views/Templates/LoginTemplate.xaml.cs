using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginTemplate : ContentView
    {
        public LoginTemplate()
        {
            InitializeComponent();
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            await this.FadeTo(1, 250, Easing.SinInOut);
            await Navigation.PushAsync(new DashboardPage());
        }
    }
}