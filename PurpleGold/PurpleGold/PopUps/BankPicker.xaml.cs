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
    public partial class BankPicker
    {
        
        BankViewModel bankViewModel;
        public BankPicker()
        {
            bankViewModel = new BankViewModel();
            InitializeComponent();
            this.BindingContext = bankViewModel;
        }

        private string bankCode;
        public string BankCode
        {
            get => bankCode;
            set
            {
                bankCode = value;
                OnPropertyChanged(nameof(BankCode));
            }
        }
        private string bankName;
        public string BankName
        {
            get => bankName;
            set
            {
                bankName = value;
                OnPropertyChanged(nameof(BankName));
            }
        }

        public async void SelectedBank_Tapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            var selectedBank = e.Item as DummyBank;
            BankName = selectedBank.BankName;
            BankCode = selectedBank.BankCode;
            MessagingCenter.Send<object, string>(this, "bankName", BankName);
            MessagingCenter.Send<object, string>(this, "bankCode", BankCode);
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
                list.ItemsSource = bankViewModel.BankData;
            }

            else
            {
                //list.ItemsSource = bankViewModel.BankData.Where(x => x.Name.StartsWith(e.NewTextValue));
                list.ItemsSource = bankViewModel.BankData.Where(x => x.BankName.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}