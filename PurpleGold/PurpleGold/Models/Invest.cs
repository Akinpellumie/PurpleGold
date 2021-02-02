using Newtonsoft.Json;
using PurpleGold.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PurpleGold.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Investment : BaseViewModel
    {
        string days;
        string newBal;

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("planId")]
        public string PlanId { get; set; }

        public string amount { get; set; }

        public string Amount
        {
            get
            {
                var newBal = Math.Round(Convert.ToDouble(this.amount), 2).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-us")).Replace("$", "N");
                return newBal;
            }

            set
            {
                Amount = value;
            }
        }

        [JsonProperty("roi")]
        public string InvestmentReturn { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public string totalReturn { get; set; }
        public string AssetName { get; set; }

        public string totalBalance;
        public string TotalBalance
        {
            get
            {
                string meeBal = Math.Round(Convert.ToDouble(this.totalReturn), 2).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-us")).Replace("$", "N");
                return meeBal;
            }
            set
            {
                TotalBalance = value;
                OnPropertyChanged(nameof(TotalBalance));
            }
        }

        //public string TotalBalance 
        //{
        //    get 
        //    {
        //        string meeBal = Math.Round(Convert.ToDouble(this.totalReturn), 2).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-us")).Replace("$", "N");
        //        return meeBal;
        //    }
        //    set 
        //    { 
        //        TotalBalance = value;
        //        OnPropertyChanged(nameof(TotalBalance));
        //    }
        //}

        //public string TotalBal
        //{
        //    get
        //    {
        //        string kems = "loading...";
        //        return kems;
        //    }

        //    set
        //    {
        //        TotalBal = value;
        //    }
        //}

        public string startDate { get; set; }

        public string StartDate
        {
            get
            {
                DateTime date = DateTime.Parse(this.startDate.Replace("[UTC]", ""));
                var newDate = date.ToLocalTime().ToString("dd MMM yyyy");
                return newDate;
            }
            set { StartDate = value; }
        }

        public string endDate { get; set; }

        public string EndDate
        {
            get
            {
                DateTime date = DateTime.Parse(this.endDate.Replace("[UTC]", ""));
                var newDate = date.ToLocalTime().ToString("dd MMM yyyy");
                return newDate;
            }
            set { EndDate = value; }
        }

        public string createdAt { get; set; }

        public string CreatedAt
        {
            get
            {
                DateTime date = DateTime.Parse(this.createdAt.Replace("[UTC]", ""));
                var newDate = date.ToLocalTime().ToString("dd MMM yyyy");
                return newDate;
            }
            set { CreatedAt = value; }
        }

        public string updatedAt { get; set; }

        public string UpdatedAt 
        {
            get
            {
                DateTime date = DateTime.Parse(this.updatedAt.Replace("[UTC]", ""));
                var newDate = date.ToLocalTime().ToString("dd MMM yyyy");
                return newDate;
            }
            set { UpdatedAt = value; } 
        }

        [JsonProperty("duration")]
        public string Duration { get; set; }
        
        [JsonProperty("mouUrl")]
        public string MouUrl { get; set; }
        public string CountDown
        {
            get 
            {
                DateTime end = DateTime.Parse(this.endDate.Replace("[UTC]", ""));
                DateTime start = DateTime.Parse(this.startDate.Replace("[UTC]", ""));
                DateTime today = DateTime.Today;
                TimeSpan remaining = end - DateTime.Now;
                var diffe = remaining.Days;
                days = diffe.ToString();
                Settings.Days = days;
                string rem = days + " DAYS REMAINING";
                return rem;

            }
            set 
            {
                CountDown = value;
            }
        }
    }
    
    public class InvestmentHistory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("planId")]
        public string PlanId { get; set; }

        public string amount { get; set; }

        public string Amount
        {
            get
            {
                var newBal = Math.Round(Convert.ToDouble(this.amount), 2).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-us")).Replace("$", "N");
                return newBal;
            }

            set
            {
                Amount = value;
            }
        }

        [JsonProperty("roi")]
        public string InvestmentReturn { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public string totalReturn { get; set; }
        public string TotalBalance
        {
            get
            {
                var newBal = Math.Round(Convert.ToDouble(this.totalReturn), 2).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-us")).Replace("$", "N");
                return newBal;
            }

            set
            {
                TotalBalance = value;
            }
        }

        public string startDate { get; set; }

        public string StartDate
        {
            get
            {
                DateTime date = DateTime.Parse(this.startDate.Replace("[UTC]", ""));
                var newDate = date.ToLocalTime().ToString("dd MMM yyyy");
                return newDate;
            }
            set { StartDate = value; }
        }

        public string endDate { get; set; }

        public string EndDate
        {
            get
            {
                DateTime date = DateTime.Parse(this.endDate.Replace("[UTC]", ""));
                var newDate = date.ToLocalTime().ToString("dd MMM yyyy");
                return newDate;
            }
            set { EndDate = value; }
        }

        public string Duration
        {
            get
            {
                var dur = this.StartDate + " - " + this.EndDate;
                return dur;
            }
            set
            {
                Duration = value;
            }
        }
        public string createdAt { get; set; }

        public string CreatedAt
        {
            get
            {
                DateTime date = DateTime.Parse(this.createdAt.Replace("[UTC]", ""));
                var newDate = date.ToLocalTime().ToString("dd MMM yyyy");
                return newDate;
            }
            set { CreatedAt = value; }
        }

        public string updatedAt { get; set; }

        public string UpdatedAt 
        {
            get
            {
                DateTime date = DateTime.Parse(this.updatedAt.Replace("[UTC]", ""));
                var newDate = date.ToLocalTime().ToString("dd MMM yyyy");
                return newDate;
            }
            set { UpdatedAt = value; } 
        }

        [JsonProperty("duration")]
        public string duration { get; set; }
        public string CountDown
        {
            get 
            {
                DateTime end = DateTime.Parse(this.endDate.Replace("[UTC]", ""));
                DateTime start = DateTime.Parse(this.startDate.Replace("[UTC]", ""));
                TimeSpan timeSpan = end.Subtract(start);
                var dys = timeSpan.Days.ToString();
                string rem = dys + " DAYS REMAINING";
                return rem;

            }
            set 
            {
                CountDown = value;
            }
        }
    }

    public class CreateInvestment
    {
        public string planId { get; set; }
        public string amount { get; set; }
        public string roi { get; set; }
        public string duration { get; set; }
    }
    public class Invest
    {
        public string status { get; set; }
        public string message { get; set; }

        [JsonProperty("data")]
        public List<Investment> Investments { get; set; }
    }
    
    public class HistoryInvest
    {
        public string status { get; set; }
        public string message { get; set; }
        
        [JsonProperty("data")]
        public List<InvestmentHistory> AssetHistory { get; set; }
    }


}
