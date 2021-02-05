using PurpleGold.Models;
using System;
using System.Collections.ObjectModel;

namespace PurpleGold
{
    public static class Settings
    {
        public static string Firstname { get; set; }
        public static bool FirstTime { get; set; }
        public static string Days { get; set; }
        public static bool UserCreated { get; set; } = false;
        public static string CurrentAmount { get; set; }
        public static string balance { get; set; }
        public static string Balance
        {
            get
            {
                var newBal =  Math.Round(Convert.ToDouble(balance), 2).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-us")).Replace("$", "N");
                return newBal;
            }

            set
            {
                Balance = value;
            }
        }
        public static string Lastname { get; set; }
        public static string BankName { get; set; }
        public static string Token { get; set; }
        public static string Id { get; set; }
        public static string UserId { get; set; }
        public static string AndroidId { get; set; }
        public static string Status { get; set; }
        public static string Title { get; set; }
        public static string AccountNumber { get; set; }
        public static string AccountName { get; set; }
        public static string State { get; set; }
        public static string Address { get; set; }

        public static string Email { get; set; }
        public static string Priviledges { get; set; }
        public static string CapName { get; set; }
        public static string Name { get; set; }
        public static string PhoneNumber { get; set; }
        public static string Gender { get; set; }
        public static int IsActive { get; set; }
        public static string ReferralCode { get; set; }
        public static string ImageUrl { get; set; }

        public static Person PersonProfile { get; set; }
        public static GetInvestor CurrentInvestor { get; set; }
        public static string AppId
        {
            get
            {
                return "PGINVESTOR";
            }
        }

        public static ObservableCollection<MyPlan> PlanList { get; set; }
        public static ObservableCollection<AllBanks> BankList { get; set; }
        public static ObservableCollection<Investment> InvestmentList { get; set; }
    }

    public static class TransHelper
    {
        public static string referenceNumber { get; set; }
        public static string transactionId { get; set; }
        public static string inHubRefNum { get; set; }
    }

}