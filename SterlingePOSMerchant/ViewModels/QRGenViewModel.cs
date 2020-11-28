using System;
using System.Threading.Tasks;
using static SterlingePOSMerchant.Models.PayThruModels;

namespace SterlingePOSMerchant.ViewModels
{
    public class QRGenViewModel : BaseViewModel
    {
        public QRGenViewModel()
        {
        }



        public async Task<(bool isSuccess, DynamicQRGenResponse resp)> GetQRBarCodeContent()
        {
            try
            {
                var model = new { channel = 1, orderType = 3, codeType = 3, merchantNo = "M0000000001", subMerchantNo = "S0000000002", amount = "12.00", orderNo = DateTime.Now.ToString("yyyyMMddHHmmss"), timestamp = DateTime.Now.ToFileTimeUtc() };
                var endPoint = Settings.AppSettings.BaseURL + "processor/generate-dynamic-qr";
                var result = await APIServices.SendRequest<DynamicQRGenResponse>(model, false, endPoint);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return (false, null);
            }

        }
    }
}
