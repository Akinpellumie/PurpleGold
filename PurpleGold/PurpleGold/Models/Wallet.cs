﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleGold.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Wallet
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string wallet_mail { get; set; }
        public string balance { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }

    public class RootWallet
    {
        public string status { get; set; }
        public string message { get; set; }

        [JsonProperty("data")]
        public List<Wallet> Wallets { get; set; }
    }

    public class Withdraw
    {
        public string amount { get; set; }
        public string password { get; set; }
    }

}
