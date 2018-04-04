using MIRIApp.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;
using MIRIApp.Model;
using System.Collections.Generic;

namespace MIRIApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubPage3 : ContentPage
	{
        
      

        public SubPage3 ()
		{
			InitializeComponent ();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Console.Write("Appearing! ");

            listView.ItemsSource = await App.Database.GetCollaboratorAsync();
        }

        async void OnClick(object Sender, EventArgs e)
        {
            //debug for button press. remove on release
            await this.DisplayAlert("Alert", "You have pressed a button", "Yes", "No");
            await Navigation.PopAsync();
        }

        


    }

}   
