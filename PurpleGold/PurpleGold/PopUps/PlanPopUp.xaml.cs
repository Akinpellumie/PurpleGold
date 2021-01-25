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
    public partial class PlanPopUp
    {
        PlanViewModel planViewModel;
        public PlanPopUp()
        {
            planViewModel = new PlanViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = planViewModel;
            //data();
            //list.ItemsSource = tempdata;
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

        public async void SelectedBank_Tapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            var selectedPlan = e.Item as MyPlan;
            SelectedPlan = selectedPlan.Title;
            SelectedPlanIcon = selectedPlan.PlanIcon;
            MessagingCenter.Send<object, string>(this, "selectedPlan", SelectedPlan);
            MessagingCenter.Send<object, ImageSource>(this, "selectedPlanIcon", SelectedPlanIcon);
            await PopupNavigation.Instance.PopAsync(true);
        }

    }
}