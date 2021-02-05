using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleGold.Models
{
    #region Array of Banks

    // Bank myDeserializedClass = JsonConvert.DeserializeObject<Bank>(myJsonResponse); 
    public class BankList
    {
        public string id { get; set; }
        public string cbnCode { get; set; }

        [JsonProperty("bankName")]
        public string Name { get; set; }
        public string bankCode { get; set; }
        public string accountName { get; set; }
    }

    public class Bank
    {
        [JsonProperty("payload")]
        public List<BankList> Banks { get; set; }
        public List<DummyBank> Dummies { get; set; }
        public static BankList AcctName { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AccountName
    {
        public string accountName { get; set; }
    }

    public class AcctNameRoot
    {
        public AccountName payload { get; set; }
    }

    public class DummyBank
    {
        public string BankName { get; set; }
        public string BankCode { get; set; }
    }
    #endregion


    #region Paystack BankList API
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AllBanks
    {
        [JsonProperty("name")]
        public string BankName { get; set; }
        public string slug { get; set; }

        [JsonProperty("code")]
        public string BankCode { get; set; }
        public string longcode { get; set; }
        public string gateway { get; set; }
        public string pay_with_bank { get; set; }
        public string active { get; set; }
        public string is_deleted { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }

    public class BankRoot
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<AllBanks> data { get; set; }
    }


    #endregion
}
