﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomNavTemplate : ContentView
    {
        public BottomNavTemplate()
        {
            InitializeComponent();
        }

        private async void ProfileStack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KYCPage());
        }
    }
}