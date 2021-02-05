using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.ViewModel;
using RestSharp;
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

        private ObservableCollection<AllBanks> searchData;
        public ObservableCollection<AllBanks> SearchData
        {
            get => searchData;
            set
            {
                searchData = value;
                OnPropertyChanged(nameof(SearchData));

            }
        }
        private ObservableCollection<AllBanks> bankData;
        public ObservableCollection<AllBanks> BankData
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
            GetAllBanks();
            SearchCommand = new Command<TextChangedEventArgs>(textChanged => SearchBar_TextChanged(textChanged));
            ClosePopCommand = new Command(async () => await ClosePop_Clicked());
            SelectedCommand = new Command<AllBanks>(async (model) => await ExecutePickerCommand(model));
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

        public void GetAllBanks()
        {
            try
            {
                if (Settings.BankList == null)
                {
                    IsBusy = true;

                    string url = Constant.AllBanksUrl;
                    var client = new RestClient(url);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("appId", "PGINVESTOR");
                    request.AddParameter("text/plain", "", ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var res = response.Content;
                    Console.WriteLine(response.Content);

                    IsBusy = false;

                    BankRoot allbanks = JsonConvert.DeserializeObject<BankRoot>(res);
                    while (!string.IsNullOrEmpty(res))
                    {
                        if (response.IsSuccessful)
                        {
                            var sorted = allbanks.data;
                            var banks = new ObservableCollection<AllBanks>(sorted);

                            BankData = banks;
                            Settings.BankList = banks;
                            IsBusy = false;
                            break;
                        }
                        else
                        {
                            return;
                        }
                    }

                }
                else
                {
                    BankData = new ObservableCollection<AllBanks>(Settings.BankList);
                    SearchData = BankData;
                }
            }
            catch (Exception)
            {
                return;
            }
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
                SearchData = (ObservableCollection<AllBanks>)BankData.Where(x => x.BankName.Contains(textChanged.NewTextValue, StringComparison.OrdinalIgnoreCase));
            }
        }

        #endregion

        #region Messaging

        private async Task ExecutePickerCommand([Optional] AllBanks model)
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
