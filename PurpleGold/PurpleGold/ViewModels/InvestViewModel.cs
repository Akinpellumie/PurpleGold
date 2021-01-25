﻿using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.Services;
using PurpleGold.ViewModel;
using PurpleGold.Views;
using RestSharp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class InvestViewModel : BaseViewModel
    {
        private InvestService investService;
        public Command InvestCommand { get; }
        //public Command SignUpCommand { get; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        
        private bool isVisible;
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        private ObservableCollection<Investment> investmentData;
        public ObservableCollection<Investment> InvestmentData
        {
            get => investmentData;
            set
            {
                investmentData = value;
                OnPropertyChanged(nameof(InvestmentData));

            }
        }
        
        private ObservableCollection<InvestmentHistory> historyData;
        public ObservableCollection<InvestmentHistory> HistoryData
        {
            get => historyData;
            set
            {
                historyData = value;
                OnPropertyChanged(nameof(HistoryData));

            }
        }

        public string roi;

        public string ROI
        {
            get { return roi; }
            set { SetProperty(ref roi, value); }
        }

        public string planId;

        public string PlanId
        {
            get { return planId; }
            set { SetProperty(ref planId, value); }
        }


        public string amount;

        public string Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        public string duration;
        public string Duration
        {
            get { return duration; }
            set { SetProperty(ref duration, value); }
        }

        public string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public InvestViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LoadInvestment();
            CompletedInvestment();
                InvestCommand = new Command(() => OnInvest_Clicked());
            //SignUpCommand = new Command(() => OnSignUpClicked());
        }


        public void OnInvest_Clicked()
        {
            if (Amount == null || Password == null)
            {
                var required = "Fill all fields.";
                MessagingCenter.Send<object, string>(this, "FillAllFields", required);
            }
            else
            {

                var beginInvest = "start invest process";
                MessagingCenter.Send<object, string>(this, "loginStart", beginInvest);
                var investData = new CreateInvestment()
                {
                    amount = Amount,
                    planId = PlanId,
                    roi = ROI,
                    duration = Duration
                };

                investService = new InvestService();
                UserInvest(investData);
            }

        }

        private async void UserInvest(CreateInvestment investData)
        {
            bool res = await investService.CreateInvestment(investData);

            if (res.Equals(true))
            {
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync("//main");
            }
            if (res == true)
            {
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync("//main");
            }
        }


        public async void LoadInvestment()
        {
            try
            {
                IsBusy = true;

                var url = Constant.GetInvestmentUrl + Settings.UserId;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("appId", Settings.AppId);
                request.AddHeader("Authorization", Settings.Token);
                request.AddParameter("text/plain", "", ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);
                var res = response.Content;
                Console.WriteLine(response.Content);
                IsBusy = false;

                Invest userAssets = JsonConvert.DeserializeObject<Invest>(res);
                var sorted = userAssets.Investments;
                //getTrans = userTransactions
                var assets = new ObservableCollection<Investment>(sorted);
                if (assets.Count == 0)
                {
                    IsVisible = true;
                }
                else
                {
                    IsVisible = false;
                }
                InvestmentData = assets;
                IsBusy = false;
                Settings.InvestmentList = assets;
              
            }
            catch (Exception)
            {
                return;
            }
        }

        public async void CompletedInvestment()
        {
            IsBusy = true;
           
            var url = Constant.GetInvestmentUrl + Settings.UserId + "?status = COMPLETED";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("appId", Settings.AppId);
            request.AddHeader("Authorization", Settings.Token);
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            var res = response.Content;
            Console.WriteLine(response.Content);
            IsBusy = false;

            HistoryInvest userAssets = JsonConvert.DeserializeObject<HistoryInvest>(res);
            var sorted = userAssets.AssetHistory;
            //getTrans = userTransactions
            var assets = new ObservableCollection<InvestmentHistory>(sorted);
            if (assets.Count == 0)
            {
                IsVisible = true;
            }
            else
            {
                IsVisible = false;
            }
            HistoryData = assets;
        }


    }
}
