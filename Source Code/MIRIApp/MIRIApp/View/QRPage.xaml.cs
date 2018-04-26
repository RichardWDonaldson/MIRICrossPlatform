using MIRIApp.Model;
using MIRIApp.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MIRIApp
{
    //Content page for the QR scanner
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRPage : ContentPage
    {
        //array used to store split string of QR code
        string[] split;
        //used to check if the scanner has already been used once
        bool state = false;
       
        

        public QRPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel();
            

        }   

        protected override void OnAppearing()
        {
            

            //if the scanner page has been opened
            if(!state)
            {
                QRCode.IsVisible = false;
                QRButton.IsEnabled = false;
                state = true;
                ScanningPage();
               
                //if navigating back to the scanner page
            } else
            {
                
                QRCode.IsVisible = true;
                QRButton.IsEnabled = true;
                
            }
         }
    
        //creates the scanner overlay
        private async void ScanningPage()
        {
           
            var scannerPage = new ZXingScannerPage();
            await Navigation.PushAsync(scannerPage);
            //adds all database items to list
            List<Collaborator> list = await App.Database.GetCollaboratorAsync();

            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
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

        //if scan again button is pressed
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

                    char[] splitChar = { '/' };
                    split = result.Text.Split(splitChar);
                    Collaborator chosenCollab = FindCollaborator(await App.Database.GetCollaboratorAsync());

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
        //used to lookup scanned collaborator
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
        //if the back button is pressed
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            base.OnBackButtonPressed();
            return false;
         }

        


    }


}