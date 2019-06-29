using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace EventUPv2
{
    public partial class QrCodePopup 
    {
        ZXingBarcodeImageView barcode;
        public QrCodePopup()
        {
            InitializeComponent();
            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 500;
            barcode.BarcodeOptions.Height = 500;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = "2503-"+Constants.CurrentUser.email;
            

            StackLQr.Children.Insert(1, barcode);
        }
    }
}
