using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MIRIApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        async void OnClick(object Sender, EventArgs e)
        {
            // debug for button presses. remove on release
           // await this.DisplayAlert("Alert", "You have pressed a button", "Yes", "No");
            Button button = (Button)Sender;
            string buttonID = button.StyleId;
            
            switch(buttonID)
            {
                // uses text value from button field in main xml NOT button name (took me a few tries to discover this BC)
                case "QR":
                    await Navigation.PushAsync(new QRPage());
                    break;

                case "WE":
                    await Navigation.PushAsync(new SubPage2());
                    break;

                case "BR":
                    await Navigation.PushAsync(new SubPage3());
                    break;

                case "SE":
                    await Navigation.PushAsync(new SettingsPage());   
                    break;

                 default:
                    //debug for button presses. remove on release
                    await this.DisplayAlert("Alert", "Error in Button Press", "Okay");
                    break;

            }
        }
	}
}
