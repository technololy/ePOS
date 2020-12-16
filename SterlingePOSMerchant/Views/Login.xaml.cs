using System;
using System.Collections.Generic;
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
            GetToken();
        }

        private async void GetToken()
        {
            txtEmail.Text = Settings.AppSettings.ClientId;

            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var response = await IndexVM.Reset();
                if (response)
                {

                    var getAccessToken = await IndexVM.Login();
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

        async void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {

            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var response = await IndexVM.Login();
                if (response)
                {

                    Application.Current.MainPage = new AppShell();


                }
                else
                {

                }

            }
        }

        void btnRegister_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Views.OnBoarding.Reg());
        }
    }
}
