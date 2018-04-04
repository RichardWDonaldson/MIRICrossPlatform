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
        readonly SQLiteAsyncConnection database;

        public CollabDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Collaborator>().Wait();
        }

        public Task<List<Collaborator>> GetCollaboratorAsync()
        {
            return database.Table<Collaborator>().ToListAsync();
        }

        


    }
}
