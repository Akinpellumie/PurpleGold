using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.ViewModel;
using RestSharp;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
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
        #endregion

        #region Methods
        public async void GetQuestion()
        {
            //questionModelList = new ObservableCollection<SecurityQuestion>();
            //questionModelList.Add(new SecurityQuestion { Question = "Where is your place of Birth?" });
            //questionModelList.Add(new SecurityQuestion { Question = "What is the name of your childhood Best Friend?" });
            //questionModelList.Add(new SecurityQuestion { Question = "What is your mothers maiden name?" });
            //questionModelList.Add(new SecurityQuestion { Question = "Where did you meet your Spouse?" });
            //questionModelList.Add(new SecurityQuestion { Question = "What is the name of the Primary School you attended?" });
            //questionModelList.Add(new SecurityQuestion { Question = "What is your best Food?" });
            //questionModelList.Add(new SecurityQuestion { Question = "What is your favorite Color?" });
            //questionModelList.Add(new SecurityQuestion { Question = "What is your favorite football club?" });
            //QuestionModelList = questionModelList;

            try
            {
                IsBusy = true;
                string url = Constant.GetSecurityQueUrl;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("appId", Settings.AppId);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "", ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                var res = response.Content;

                SecurityRoot secQues = JsonConvert.DeserializeObject<SecurityRoot>(res);
                var sorted = secQues.securityQuestions;

                var questions = new ObservableCollection<SecurityQuestion>(sorted);
                QuestionModelList = questions;
                IsBusy = false;
            }
            catch (Exception)
            {
                return;
            }

        }
        #endregion
    }
}
