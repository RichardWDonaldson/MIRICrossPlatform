using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIRIApp
{
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