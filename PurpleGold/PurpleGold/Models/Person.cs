using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;

namespace PurpleGold.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class UserRole
    {
        public string id { get; set; }
        public string roleName { get; set; }
    }

    public class PersonData
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string referralCode { get; set; }
        public string imageUrl { get; set; }
        public string state { get; set; }
        public string houseOfResidence { get; set; }
        public string title { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public string bank { get; set; }
        public int isActive { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string phoneNumber2 { get; set; }
        public string postalCode { get; set; }
        public string nameOfNextOfKin { get; set; }
        public string meansOfIdentificationUrl { get; set; }
        public string marketerReason { get; set; }
        public string isMarketerVerified { get; set; }
        public string addressOfNextOfKin { get; set; }

        public string token { get; set; }
        public List<UserRole> userRoles { get; set; }
        public List<Wallet> wallet { get; set; }
    }

    public class LoginUser
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    
    public class CreateUser
    {
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string fullname { get; set; }
        public string referralCode { get; set; }
        public string securityQuestionId { get; set; }
        public string securityQuestionAnswer { get; set; }
        public string otp { get; set; }
        public string userId { get; set; }

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class CreateUserData
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string referralCode { get; set; }
        public string imageUrl { get; set; }
        public string securityQuestionId { get; set; }
        public string securityQuestionAnswer { get; set; }
        public string state { get; set; }
        public string houseOfResidence { get; set; }
        public string title { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public string bank { get; set; }
        public string password { get; set; }
        public string isActive { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }

    public class RegisterInvestor
    {
        public string status { get; set; }
        public string message { get; set; }

        [JsonProperty("data")]
        public CreateUserData createUserData { get; set; }
    }
    public class Person
    {
        public string message { get; set; }

        [JsonProperty("data")]
        public PersonData personData { get; set; }
        public string Token { get; set; }
    }

    public class Gender
    {
        public string Title { get; set; }
        public string Sex { get; set; }
    }

    public class OTP
    {
        public string otp { get; set; }
        public string userId { get; set; }
    }
    public class ResendOTP
    {
        public string otp { get; set; }
        public string userId { get; set; }
        public string email { get; set; }
    }

    public class OTPResponse
    {
        public string message { get; set; }
        public List<OTP> oTPs { get; set; }
        public string status { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class UpdateUser
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phoneNumber { get; set; }
        public string state { get; set; }
        public string houseResidence { get; set; }
        public string title { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public string bank { get; set; }
        public string imageUrl { get; set; }
    }

    public class ResetPassword
    {
        public string email { get; set; }
        public string securityQuestionAnswer { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Data
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
        public int isActive { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string phoneNumber2 { get; set; }
        public string postalCode { get; set; }
        public string nameOfNextOfKin { get; set; }
        public string meansOfIdentificationUrl { get; set; }
        public string marketerReason { get; set; }
        public string isMarketerVerified { get; set; }
        public string addressOfNextOfKin { get; set; }
    }

    public class RootResetPass
    {
        public string status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class ChangePassword
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }

    public class RootChangePassword
    {
        public string status { get; set; }
        public string message { get; set; }
    }
}
