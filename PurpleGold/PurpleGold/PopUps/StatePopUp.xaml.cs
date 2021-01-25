using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.ViewModels;
using Rg.Plugins.Popup.Services;
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
    public partial class StatePopUp
    {

        StateViewModel stateViewModel;
        public StatePopUp()
        {
            stateViewModel = new StateViewModel();
            InitializeComponent();
            this.BindingContext = stateViewModel;
        }

        private string stateCode;
        public string StateCode
        {
            get => stateCode;
            set
            {
                stateCode = value;
                OnPropertyChanged(nameof(StateCode));
            }
        }
        private string stateName;
        public string StateName
        {
            get => stateName;
            set
            {
                stateName = value;
                OnPropertyChanged(nameof(StateName));
            }
        }

        public async void SelectedState_Tapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            var selectedState = e.Item as State;
            StateName = selectedState.StateName;
            //BankCode = selectedBank.BankCode;
            MessagingCenter.Send<object, string>(this, "stateName", StateName);
            //MessagingCenter.Send<object, string>(this, "bankCode", BankCode);
            await PopupNavigation.Instance.PopAsync(true);
        }

        public async void ClosePop_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                list.ItemsSource = stateViewModel.StateList;
            }

            else
            {
                //list.ItemsSource = bankViewModel.BankData.Where(x => x.Name.StartsWith(e.NewTextValue));
                list.ItemsSource = stateViewModel.StateList.Where(x => x.StateName.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase));
            }
        }

    }
}