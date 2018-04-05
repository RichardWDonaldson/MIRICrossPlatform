using SQLite;


namespace MIRIApp.Model
{
    public class Collaborator
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        
        public string itemName { get; set; }

        public string collabName { get; set; }

        public string city { get; set; }

        public string country { get; set; }

        public string description { get; set; }

        public int images { get; set; }

        public override string ToString()
        {
            return string.Format("[Person: id={0}, itemName={1}, collabName={2}, city={3}, country={4},description={5}, images={6}]", id, itemName, collabName, city, country, description, images);
        }
    }
    
}
