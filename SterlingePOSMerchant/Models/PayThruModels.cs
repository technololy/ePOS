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
            public string jwt { get; set; }
        }
        public class BaseResponse<T>
        {
            public string returnCode { get; set; }
            public string returnMsg { get; set; }
            public string errorDesc { get; set; }

            public T Data { get; set; }
        }
        public class ImageAndText
        {
            public string Image { get; set; }
            public string Text { get; set; }
        }
        public class BaseResponse
        {
            public string returnCode { get; set; }
            public string returnMsg { get; set; }
            public string errorDesc { get; set; }

        }

        public class DynamicQRGenResponse : BaseResponse<string>
        {

            public string orderSn { get; set; }
            public string codeString { get; set; }
        }


    }
}
