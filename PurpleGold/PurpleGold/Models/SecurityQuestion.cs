using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleGold.Models
{
    public class SecurityQuestion
    {
        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
        
        public string Answer { get; set; }
    }

    public class SecurityRoot
    {
        public string status { get; set; }
        public string message { get; set; }

        [JsonProperty("data")]
        public List<SecurityQuestion> securityQuestions { get; set; }
    }

    public class VerifyUserSecurity
    {
        public string securityQuestionId { get; set; }
        public string securityQuestionAnswer { get; set; }
        public string password { get; set; }
        public string id { get; set; }
    }
}
