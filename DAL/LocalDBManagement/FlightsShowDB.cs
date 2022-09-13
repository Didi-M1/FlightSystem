using System.Data.Entity;

namespace DAL
{
    public class FlightsShowDB : DbContext
    {
        // Your context has been configured to use a 'FlightsShowDB' connection string from your application's
        // configuration file (App.config or Web.config). By default, this connection string targets the
        // 'DAL.FlightsShowDB' database on your LocalDb instance.
        //
        // If you wish to target a different database and/or database provider, modify the 'FlightsShowDB'
        // connection string in the application configuration file.
        public FlightsShowDB()
            : base("name=FlightsShowDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<BE.Models.FlightInfoPartial> DBFligths { get; set; }
        public DbSet<BE.Models.AirPort> DBAirports { get; set; }
    }
}