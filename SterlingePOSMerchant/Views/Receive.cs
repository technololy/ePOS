using System;

using Xamarin.Forms;

namespace SterlingePOSMerchant.Views
{
    public class Receive : ContentPage
    {
        public Receive()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

