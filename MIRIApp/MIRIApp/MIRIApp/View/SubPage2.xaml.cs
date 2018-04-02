using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIRIApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubPage2 : ContentPage
	{
		public SubPage2 ()
		{
			InitializeComponent ();
		}

        async void OnClick(object Sender, EventArgs e)
        {
            //debug for button press. remove on release
            await this.DisplayAlert("Alert", "You have pressed a button", "Yes", "No");
            await Navigation.PopAsync();
        }

    }

   
}