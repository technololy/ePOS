using System;
namespace SterlingePOSMerchant.Models
{
    public class CreateMerchant
    {
        public CreateMerchant()
        {
        }
        public string institutionNumber { get; set; }
        public string name { get; set; }
        public string tin { get; set; }
        public string contact { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string fee { get; set; }
        public string address { get; set; }
        public string timestamp { get; set; }


    }
}
