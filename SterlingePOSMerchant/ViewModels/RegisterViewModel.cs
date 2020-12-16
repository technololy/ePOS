using System;
using SterlingePOSMerchant.Models;
using SterlingePOSMerchant.Settings;
using Xamarin.Forms;
using static SterlingePOSMerchant.Models.PayThruModels;

namespace SterlingePOSMerchant.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public CreateMerchant Merchant { get; set; }
        public System.Windows.Input.ICommand RegisterCommand { get; set; }
        public RegisterViewModel()
        {
            Merchant = new CreateMerchant();
            RegisterCommand = new Command(RegisterMerchant);
#if DEBUG
            Merchant = new CreateMerchant()
            {
                address1 = "chris okafor",
                firstName = "ololade",
                middleName = "ahmed",
                lastName = "oyebanji",
                emailAddress = "loladeking@gmail.com",
                partnerCode = "08",
                userName = "loladeking",
                userRoleText = "Merchant",
                phoneNumberPri = "+234" + "7036605597",
                createdBy = "1"
            };
#endif
        }

        private async void RegisterMerchant(object x)
        {
            Merchant.userRole = getUserRoleValue(Merchant.userRole);
            string url = AppSettings.BaseURL + "admin/create-profile";
            var obj = new { Merchant };

            var response = await APIServices.SendHashRequest<BaseResponse>(Merchant, false, url);
            if (response.isSuccess)
            {


            }
            else
            {


            }
        }

        private string getUserRoleValue(string userRole)
        {
            throw new NotImplementedException();
        }
    }
}
