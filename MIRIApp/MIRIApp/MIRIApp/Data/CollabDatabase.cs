using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MIRIApp.Model;


namespace MIRIApp.Data
{
  public class CollabDatabase
    {
      public readonly SQLiteAsyncConnection database;

        public CollabDatabase(string dbPath)
        {
            try
            {
                database = new SQLiteAsyncConnection(dbPath);
                Console.Write("database is connected");
                database.CreateTableAsync<Collaborator>().Wait();
                Populate();
            } catch (SQLiteException e)
            {
                Console.Write("SQLite ERROR ");
            }
          
            Console.Write("Database has populated");
        }

        public Task<List<Collaborator>> GetCollaboratorAsync()
        {
            return database.Table<Collaborator>().ToListAsync();
        }

        public void Populate()
        {
            
            Collaborator c1 = new Collaborator();
            c1.itemName = "ccc";
            c1.collabName = "Paul Scherrer Institute";
            c1.city = "Villigen";
            c1.country = "Switzerland";
            c1.description = "This cover is placed in the entrance optical path of MIRI right after the picko. " +
                "mirror (POM) and will be closed during the instruments cool down phase and at MIRIs operational " +
                "temperature each time the POM is heated up for decontamination. The CCC will be used further as an optical shutter " +
                "for dark sky calibration and for the protection against latency images which might emerge from coronagraphic filter " +
                "changes.";
            c1.images = 4;
            database.InsertAsync(c1);

        }


    }
}
