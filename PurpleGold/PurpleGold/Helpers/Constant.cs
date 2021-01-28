﻿using PurpleGold.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PurpleGold.Helpers
{
    public static class Constant
    {
        public static string Domainurl
        {
            get
            {
                return "https://purple-gold.herokuapp.com";
            }
        }
        public static string FormatAmount = "N52,000.00";
        public static string FaqUrl
        {
            get
            {
                return "https://purplegold.netlify.app/mobile-faq.html";
            }
        }
        
        public static string LoginUrl
        {
            get
            {
                return Domainurl + "/auth";
            }
        }
        public static string SignUpUrl
        {
            get
            {
                return Domainurl + "/investor/create_user";
            }
        }
        
        public static string VerifyOtpUrl
        {
            get
            {
                return Domainurl + "/verify_otp";
            }
        }
        public static string ConfirmRegUrl
        {
            get
            {
                return Domainurl + "/investor/set_security";
            }
        }
        
        public static string WithdrawUrl
        {
            get
            {
                return Domainurl + "/withdrawal_request";
            }
        }
        
        public static string ForgotUrl
        {
            get
            {
                return Domainurl + "/investor/forgot_password";
            }
        }
        public static string ResetPasswordUrl
        {
            get
            {
                return Domainurl + "/reset_password";
            }
        }
        
        public static string DownloadUrl
        {
            get
            {
                return Domainurl + "/public/";
            }
        }
        
        public static string ResendOtpUrl
        {
            get
            {
                return Domainurl + "/resend_otp";
            }
        }
        public static string GetWalletUrl
        {
            get
            {
                return Domainurl + "/wallet/users/";
            }
        }
        public static string InvestUrl
        {
            get
            {
                return Domainurl + "/investor/invest";
            }
        }
        
        public static string GetInvestmentUrl
        {
            get
            {
                return Domainurl + "/investor/user_investments/";
            }
        }
        
        public static string GetSecurityQueUrl
        {
            get
            {
                return Domainurl + "/security_question";
            }
        }
        
        public static string GetPlanUrl
        {
            get
            {
                return Domainurl + "/plan";
            }
        }
        
        public static string UploadUrl
        {
            get
            {
                return Domainurl + "/files";
            }
        }
        
        public static string UpdateUser
        {
            get
            {
                return Domainurl + "/investor/update_profile";
            }
        }
        
        public static string SecurityQueId
        {
            get
            {
                return "4b6a90fa-b2fb-44b2-b841-ece76b619d6c";
            }
        }
        
        public static string PlanId
        {
            get
            {
                return "cf869127-a300-417a-bad8-a32587e99514";
            }
        }

        public static List<SecurityQuestion> SecurityQuestionList { get; set; }
    }
}