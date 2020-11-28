using System;
using System.Collections.Generic;
using SterlingePOSMerchant.Models;
using Xamarin.Forms;

namespace SterlingePOSMerchant.Views.QR
{
    public partial class ScanPage : ContentPage
    {
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
