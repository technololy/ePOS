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


        }

        ViewModels.QRGenViewModel qrVM;
        private (bool isSuccess, PayThruModels.DynamicQRGenResponse resp) result;

        public ScanPage()
        {
            InitializeComponent();
            qrVM = new ViewModels.QRGenViewModel();
            BindingContext = qrVM;
            LoadQRBarCode();
        }


        public async void LoadQRBarCode()
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

            }
        }
    }
}
