using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.ViewModel;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class BankViewModel : BaseViewModel
    {
        #region Properties
        private bool isBusy { get; set; }
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));

            }
        }
        public Command SearchCommand { get; }
        public Command ClosePopCommand { get; }
        public Command SelectedCommand { get; }
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
        
        private string selectedBank;
        public string SelectedBank
        {
            get => selectedBank;
            set
            {
                bankName = value;
                OnPropertyChanged(nameof(SelectedBank));

            }
        }

        private string selectedBankCode;
        public string SelectedBankCode
        {
            get => selectedBankCode;
            set
            {
                selectedBankCode = value;
                OnPropertyChanged(nameof(SelectedBankCode));

            }
        }

        private ObservableCollection<DummyBank> searchData;
        public ObservableCollection<DummyBank> SearchData
        {
            get => searchData;
            set
            {
                searchData = value;
                OnPropertyChanged(nameof(SearchData));

            }
        }
        private ObservableCollection<DummyBank> bankData;
        public ObservableCollection<DummyBank> BankData
        {
            get => bankData;
            set
            {
                IsBusy = true;
                bankData = value;
                OnPropertyChanged(nameof(BankData));
                IsBusy = false;
            }
        }
      
        #endregion


        #region Constructors
        public BankViewModel()
        {
            //LoadBanks();
            GetDummyBanks();
            SearchCommand = new Command<TextChangedEventArgs>(textChanged => SearchBar_TextChanged(textChanged));
            ClosePopCommand = new Command(async () => await ClosePop_Clicked());
            SelectedCommand = new Command<DummyBank>(async (model) => await ExecutePickerCommand(model));
            //BankName = Settings.BankName;
            //BankCode = Settings.BankCode;
        }
        #endregion

        #region Functions
        //private async void LoadBanks()
        //{
        //    IsBusy = true;
        //    HttpClient client = new HttpClient();
        //    var url = Constant.GetBanksUrl;
        //    var response = await client.GetAsync(url);

        //    var json = await response.Content.ReadAsStringAsync();

        //    Bank banks = JsonConvert.DeserializeObject<Bank>(json);
        //    var sorted = banks.Dummies;
        //    //getTrans = userTransactions
        //    var bankList = new ObservableCollection<DummyBank>(sorted);
        //    BankData = bankList;
        //    IsBusy = false;


        //}

        public void GetDummyBanks()
        {
            bankData = new ObservableCollection<DummyBank>();
            bankData.Add(new DummyBank { BankName = "First Bank Plc", BankCode="023" });
            bankData.Add(new DummyBank { BankName = "Access Bank Plc", BankCode="024" });
            bankData.Add(new DummyBank { BankName = "GT Bank Plc", BankCode="025" });
            bankData.Add(new DummyBank { BankName = "EcoBank Plc", BankCode="026" });
            bankData.Add(new DummyBank { BankName = "Sterling Bank Plc", BankCode="027" });
            bankData.Add(new DummyBank { BankName = "Stanbic IBTC Bank", BankCode="028" });
            bankData.Add(new DummyBank { BankName = "AstraPolaris Bank Plc", BankCode="029" });
            bankData.Add(new DummyBank { BankName = "MTN Y'ello Bank", BankCode="034" });
            bankData.Add(new DummyBank { BankName = "Layi MFB Plc", BankCode="039" });
            bankData.Add(new DummyBank { BankName = "Keystone Bank Plc", BankCode="036" });
            bankData.Add(new DummyBank { BankName = "Heritage Bank Plc", BankCode="037" });
            bankData.Add(new DummyBank { BankName = "Zenith Bank Plc", BankCode="047" });
            bankData.Add(new DummyBank { BankName = "Wema Bank Plc", BankCode="017" });
            BankData = bankData;

        }
        #endregion

        #region Commands

        public async Task ClosePop_Clicked()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        private void SearchBar_TextChanged(TextChangedEventArgs textChanged)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(textChanged.NewTextValue))
            {
                SearchData = BankData;
            }

            else
            {
                SearchData = (ObservableCollection<DummyBank>)BankData.Where(x => x.BankName.Contains(textChanged.NewTextValue, StringComparison.OrdinalIgnoreCase));
            }
        }

        #endregion

        #region Messaging

        private async Task ExecutePickerCommand([Optional] DummyBank model)
        {

            var selectedBank = model;
            SelectedBank = selectedBank.BankName;
            SelectedBankCode = selectedBank.BankCode;
            MessagingCenter.Send<object, string>(this, "selectedBank", SelectedBank);
            MessagingCenter.Send<object, string>(this, "selectedBankCode", SelectedBankCode);
            await PopupNavigation.Instance.PopAsync(true);
        }
        #endregion
    }
}
