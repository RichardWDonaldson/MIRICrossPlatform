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
            await this.DisplayAlert("Alert", "You have pressed a button", "Yes", "No");
            Button button = (Button)Sender;
            string buttonText = button.Text;
            
                switch(buttonText)
            {
                case "QR":
                    await Navigation.PushAsync(new QRPage());
                    break;
                case "btn2":
                    break;
                case "Settings":
                 await Navigation.PushAsync(new SettingsPage());   
                    break;
                 default:
                    await this.DisplayAlert("Alert", "Error in Button Press", "Okay");
                    break;

            }
        }


       

	}
}
