using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SterlingePOSMerchant.Models;
using SterlingePOSMerchant.ViewModels;
using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.OnBoarding
{
    public partial class OTP : ContentPage
    {
        public bool isOnBoarding { get; private set; }

        private RegisterViewModel rvm;

        public OTP()
        {
            InitializeComponent();
        }

        public OTP(RegisterViewModel rvm, bool isOnboarding = false)
        {
            InitializeComponent();
            this.isOnBoarding = isOnboarding;
            this.rvm = rvm;
            BindingContext = this.rvm;
        }

        protected override void OnAppearing()
        {


            StartMessageCenters();

            base.OnAppearing();
        }

        private void StartMessageCenters()
        {
            MessagingCenter.Subscribe<RegisterViewModel, bool>(
this, MessageKeys.otp_password, async (sender, arg) =>
{
    if (arg)
    {

        GoToHomePage(arg);

    }
    else
    {
        await DisplayAlert("Not successful", "This action was not successful", "OK");
    }

});
        }

        private void GoToHomePage(bool arg)
        {
            Application.Current.MainPage = new AppShell();

        }

        protected override void OnDisappearing()
        {
            StopMessageCenters();

            base.OnDisappearing();
        }

        private void StopMessageCenters()
        {
            MessagingCenter.Unsubscribe<RegisterViewModel, bool>(this, MessageKeys.otp_password);
        }

        private bool ValidateForm()
        {
            var check = stackOTP.Children.OfType<CustomControls.RoundedEntry>().ToList();
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

        public async void btnOTP_Password_Clicked(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;

            }

            var result = await rvm.VerifyOTP_SetPassword(null, this.isOnBoarding);
            if (result.status)
            {
                if (isOnBoarding)
                {
                    Application.Current.MainPage = new Views.Login(Services.DataWareHouse.UserNameDuringOnboarding, Services.DataWareHouse.PassWordDuringOnboarding);
                }
                else
                {
                    GoToHomePage(true);

                }
            }
            else
            {
                //GoToHomePage(false);
                await DisplayAlert("Opps!!", result.message ?? "error occured", "OK");
            }

        }



    }
}
