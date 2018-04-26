using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIRIApp
{
    //content page for about the app
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
            Title = "About";
            InitializeComponent ();
		}

        async void OnClick(object Sender, EventArgs e)
        {
            // debug for button pushes. remove on release
            await this.DisplayAlert("Alert", "You have pressed a button", "okay");
            await Navigation.PopAsync();
        }
    }
}