using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.OnBoarding
{
    public partial class RegNewMerchantProfile : ContentPage
    {
        public RegNewMerchantProfile()
        {
            InitializeComponent();
            this.Rvm = new ViewModels.RegisterViewModel();
            BindingContext = Rvm;
            Rvm.DummyMerchantProfile();
        }

        ViewModels.RegisterViewModel Rvm;

        public async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;

            }
            var result = await Rvm.CreateMerchantProfile();
            if (result.isSuccess)
            {


                await Navigation.PushAsync(new Views.OnBoarding.OTP(this.Rvm));
                await DisplayAlert("Successful", "Submerchant created", "OK");

            }
            else
            {
                await DisplayAlert("Opss!", result.Message ?? "An error occured", "OK");

            }
        }

        private bool ValidateForm()
        {
            var check = stackReg.Children.OfType<CustomControls.RoundedEntry>().ToList();
            foreach (var item in check)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    DisplayAlert("Required!!", $"{item.Placeholder} is needed to continue", "OK");
                    return false;
                }
            }
            return true;
        }
    }
}
