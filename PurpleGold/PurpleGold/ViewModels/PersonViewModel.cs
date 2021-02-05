using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        public PersonViewModel(INavigation navigation)
        {

            Navigation = navigation;
            GetTitle();
            //GetUserById();
            //PickerCommand = new Command<Gender>(async (model) => await ExecutePickerCommand(model));
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
        
        private ObservableCollection<PersonData> personData;
        public ObservableCollection<PersonData> PersonData
        {
            get => personData;
            set
            {
                personData = value;
                OnPropertyChanged(nameof(PersonData));

            }
        }

        private string fullname = Settings.Firstname + " " + Settings.Lastname;
        public string FullName
        {
            get => fullname;
            set
            {
                fullname = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        
        private string email = Settings.Email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string phoneNo = Settings.PhoneNumber;
        public string PhoneNumber
        {
            get => phoneNo;
            set
            {
                phoneNo = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        #endregion

        #region Methods
        public void GetTitle()
        {
            titleModelList = new ObservableCollection<Gender>();
            titleModelList.Add(new Gender { Title = "Mr" });
            titleModelList.Add(new Gender { Title = "Mrs" });
            titleModelList.Add(new Gender { Title = "Miss" });
            titleModelList.Add(new Gender { Title = "Chief" });
            titleModelList.Add(new Gender { Title = "Prof" });
            TitleModelList = titleModelList;

        }
        #endregion

        #region Messaging
        //private async Task ExecutePickerCommand([Optional] Gender model)
        //{

        //    var selectedTitle = model;
        //    SelectedTitle = selectedTitle.Title;
        //    MessagingCenter.Send<object, string>(this, "selectedTitle", SelectedTitle);
        //    //MessagingCenter.Send<object, string>(this, "selectedPlanIcon", SelectedPlanIcon);
        //    await PopupNavigation.Instance.PopAsync(true);
        //}
        #endregion
    }
}
