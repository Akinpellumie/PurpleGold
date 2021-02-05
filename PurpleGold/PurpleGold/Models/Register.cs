using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleGold.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class Investor
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string referralCode { get; set; }
        public string imageUrl { get; set; }
        public string state { get; set; }
        public string houseOfResidence { get; set; }
        public string title { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public string bank { get; set; }
        public string isActive { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string phoneNumber2 { get; set; }
        public string postalCode { get; set; }
        public string nameOfNextOfKin { get; set; }
        public string meansOfIdentificationUrl { get; set; }
        public string marketerReason { get; set; }
        public string isMarketerVerified { get; set; }
        public string addressOfNextOfKin { get; set; }
        public string lastLogin { get; set; }
        public string dob { get; set; }
        public List<Wallet> wallet { get; set; }
    }

    public class RegisterRoot
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Investor> data { get; set; }
    }


}
