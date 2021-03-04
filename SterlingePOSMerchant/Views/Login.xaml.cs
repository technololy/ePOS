using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SterlingePOSMerchant.Views
{
    public partial class Login : ContentPage
    {
        ViewModels.IndexViewModel IndexVM;
        public Login()
        {
            InitializeComponent();
            IndexVM = new ViewModels.IndexViewModel();
#if DEBUG
            txtEmail.Text = "loladeking OKRZ";//merchant
            txtEmail.Text = "loladeking TYWP";//cashier
            txtPassword.Text = "123456";
#endif
            // GetToken();
        }

        public Login(string userName, string Password)
        {
            InitializeComponent();
            IndexVM = new ViewModels.IndexViewModel();

            txtEmail.Text = userName;
            txtPassword.Text = Password;

            // GetToken();
        }

        private async void GetToken()
        {
            // txtEmail.Text = Settings.AppSettings.ClientId;

            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var response = await IndexVM.Reset();
                if (response)
                {

                    var getAccessToken = await IndexVM.SysLogin();
                    if (getAccessToken)
                    {
                        stackLogin.IsVisible = true;
                        //txtEmail.Text = Settings.AppSettings.ClientId;
                        btnRefresh.IsVisible = false;
                    }
                    else
                    {
                        stackLogin.IsVisible = false;
                        btnRefresh.IsVisible = true;
                    }


                }
                else
                {
                    stackLogin.IsVisible = false;
                    btnRefresh.IsVisible = true;
                }

            }
        }
        private bool ValidateForm()
        {
            var check = stackLogin.Children.OfType<CustomControls.RoundedEntry>().ToList();
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
        async void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }
            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var response = await IndexVM.UserLogin(txtEmail.Text, txtPassword.Text);
                if (response)
                {

                    Application.Current.MainPage = new AppShell();


                }
                else
                {

                    if (SterlingePOSMerchant.Services.DataWareHouse.ErrorLoggingInData != null && SterlingePOSMerchant.Services.DataWareHouse.ErrorLoggingInData.errorDesc.ToLower().Contains("password change required"))
                        await Navigation.PushAsync(new Views.OnBoarding.OTP(new ViewModels.RegisterViewModel()
                        {
                            Merchant = new Models.CreateMerchant { userName = txtEmail.Text }
                        }, isOnboarding: false));

                    else
                        await DisplayAlert("Failed", "Login failed", "OK");

                }

            }
        }

        void btnRegister_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Views.OnBoarding.Reg());
        }

        void GoBack(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
