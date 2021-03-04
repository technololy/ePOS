using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SterlingePOSMerchant.Models;
using SterlingePOSMerchant.ViewModels;
using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.OnBoarding
{
    public partial class Reg : ContentPage
    {
        public bool IsMerchant { get; private set; }

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
                if (IsMerchant)
                {
                    await GoToOTPPage(true);

                }
                else
                {
                    await DisplayAlert("Successful", "Submerchant created", "OK");
                }
            }
            else
            {
                await DisplayAlert("Opss!", "An error occured", "OK");

            }

        }
        protected override void OnAppearing()
        {


            StartMessageCenters();

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            StopMessageCenters();

            base.OnDisappearing();
        }

        private void StopMessageCenters()
        {
            MessagingCenter.Unsubscribe<RegisterViewModel, bool>(this, MessageKeys.Registeration);
        }



        public Reg(bool isMerchant = true)
        {
            InitializeComponent();
            IsMerchant = isMerchant;
            this.
            Rvm = new ViewModels.RegisterViewModel();
            BindingContext = Rvm;
            pickerMerchant.SelectedItem = "Merchant";
            //if (isMerchant)
            //{
            //    Rvm.Merchant.userRoleText = "Merchant";

            //}
            //else
            //{
            //    //set user role to sub merchant

            //    Rvm.Merchant.userRoleText = "Submerchant";
            //    Title = "Submerchant registeration";
            //    lblInfo.Text = "Please fill all info and create submerchant";
            //    pickerMerchant.SelectedItem = "Submerchant";
            //}

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
        private void StartMessageCenters()
        {
            MessagingCenter.Subscribe<RegisterViewModel, bool>(
                this, MessageKeys.Registeration, async (sender, arg) =>
                {
                    if (arg)
                    {

                        await GoToOTPPage(arg);

                    }
                    else
                    {
                        await DisplayAlert("Not successful", "This action was not successful", "OK");
                    }

                });
        }

        private async Task GoToOTPPage(bool arg)
        {
            await Navigation.PushAsync(new Views.OnBoarding.OTP(Rvm), true);
        }
    }
}
