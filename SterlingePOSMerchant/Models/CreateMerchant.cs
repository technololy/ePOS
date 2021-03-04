using System;
using static SterlingePOSMerchant.Models.PayThruModels;

namespace SterlingePOSMerchant.Models
{
    public class CreateMerchant : BaseResponse
    {
        private string userRoleText1;

        public CreateMerchant()
        {
        }
        public string institutionNumber { get; set; }
        public string name { get; set; }
        public string tin { get; set; }
        public string contact { get; set; }
        public string phoneNumberPri { get; set; }
        public string phone { get; set; }
        public string phoneNumberSec { get; set; }
        public string emailAddress { get; set; }
        public string email { get; set; }
        public string fee { get; set; }
        public string address1 { get; set; }
        public string address { get; set; }
        public string Address2 { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string userName { get; set; }
        public bool multiStore { get; set; }
        public string timestamp
        {
            get
            {

                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                return unixTimestamp.ToString();
            }
        }
        public string partnerCode { get; set; }
        public string userRole { get; set; }
        public string code { get; set; }
        public string jwt { get; set; }
        public string subFixed { get; set; }
        public string subAmount { get; set; }

        public string fullName { get => firstName + " " + middleName + " " + lastName; }
        public string userRoleText
        {
            get => userRoleText1; set
            {
                userRoleText1 = value;
                if (!string.IsNullOrEmpty(userRoleText1))
                {
                    if (userRoleText1.ToLower() == "merchant")
                    {
                        userRole = "08";
                    }
                    else if (userRoleText1.ToLower() == "submerchant")
                    {
                        userRole = "09";

                    }
                }
            }
        }
        public string createdBy { get; set; }
        public string state { get; set; }

        public string merchantNumber { get; set; }
        public string phoneNumber { get; internal set; }

        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string bankCode { get; set; }
        public string channelId { get; set; }
        public string phone2 { get; set; }
        public string QrCodeStr { get; set; }

    }
}
