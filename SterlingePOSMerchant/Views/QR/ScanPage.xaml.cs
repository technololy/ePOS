using System;
using System.Collections.Generic;
using SterlingePOSMerchant.Models;
using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.QR
{
    public partial class ScanPage : ContentPage
    {
        public void QRType_Tapped(object sender, EventArgs e)
        {


            var obj = (TappedEventArgs)e;
            var selected = obj.Parameter.ToString();

            var selectedFrame = (Frame)sender;
            var parent = selectedFrame.Parent as StackLayout;
            foreach (var item in parent.Children)
            {
                var frm = item as Frame;


                VisualStateManager.GoToState(frm, "Normal");

            }
            VisualStateManager.GoToState((Frame)sender, "Selected");
            if (selected.Equals("Static"))
            {
                myZX.IsVisible = true;
                DynamicEntry.IsVisible = false;

            }
            else
            {
                myZX.IsVisible = false;
                DynamicEntry.IsVisible = true;
            }


        }

        ViewModels.QRGenViewModel qrVM;
        private (bool isSuccess, PayThruModels.DynamicQRGenResponse resp) result;

        public ScanPage()
        {
            InitializeComponent();
            qrVM = new ViewModels.QRGenViewModel();
            BindingContext = qrVM;
            myZX.BarcodeValue = Services.DataWareHouse.LoggedInMerchantData?.QrCodeStr;

            // QRType_Tapped(this, new EventArgs());
            //LoadQRBarCode();
        }


        public async void LoadQRBarCode(string BarCodeType)
        {

            using (Acr.UserDialogs.UserDialogs.Instance.Loading())
            {
                result = await qrVM.GetQRBarCodeContent();

            }
            if (result.isSuccess)
            {
                myZX.BarcodeValue = result.resp.codeString;
            }
            else
            {
                await DisplayAlert("Failed to generate QR", result.resp?.errorDesc ?? "Error occured", "OK");
            }
        }

        void genDynamicQR_Clicked(System.Object sender, System.EventArgs e)
        {
            LoadQRBarCode("");
        }
    }
}
