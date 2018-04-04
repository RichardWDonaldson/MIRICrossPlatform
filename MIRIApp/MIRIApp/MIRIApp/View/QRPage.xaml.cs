using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Common;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace MIRIApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QRPage : ContentPage
	{
		public QRPage ()
		{
			InitializeComponent ();
            BindingContext = new ViewModel();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var scannerPage = new ZXingScannerPage();
            await Navigation.PushAsync(scannerPage);

            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("Scanned Detail", result.Text, "OK");
                });
            };

        }

    }

   
}