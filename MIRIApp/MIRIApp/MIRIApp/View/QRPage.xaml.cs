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
	public partial class QRPage : ContentPage
	{
		public QRPage ()
		{
			InitializeComponent ();
		}

        async void OnClick(object Sender, EventArgs e)
        {
            await this.DisplayAlert("Alert", "You have pressed a button", "Yes", "No");
            await Navigation.PopAsync();
        }

    }

   
}