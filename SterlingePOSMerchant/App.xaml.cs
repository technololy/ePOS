using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SterlingePOSMerchant.Services;
using SterlingePOSMerchant.Views;

namespace SterlingePOSMerchant
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
