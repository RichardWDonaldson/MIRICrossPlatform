using MIRIApp.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;
using MIRIApp.Model;
using System.Collections.Generic;
using MIRIApp.View;

namespace MIRIApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubPage3 : ContentPage
	{

       

        public SubPage3 ()
		{
			InitializeComponent ();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Console.Write("Appearing! ");

            listView.ItemsSource = App.Database.CollaboratorList;
        }

        async void OnClick(object Sender, EventArgs e)
        {
            //debug for button press. remove on release
            // await this.DisplayAlert("Alert", "You have pressed a button", "Yes", "No");
            await Navigation.PopAsync();
        }

        private async void OnListItemSelected(object Sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {

                await Navigation.PushAsync(new ItemPage
                {
                    BindingContext = e.Item as Collaborator
                });
            }
        }


     

        
		


    }

} 
