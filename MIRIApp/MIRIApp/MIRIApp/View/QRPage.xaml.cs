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
        bool state = false;
        public bool itemScanned = false;
        

        public QRPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel();
            

        }   

        protected override void OnAppearing()
        {
            


            if(!state)
            {
                QRCode.IsVisible = false;
                QRButton.IsEnabled = false;
                state = true;
                ScanningPage();
               

            } else
            {
                
                QRCode.IsVisible = true;
                QRButton.IsEnabled = true;
                //Navigation.PopAsync();
            }
         }
    

        private async void ScanningPage()
        {
           
            var scannerPage = new ZXingScannerPage();
            await Navigation.PushAsync(scannerPage);
            List<Collaborator> list = await App.Database.GetCollaboratorAsync();

            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                  //  await DisplayAlert("Scanned Detail", result.Text, "OK");
                    char[] splitChar = { '/' };
                    split = result.Text.Split(splitChar);
                    Collaborator chosenCollab = FindCollaborator(list);

                    if (chosenCollab != null)
                    {
                        
                        await Navigation.PushAsync(new ItemPage
                        {
                            
                            BindingContext = chosenCollab as Collaborator

                        });

                    }
                    else
                    {
                        await DisplayAlert("Invalid QR Code", "Invalid QR Code - Please try again", "OK");
                    }





                });
            };
        }


        private async void Button_OnClicked(object sender, EventArgs e)
        {
            List<Collaborator> list = await App.Database.GetCollaboratorAsync();
            var scannerPage = new ZXingScannerPage();
            await Navigation.PushAsync(scannerPage);

            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                  //  await DisplayAlert("Scanned Detail", result.Text, "OK");
                    char[] splitChar = { '/' };
                    split = result.Text.Split(splitChar);
                    Collaborator chosenCollab = FindCollaborator(list);

                    if (chosenCollab != null)
                    {
                        await Navigation.PushAsync(new ItemPage
                        {
                            BindingContext = chosenCollab as Collaborator

                        });

                    }
                    else
                    {
                        await DisplayAlert("Invalid QR Code", "Invalid QR Code - Please try again", "OK");
                    }





                });
            };

        }

        private Collaborator FindCollaborator(List<Collaborator> list)
        {
            foreach (var Collaborator in list)
            {

                if ((Collaborator.id == int.Parse(split[0])) && (Collaborator.itemName == split[1]))
                {
                    return Collaborator;

                }
            }
            return null;



        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
                
          //  Navigation.PushAsync(new MainPage());
            base.OnBackButtonPressed();
            return false;
         }

        


    }


}