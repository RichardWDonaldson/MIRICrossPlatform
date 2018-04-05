using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIRIApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemPage : ContentPage
	{
		public ItemPage ()
		{
            Title = "Collaborator";

            InitializeComponent();


            //var idLabel = new Label();
            //idLabel.SetBinding(Label.TextProperty, "id");

            //var itemNameLabel = new Label();
            //itemNameLabel.SetBinding(Label.TextProperty, "Item");
            //var collabNameLabel = new Label();
            //collabNameLabel.SetBinding(Label.TextProperty, "Centre");
            //var cityLabel = new Label();
            //cityLabel.SetBinding(Label.TextProperty, "City");
            //var countryLabel = new Label();
            //countryLabel.SetBinding(Label.TextProperty, "Country");
            //var descriptionLabel = new Label();
            //descriptionLabel.SetBinding(Label.TextProperty, "Description");


            //Content = new StackLayout
            //{
            //    Margin = new Thickness(20),
            //    VerticalOptions = LayoutOptions.StartAndExpand,
            //    Children =
            //    {
            //        new Label { Text = "id" },
            //        idLabel,
            //        new Label { Text = "Item" },
            //        itemNameLabel,
            //        new Label { Text = "Centre" },
            //        collabNameLabel,
            //        cityLabel,
            //        countryLabel,
            //        descriptionLabel

            //    }
            //};


        }
	}
}