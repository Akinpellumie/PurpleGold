using PurpleGold.Models;
using PurpleGold.ViewModel;
using Rg.Plugins.Popup.Services;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class GenderViewModel : BaseViewModel
    {
        public GenderViewModel(INavigation navigation)
        {

            Navigation = navigation;
            GetTitle();
            PickerCommand = new Command<Gender>(async (model) => await ExecutePickerCommand(model));
        }


        #region Commands
        public Command PickerCommand { get; }
        #endregion
        #region Properties
        private ObservableCollection<Gender> titleModelList;
        public ObservableCollection<Gender> TitleModelList
        {
            get => titleModelList;
            set
            {
                titleModelList = value;
                OnPropertyChanged(nameof(TitleModelList));

            }
        }

        private string selectedTitle;
        public string SelectedTitle
        {
            get => selectedTitle;
            set
            {
                selectedTitle = value;
                OnPropertyChanged(nameof(SelectedTitle));
            }
        }

        private string selectedPlanIcon;
        public string SelectedPlanIcon
        {
            get => selectedPlanIcon;
            set
            {
                selectedPlanIcon = value;
                OnPropertyChanged(nameof(SelectedPlanIcon));
            }
        }
        #endregion

        #region Methods
        public void GetTitle()
        {
            titleModelList = new ObservableCollection<Gender>();
            titleModelList.Add(new Gender { Title = "None" });
            titleModelList.Add(new Gender { Title = "Mr"});
            titleModelList.Add(new Gender { Title = "Mrs"});
            titleModelList.Add(new Gender { Title = "Miss"});
            titleModelList.Add(new Gender { Title = "Chief"});
            titleModelList.Add(new Gender { Title = "Prof"});
            TitleModelList = titleModelList;

        }
        #endregion

        #region Messaging
        private async Task ExecutePickerCommand([Optional] Gender model)
        {

            var selectedTitle = model;
            SelectedTitle = selectedTitle.Title;
            MessagingCenter.Send<object, string>(this, "selectedTitle", SelectedTitle);
            //MessagingCenter.Send<object, string>(this, "selectedPlanIcon", SelectedPlanIcon);
            await PopupNavigation.Instance.PopAsync(true);
        }
        #endregion
    }
}
