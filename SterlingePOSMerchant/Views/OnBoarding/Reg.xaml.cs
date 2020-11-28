using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.OnBoarding
{
    public partial class Reg : ContentPage
    {
        ViewModels.RegisterViewModel Rvm;
        public void btnRegister_Clicked(object sender, EventArgs e)
        {

        }

        public Reg()
        {
            InitializeComponent();
            Rvm = new ViewModels.RegisterViewModel();
            BindingContext = Rvm;

        }
    }
}
