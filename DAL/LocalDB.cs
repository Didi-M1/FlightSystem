using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE;
namespace DAL
{
    class LocalDB:DbContext
    {
        public DbSet<BE.Models.FlightInfoPartial> DBFligths { get; set; }


    }
}
