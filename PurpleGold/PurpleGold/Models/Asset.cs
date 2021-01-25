using PurpleGold.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleGold.Models
{
    public class Asset
    {
        public string Id { get; set; }
        public string Count { get; set; }
        public string RemDays { get; set; }
        public string CurrentDate { get; set; }
        public string OpeningAmount { get; set; }
        public string CurrentAmount { get; set; }
        public string BarImage { get; set; }
        public string Duration { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }

    public class Root
    {
        public List<Asset> Assets { get; set; }
    }
   
}
