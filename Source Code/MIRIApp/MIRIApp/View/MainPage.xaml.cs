using System;
using Xamarin.Forms;

namespace MIRIApp
{
    //home page
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            Title = "MIRI";
            InitializeComponent();
		}

        async void OnClick(object Sender, EventArgs e)
        {
           
            Button button = (Button)Sender;
            string buttonID = button.StyleId;
            //switch statement that navigates to the appropriate page on press
            switch(buttonID)
            {
                // uses text value from button field in main xml NOT button name (took me a few tries to discover this BC)
                //QR page
                case "QR":
                    await Navigation.PushAsync(new QRPage());
                    break;
                    //Web link
                case "WE":
                    await Navigation.PushAsync(new SubPage2());
                    break;
                    //ListView page
                case "BR":
                    await Navigation.PushAsync(new SubPage3());
                    break;
                    //About section
                case "SE":
                    await Navigation.PushAsync(new SettingsPage());   
                    break;

                 default:                  
                    await this.DisplayAlert("Alert", "Error in Button Press", "Okay");
                    break;

            }
        }
	}
}
