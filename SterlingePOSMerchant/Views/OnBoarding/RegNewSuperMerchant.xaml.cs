using System;
using System.Collections.Generic;
using System.Linq;
using SterlingePOSMerchant.Models;
using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.OnBoarding
{
    public partial class RegNewSuperMerchant : ContentPage
    {
        ViewModels.RegisterViewModel Rvm;
        private (bool isSuccess, string Message) result;
        private bool isOnboarding;

        public RegNewSuperMerchant()
        {
            InitializeComponent();
            this.Rvm = new ViewModels.RegisterViewModel();
            Rvm.Merchant.multiStore = true;

            BindingContext = Rvm;
#if DEBUG
            Rvm.DummyNewcreateSuperMerchant();

#endif
            txtMultiStore.InputTransparent = true;
        }

        public RegNewSuperMerchant(bool isMultiStore, string userrole = "", bool isThisOnBoarding = false)
        {
            InitializeComponent();
            this.Rvm = new ViewModels.RegisterViewModel();
            Rvm.Merchant.multiStore = isMultiStore;
            Rvm.Merchant.userRole = userrole;
            isOnboarding = isThisOnBoarding;

            BindingContext = Rvm;
#if DEBUG
            Rvm.DummyNewcreateSuperMerchant();
            Rvm.Merchant.multiStore = isMultiStore;
            Rvm.Merchant.userRole = userrole;


#endif
            if (isMultiStore)
            {
                txtMultiStore.Text = "True";

            }
            else
            {
                txtMultiStore.Text = "False";
                lblHeader.Text = "Create merchants";
            }
            txtMultiStore.InputTransparent = true;
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


        public async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;

            }

            if (isOnboarding)
            {
                result = await Rvm.CreateMerchantProfileAtOnboarding(afterLogin: false);

            }
            else
            {
                if (Rvm.Merchant.userRole == "03")//super merchant
                {
                    result = await Rvm.CreateSuperMerchantProfile(afterLogin: true);

                }

                else if (Rvm.Merchant.userRole == "07")// merchant
                {
                    result = await Rvm.CreateMerchantProfile(useHardCodedJson: false, afterLogin: true);

                }

                else if (Rvm.Merchant.userRole == "05")//sub merchant
                {
                    result = await Rvm.CreateSuperMerchantProfile();

                }
            }


            if (result.isSuccess)
            {


                await Navigation.PushAsync(new Views.OnBoarding.OTP(this.Rvm, isOnboarding));
                await DisplayAlert("Successful", "Merchant created", "OK");

            }
            else
            {
                await DisplayAlert("Opss!", result.Message ?? "An error occured", "OK");

            }
        }

        void MyPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            this.Rvm.Merchant.bankCode = ((BankInfo)myPicker.SelectedItem).BankCode;
        }
    }
}
