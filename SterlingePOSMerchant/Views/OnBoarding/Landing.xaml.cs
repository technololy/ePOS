using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.OnBoarding
{
    public partial class Landing : ContentPage
    {
        ViewModels.IndexViewModel IndexVM;

        public Landing()
        {
            InitializeComponent();
            IndexVM = new ViewModels.IndexViewModel();

            GetToken();



        }

        private async void GetToken()
        {

            bool response;
            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {


                if (string.IsNullOrEmpty(Xamarin.Essentials.SecureStorage.GetAsync("iv").Result))
                {
                    response = await IndexVM.Reset();

                }
                else
                {
                    Settings.AppSettings.iv = Xamarin.Essentials.SecureStorage.GetAsync("iv").Result;
                    Settings.AppSettings.key = Xamarin.Essentials.SecureStorage.GetAsync("key").Result;
                    response = true;

                }


                if (response)
                {

                    var getAccessToken = await IndexVM.SysLogin();
                    if (getAccessToken)
                    {
                        btnLogin.IsVisible = true;
                        btnRegister.IsVisible = true;
                        //txtEmail.Text = Settings.AppSettings.ClientId;
                        btnRefresh.IsVisible = false;
                    }
                    else
                    {
                        btnLogin.IsVisible = false;
                        btnRegister.IsVisible = false;
                        btnRefresh.IsVisible = true;
                    }


                }
                else
                {
                    btnLogin.IsVisible = false;
                    btnRegister.IsVisible = false;
                    btnRefresh.IsVisible = true;
                }

            }
        }

        void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {

            //using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            //{
            //    var response = await IndexVM.SysLogin();
            //    if (response)
            //    {

            //        Application.Current.MainPage = new AppShell();


            //    }
            //    else
            //    {

            //    }

            //}

            Navigation.PushAsync(new Views.Login(), true);
        }

        void btnRegister_Clicked(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new Views.OnBoarding.Reg());
            Navigation.PushAsync(new Views.OnBoarding.ProfileChoice());
        }

        void btnRefresh_Clicked(System.Object sender, System.EventArgs e)
        {
            GetToken();
        }
    }
}
