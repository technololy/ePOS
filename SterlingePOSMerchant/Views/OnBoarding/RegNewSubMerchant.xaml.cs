using System;
using System.Collections.Generic;
using System.Linq;
using SterlingePOSMerchant.Models;
using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.OnBoarding
{
    public partial class RegNewSubMerchant : ContentPage
    {
        ViewModels.RegisterViewModel Rvm;

        public async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;

            }
            var result = await Rvm.CreateSubMerchant();
            if (result.isSuccess)
            {


                await Navigation.PushAsync(new Views.OnBoarding.OTP(this.Rvm));
                await DisplayAlert("Successful", "Submerchant created", "OK");

            }
            else
            {
                await DisplayAlert("Opss!", result.message ?? "An error occured", "OK");

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
        public RegNewSubMerchant()
        {
            InitializeComponent();
            this.Rvm = new ViewModels.RegisterViewModel();
            BindingContext = Rvm;
            Rvm.DummyNewcreateSubMerchant();

        }

        void MyPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            this.Rvm.Merchant.bankCode = ((BankInfo)myPicker.SelectedItem).BankCode;
        }
    }
}
