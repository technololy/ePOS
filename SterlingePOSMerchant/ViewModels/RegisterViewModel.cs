using System;
using SterlingePOSMerchant.Models;
using Xamarin.Forms;

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
        }

        private void RegisterMerchant(object obj)
        {

        }
    }
}
