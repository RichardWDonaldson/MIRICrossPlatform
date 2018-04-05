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
                //Populate();
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
            c1.itemName = "contamination-control-cover";
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

            Collaborator c2 = new Collaborator
            {
                itemName = "detectors",
                collabName = "NASA Jet Propulsion Laboratory (JPL)",
                city = "California",
                country = "USA",
                description = "The MIRI photodetectors are composed of semiconductor material that creates free charge carriers (i.e., electrons) " +
                "when photons are absorbed. These arsenic-doped silicon impurity band conduction (Si:As IBC) devices are sensitive to electromagnetic " +
                "radiation from 5 to 28.5 micrometres.",
                images = 2
            };
            database.InsertAsync(c2);

            Collaborator c3 = new Collaborator
            {
                itemName = "electronics",
                collabName = "Centre Spatial de Liege",
                city = "Leige",
                country = "Belgium",
                description = "To interface and provide control to all instrument systems.",
                images = 4
            };
            database.InsertAsync(c3);

            Collaborator c4 = new Collaborator
            {
                itemName = "imager",
                collabName = "CEA",
                city = "Saclay",
                country = "France",
                description = "For imaging, the MIRI imager offers 9 broadband filters covering wavelengths from 5.6 to 25.5 micrometers over an unobstructed 74' × 113' " +
                "field of view, and a detector plate scale of 0.11' / pixel(Bouchet et al. 2015).The MIRI imaging mode also supports the use of detector subarrays for " +
                "bright targets, as well as a variety of dither patterns that could improve sampling at the shortest wavelengths, remove detector artifacts and cosmic ray hits, " +
                "and facilitate self - calibration.",
                images = 3
            };
            database.InsertAsync(c4);

            Collaborator c5 = new Collaborator
            {
                itemName = "input-optics",
                collabName = "Centre Spatial de Liege",
                city = "Leige",
                country = "Belgium",
                description = "This unit takes the light from the telescope and divides and correctly formats the beam for the Imager and Spectrometer subsystems. " +
                "It also contains a Contamination Control Cover mechanism (provides by the Paul Scherrer Institute (PSI) in Switzerland) which ensure the sensitive optical " +
                "surface stay clean throughout the mission",
                images = 1
            };
            database.InsertAsync(c5);

            Collaborator c6 = new Collaborator
            {
                itemName = "mechanisms",
                collabName = "MPIA",
                city = "Heidelberg",
                country = "Germany",
                description = "In order to provide all observing modes such as broad/narrow-band imaging, coronagraphy and low/medium resolution spectroscopy, " +
                "the MIRI instrument is equipped with a filter wheel and two dichroic/grating wheel mechanisms. They allow for a re-configuration of the instrument " +
                "between the different observing modes and wavelength ranges. The lower MIRI operating temperature of T ~ 7 K provided by a dedicated cooler, much lower " +
                "than the passively cooled rest of JWST at a temperature of ~ 40 K, implying additional challenges. The main requirements for the three mechanisms with up " +
                "to 18 positions on the filter wheel (see Fig. 1) include: reliable operation at T ~ 7 K, optical precision of < 4 arcsec, low power dissipation, vibration " +
                "capability up to 13.5 Grms and full functionality in the temperature range 6 K < T < 300 K",
                images = 2
            };
            database.InsertAsync(c6);

            Collaborator c7 = new Collaborator
            {
                itemName = "optical-bench-assembly",
                collabName = "ASTRIUM, UKATC, CCLRC, JPL",
                city = "Various",
                country = "Various",
                description = "All the optics put together",
                images = 3
            };
            database.InsertAsync(c7);

            Collaborator c8 = new Collaborator
            {
                itemName = "simulator",
                collabName = "INTA",
                city = "Madrid",
                country = "Spain",
                description = "Deliver a test beam to MIRI similar to the output beam of the JWST and in similar conditions to the flight",
                images = 1
            };
            database.InsertAsync(c8);
        }


    }
}
