using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class LocalDB:DbContext
    {
        public DbSet<BE.Models.FlightInfoPartial> DBFligths { get; set; }
        public DbSet<BE.Models.Airport> DBAirports { get; set; }
        public LocalDB():base("LocalDB")
        {           
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LocalDB>());
        }
    }
}
