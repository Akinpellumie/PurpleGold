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
        public static readonly BindableProperty BackBtnProperty = BindableProperty.Create(
          nameof(BackBtn),
          typeof(bool),
          typeof(BackButtonView));
        public BackButtonView()
        {
            InitializeComponent();
        }

        public void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        //public bool BackBtn
        //{
        //    get => (bool)GetValue(BackBtnProperty);
        //    set => SetValue(BackBtnProperty, value);
        //}

        private bool backBtn = false;
        public bool BackBtn
        {
            get => backBtn;
            set
            {
                backBtn = value;
                OnPropertyChanged(nameof(BackBtn));
            }

        }
    }
}