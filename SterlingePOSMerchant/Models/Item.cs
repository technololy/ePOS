using System;

namespace SterlingePOSMerchant.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class BankInfo
    {
        public string BankName { get; set; }
        public string BankCode { get; set; }
    }
}