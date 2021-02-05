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
    public class StateViewModel : BaseViewModel
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

       
        private ObservableCollection<State> stateList;
        public ObservableCollection<State> StateList
        {
            get => stateList;
            set
            {
                stateList = value;
                OnPropertyChanged(nameof(StateList));
            }
        }

        #endregion


        #region Constructors
        public StateViewModel()
        {
            //LoadBanks();
            GetStates();
            ClosePopCommand = new Command(async () => await ClosePop_Clicked());
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

        public void GetStates()
        {
            stateList = new ObservableCollection<State>();
            stateList.Add(new State { StateName = "Abia", StateCode = "023" });
            stateList.Add(new State { StateName = "Adamawa", StateCode = "023" });
            stateList.Add(new State { StateName = "Akwa Ibom", StateCode = "023" });
            stateList.Add(new State { StateName = "Anambra", StateCode = "023" });
            stateList.Add(new State { StateName = "Bauchi", StateCode = "023" });
            stateList.Add(new State { StateName = "Bayelsa", StateCode = "023" });
            stateList.Add(new State { StateName = "Benue", StateCode = "023" });
            stateList.Add(new State { StateName = "Borno", StateCode = "023" });
            stateList.Add(new State { StateName = "Cross River", StateCode = "023" });
            stateList.Add(new State { StateName = "Delta", StateCode = "023" });
            stateList.Add(new State { StateName = "Ebonyi", StateCode = "023" });
            stateList.Add(new State { StateName = "Edo", StateCode = "023" });
            stateList.Add(new State { StateName = "Ekiti", StateCode = "023" });
            stateList.Add(new State { StateName = "Enugu", StateCode = "023" });
            stateList.Add(new State { StateName = "Gombe", StateCode = "023" });
            stateList.Add(new State { StateName = "Imo", StateCode = "023" });
            stateList.Add(new State { StateName = "Jigawa", StateCode = "023" });
            stateList.Add(new State { StateName = "Kaduna", StateCode = "023" });
            stateList.Add(new State { StateName = "Kano", StateCode = "023" });
            stateList.Add(new State { StateName = "Katsina", StateCode = "023" });
            stateList.Add(new State { StateName = "Kebbi", StateCode = "023" });
            stateList.Add(new State { StateName = "Kogi", StateCode = "023" });
            stateList.Add(new State { StateName = "Kwara", StateCode = "023" });
            stateList.Add(new State { StateName = "Lagos", StateCode = "023" });
            stateList.Add(new State { StateName = "Nasarawa", StateCode = "023" });
            stateList.Add(new State { StateName = "Ogun", StateCode = "023" });
            stateList.Add(new State { StateName = "Ondo", StateCode = "023" });
            stateList.Add(new State { StateName = "Osun", StateCode = "023" });
            stateList.Add(new State { StateName = "Oyo", StateCode = "023" });
            stateList.Add(new State { StateName = "Plateau", StateCode = "023" });
            stateList.Add(new State { StateName = "Rivers", StateCode = "023" });
            stateList.Add(new State { StateName = "Sokoto", StateCode = "023" });
            stateList.Add(new State { StateName = "Taraba", StateCode = "023" });
            stateList.Add(new State { StateName = "Yobe", StateCode = "023" });
            stateList.Add(new State { StateName = "Zamfara", StateCode = "023" });
            stateList.Add(new State { StateName = "FCT (Abuja)", StateCode = "023" });
            StateList = stateList;

        }
        #endregion

        #region Commands

        public async Task ClosePop_Clicked()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        #endregion

        #region Messaging

        
        #endregion
    }
}
