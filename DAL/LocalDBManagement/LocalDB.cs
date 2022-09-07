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

        public LocalDB():base("FlightInfoDB")
        {           
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LocalDB>());
        }
    }
}
