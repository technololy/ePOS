using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.OnBoarding
{
    public partial class RegNewMerchant : ContentPage
    {
        ViewModels.RegisterViewModel Rvm;

        public async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;

            }
            var result = await Rvm.CreateMerchant();
            if (result.isSuccess)
            {


                await Navigation.PushAsync(new Views.OnBoarding.OTP(this.Rvm));
                await DisplayAlert("Successful", "Merchant created", "OK");

            }
            else
            {
                await DisplayAlert("Opss!", result.Message ?? "An error occured", "OK");

            }
        }

        public RegNewMerchant()
        {
            InitializeComponent();
            this.Rvm = new ViewModels.RegisterViewModel();
            BindingContext = Rvm;
            pickerMerchant.SelectedItem = "Merchant";
            pickerMerchant.InputTransparent = false;
            Rvm.DummyNewcreateMerchant();
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
