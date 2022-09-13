using System.Data.Entity;

namespace DAL
{
    public class LocalDB : DbContext
    {
        public DbSet<BE.Models.FlightInfoPartial> DBFligths { get; set; }
        public DbSet<BE.Models.AirPort> DBAirports { get; set; }

        public LocalDB() : base("LocalDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LocalDB>());
        }
    }
}