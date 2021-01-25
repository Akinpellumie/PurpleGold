using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleGold.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class File
    {
        public string status { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }


}
