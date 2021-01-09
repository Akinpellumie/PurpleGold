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
    public partial class BackButtonView : ContentView
    {
        public BackButtonView()
        {
            InitializeComponent();
        }

        public void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}