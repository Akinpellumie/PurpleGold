using PurpleGold.Models;
using PurpleGold.ViewModel;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class SecurityQueViewModel : BaseViewModel
    {
        public SecurityQueViewModel(INavigation navigation)
        {

            Navigation = navigation;
            GetQuestion();
        }

        #region Properties
        private  ObservableCollection<SecurityQuestion> questionModelList;
        public ObservableCollection<SecurityQuestion> QuestionModelList
        {
            get => questionModelList;
            set
            {
                questionModelList = value;
                OnPropertyChanged(nameof(QuestionModelList));

            }
        }
        #endregion

        #region Methods
        public void GetQuestion()
        {
            questionModelList = new ObservableCollection<SecurityQuestion>();
            questionModelList.Add(new SecurityQuestion { Question= "Where is your place of Birth?"});
            questionModelList.Add(new SecurityQuestion { Question= "What is the name of your childhood Best Friend?" });
            questionModelList.Add(new SecurityQuestion { Question= "What is your mothers maiden name?" });
            questionModelList.Add(new SecurityQuestion { Question= "Where did you meet your Spouse?" });
            questionModelList.Add(new SecurityQuestion { Question= "What is the name of the Primary School you attended?" });
            questionModelList.Add(new SecurityQuestion { Question= "What is your best Food?" });
            questionModelList.Add(new SecurityQuestion { Question= "What is your favorite Color?" });
            QuestionModelList = questionModelList;

        }
        #endregion
    }
}
