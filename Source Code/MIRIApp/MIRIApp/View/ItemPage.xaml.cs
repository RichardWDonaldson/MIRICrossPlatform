
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIRIApp.View
{
    //content page that displays the item information
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemPage : ContentPage
	{
        public ItemPage()
        {
            Title = "Collaborator";
            InitializeComponent();


        }

    }

}