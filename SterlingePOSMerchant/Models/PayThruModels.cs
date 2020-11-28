using System;
namespace SterlingePOSMerchant.Models
{
    public class PayThruModels
    {
        public PayThruModels()
        {
        }
        public class BearerClass
        {
            public string Authorization { get; set; }
        }
        public class BaseResponse
        {
            public string returnCode { get; set; }
            public string returnMsg { get; set; }
        }

        public class DynamicQRGenResponse : BaseResponse
        {

            public string orderSn { get; set; }
            public string codeString { get; set; }
        }


    }
}
