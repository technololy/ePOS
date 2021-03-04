using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static SterlingePOSMerchant.Models.PayThruModels;

namespace SterlingePOSMerchant.Views.OnBoarding
{
    public partial class ProfileChoice : ContentPage
    {
        public ProfileChoice()
        {
            InitializeComponent();

            List<ImageAndText> imgAndTxt = new List<ImageAndText>()
           {
               new ImageAndText {Image="tab_feed",Text=$"Multiple stores {Environment.NewLine}(e.g. Shoprite"},
               new ImageAndText {Image="tab_about",Text=$"Single Store{Environment.NewLine} (e.g. One single shop at ikeja)"},
           };

            myToggle.SetItemSource(imgAndTxt);
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(myToggle.SelectedItem))
            {
                return;
            }
            if (myToggle.SelectedItem.ToLower().Contains("multiple"))
            {
                Navigation.PushAsync(new RegNewSuperMerchant(true, "03", isThisOnBoarding: true));


            }
            else if (myToggle.SelectedItem.ToLower().Contains("single"))
            {

                Navigation.PushAsync(new RegNewSuperMerchant(false, "07", isThisOnBoarding: true));

            }
        }
    }
}
