using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SterlingePOSMerchant.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }
    }
}
