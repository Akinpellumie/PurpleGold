using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace PurpleGold.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    //public class MyPlan
    //{
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public string description { get; set; }
    //    public DateTime createdAt { get; set; }
    //    public DateTime updatedAt { get; set; }
    //    public string imgUrl { get; set; }

    //}

    public class Plan
    {
        public string status { get; set; }
        public string message { get; set; }

        [JsonProperty("data")]
        public List<MyPlan> myPlans { get; set; }
    }


    public class MyPlan
    {
        public string id { get; set; }
        public string name { get; set; }
        public string Title 
        {
            get 
            {
                var title = this.name + " (" + duration + " month(s))";
                return title;
            }
            set
            {
                Title = value;
            }
         }

        [JsonProperty("description")]
        public string Description { get; set; }
        public string imgUrl { get; set; }

        public ImageSource PlanIcon 
        {
            get 
            {
                    //return "https://res.cloudinary.com/dmnghlyic/image/upload/v1587479916/";
                Uri source = new Uri(imgUrl);
                return source;
            }
            set
            {
                PlanIcon = value;
            }
        }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public int duration { get; set; }
        public int roi { get; set; }
    }
}
