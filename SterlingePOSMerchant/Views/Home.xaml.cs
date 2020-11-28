using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Xamarin.Forms;

namespace SterlingePOSMerchant.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            LoadFeatureNames();
        }

        private void LoadFeatureNames()
        {
            List<Features> feat = new List<Features>()
            {
                new Features{Icon = Services.IconFont.Cards, Name = "Card Payment"},
                new Features{Icon = Services.IconFont.Qrcode, Name = "QR Payment"},
                new Features{Icon = Services.IconFont.Link, Name = "Share Link"},
                new Features{Icon = Services.IconFont.Transfer, Name = "Transfer"},
            };
            myCV.ItemsSource = feat;
        }

        public class Features
        {
            public string Icon { get; set; }
            public string Name { get; set; }
        }

        void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            try
            {
                if (!e.CurrentSelection.Any())
                {
                    return;
                }
                var page = (e.CurrentSelection.FirstOrDefault() as Features).Name.ToString().ToLower();
                if (page == "card payment")
                {

                }
                else if (page == "qr payment")
                {
                    Navigation.PushAsync(new QR.ScanPage());

                }
                else if (page == "transfer")
                {

                }
                else if (page == "share link")
                {

                }


                myCV.SelectedItem = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }
    }
}
