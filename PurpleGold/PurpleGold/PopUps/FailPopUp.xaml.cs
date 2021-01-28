﻿using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FailPopUp
    {
        public FailPopUp()
        {
            InitializeComponent();
            MessagingCenter.Subscribe(this, "error", (object obj, string msg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    failLbl.Text = msg;
                });

            });
        }

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}