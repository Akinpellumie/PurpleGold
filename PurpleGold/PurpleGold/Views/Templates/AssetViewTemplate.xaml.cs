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
    public partial class AssetViewTemplate : ContentView
    {
        AssetViewModel assetViewModel;
        public static readonly BindableProperty FormatAmountProperty = BindableProperty.Create(
           nameof(FormatAmount),
           typeof(string),
           typeof(AssetViewTemplate),
           string.Empty);
        public AssetViewTemplate()
        {
            assetViewModel = new AssetViewModel(Navigation);
            InitializeComponent();
            BindingContext = assetViewModel;
        }

        public string FormatAmount
        {
            get => (string)GetValue(FormatAmountProperty);
            set => SetValue(FormatAmountProperty, value);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //htmlLabel.Text = "<span  style='color: green'><small>N52,</small></span><span style='color:green'><big>O3O.</big></span><span style='color:red'><small>60</small></span>";
        }
    }
}