using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using MIRIApp.Data;
using Xamarin.Forms.Xaml;
using System.IO;
using MIRIApp.Model;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MIRIApp
{
	public partial class App : Application
	{
        private static CollabDatabase database;
        
        
       
        public App ()
		{
			InitializeComponent();
         
            var MainPage = new NavigationPage(new MainPage());
            Application.Current.MainPage = MainPage;
            
        }

        public static CollabDatabase Database
        {
            get
            {
                if (database == null)
                {
                    // var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    //path = Path.Combine(path, "Collaborators.db");
                    
                    database = new CollabDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Collaborators.db3"));
                    Console.Write("App.xaml.cs Create Database");     
                    
                 
                }
                Console.Write("App.xaml.cs returned database");
                return database;
                
            }
        }

        

      

        protected override void OnStart ()
		{
           
			
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
