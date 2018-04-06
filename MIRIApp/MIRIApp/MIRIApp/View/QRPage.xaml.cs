using MIRIApp.Data;
using MIRIApp.Model;
using MIRIApp.View;
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
        string[] split;
       
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
                    char[] splitChar = { '/' };
                    split = result.Text.Split(splitChar);
                    await DisplayAlert("Scanned Detail", split[0], "OK");
                    await DisplayAlert("Scanned Detail", split[1], "OK");

                    List<Collaborator> list = await App.Database.GetCollaboratorAsync();
                    
                    foreach(var Collaborator in list)
                    {
                        if((Collaborator.id == int.Parse(split[0])) && (Collaborator.itemName == split[1]))
                        {
                            await DisplayAlert("Found", "Item Found", "OK");
                            await Navigation.PushAsync(new ItemPage
                            {
                                BindingContext = Collaborator as Collaborator
                            });
                        } else
                        {
                            await DisplayAlert("Not found", "Item not found", "OK");
                        }
                    }

                });
            };

           

        }

    }

   
}