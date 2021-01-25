using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.ViewModel;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class PlanViewModel : BaseViewModel
    {
        public PlanViewModel(INavigation navigation)
        {

            Navigation = navigation;
            GetPlan();
            PickerCommand = new Command<MyPlan>(async (model) => await ExecutePickerCommand(model));
        }


        #region Commands
        public Command PickerCommand { get; }
        #endregion
        #region Properties
        private ObservableCollection<MyPlan> planModelList;
        public ObservableCollection<MyPlan> PlanModelList
        {
            get => planModelList;
            set
            {
                planModelList = value;
                OnPropertyChanged(nameof(PlanModelList));

            }
        }

        private string selectedPlan;
        public string SelectedPlan
        {
            get => selectedPlan;
            set
            {
                selectedPlan = value;
                OnPropertyChanged(nameof(SelectedPlan));
            }
        }
        
        private string selectedPlanId;
        public string SelectedPlanId
        {
            get => selectedPlanId;
            set
            {
                selectedPlanId = value;
                OnPropertyChanged(nameof(SelectedPlanId));
            }
        }
        
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(isBusy));
            }
        }

        private ImageSource selectedPlanIcon;
        public ImageSource SelectedPlanIcon
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
        public async void GetPlan()
        {
            //planModelList = new ObservableCollection<Plan>();
            //planModelList.Add(new Plan { Title = "Gelato (1 month)", PlanIcon="star.svg", Description= "An investment plan that seeks to add value to short term investors interest and capital are withdrawn after a month of investment." });
            //planModelList.Add(new Plan { Title = "Honourable (3 months)", PlanIcon="honor.svg", Description= "A plan for investors who seek to withdraw their interest monthly while their capital is left for a period of at least 3 months." });
            //planModelList.Add(new Plan { Title = "Midas Touch (6 months)", PlanIcon="cup.svg", Description= "A long term investment plan between 3 - 6 months in which between the period of investment there shall be no premature withdrawal." });
            //PlanModelList = planModelList;

            try
            {

                if (Settings.PlanList == null)
                {

                    var client = new RestClient(Constant.GetPlanUrl);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("appId", Settings.AppId);
                    request.AddHeader("Authorization", Settings.Token);
                    request.AddParameter("text/plain", "", ParameterType.RequestBody);
                    IRestResponse response = await client.ExecuteAsync(request);
                    var res = response.Content;
                    Console.WriteLine(response.Content);
                    Plan userPlans = JsonConvert.DeserializeObject<Plan>(res);
                    var sorted = userPlans.myPlans;

                    var groupedMembers = new ObservableCollection<MyPlan>(sorted);
                    PlanModelList = groupedMembers;
                    Settings.PlanList = groupedMembers;
                }
                else
                {
                    PlanModelList = Settings.PlanList;
                }
            }
            catch (Exception)
            {
                return;
            }


        }
        #endregion

        #region Messaging
        private async Task ExecutePickerCommand([Optional] MyPlan model)
        {

            var selectedPlan = model;
            SelectedPlan = selectedPlan.Title;
            SelectedPlanId = selectedPlan.id;
            SelectedPlanIcon = selectedPlan.PlanIcon;
            MessagingCenter.Send<object, string>(this, "selectedPlan", SelectedPlan);
            MessagingCenter.Send<object, string>(this, "selectedPlanId", SelectedPlanId);
            MessagingCenter.Send<object, ImageSource>(this, "selectedPlanIcon", SelectedPlanIcon);
            await PopupNavigation.Instance.PopAsync(true);
        }
        #endregion
    }
}
