using System;
namespace SterlingePOSMerchant.Models
{
    public class CreateMerchant
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
        public string phoneNumberSec { get; set; }
        public string emailAddress { get; set; }
        public string fee { get; set; }
        public string address1 { get; set; }
        public string Address2 { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string userName { get; set; }
        public string timestamp { get; set; }
        public string partnerCode { get; set; }
        public string userRole { get; set; }
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


    }
}
