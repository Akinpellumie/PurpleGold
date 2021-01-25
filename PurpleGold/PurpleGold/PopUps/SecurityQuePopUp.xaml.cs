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
    public partial class SecurityQuePopUp
    {
        SecurityQueViewModel securityQueViewModel;
        public SecurityQuePopUp()
        {
            securityQueViewModel = new SecurityQueViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = securityQueViewModel;
            //data();
            //list.ItemsSource = tempdata;
        }

        private string secQue;
        public string SecQue
        {
            get => secQue;
            set
            {
                secQue = value;
                OnPropertyChanged(nameof(SecQue));
            }
        }
        
        private string secQueId;
        public string SecQueId
        {
            get => secQueId;
            set
            {
                secQueId = value;
                OnPropertyChanged(nameof(SecQueId));
            }
        }

        public async void SelectedBank_Tapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            var selectedQuestion = e.Item as SecurityQuestion;
            SecQue = selectedQuestion.Question;
            SecQueId = selectedQuestion.Id;
            MessagingCenter.Send<object, string>(this, "secQuestion", SecQue);
            MessagingCenter.Send<object, string>(this, "secQuestionId", SecQueId);
            await PopupNavigation.Instance.PopAsync(true);
        }

    }
}