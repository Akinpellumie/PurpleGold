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
        AssetViewModel assetViewModel;
        public HistoryViewTemplate()
        {
            assetViewModel = new AssetViewModel(Navigation);
            InitializeComponent();
            BindingContext = assetViewModel;
        }
    }
}