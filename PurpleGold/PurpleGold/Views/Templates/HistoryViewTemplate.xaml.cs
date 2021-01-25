using PurpleGold.ViewModels;
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
    public partial class HistoryViewTemplate : ContentView
    {
        //AssetViewModel assetViewModel;
        InvestViewModel investViewModel;
        public HistoryViewTemplate()
        {
            //assetViewModel = new AssetViewModel(Navigation);
            investViewModel = new InvestViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = investViewModel;
        }
    }
}