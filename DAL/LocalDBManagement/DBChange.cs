using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;

namespace DAL.LocalDBManagement
{
    public class DBChange
    {
        public void AddFlight(FlightInfoPartial flight)
        {
            using (var ctx = new LocalDB())
            {
                ctx.DBFligths.Add(flight);
                ctx.SaveChanges();
            }

        }

        public void RemoveFlight(int id)
        {
            using (var ctx = new LocalDB())
            {
                ctx.DBFligths.Remove(ctx.DBFligths.Where(F => F.Id == id).FirstOrDefault());
                ctx.SaveChanges();
            }

        }
        public  FlightInfoPartial GetFlight(int id)
        {
            using (var ctx = new LocalDB())
            {
                var query = from flight in ctx.DBFligths
                            where flight.Id == id
                            select flight;
                return query.FirstOrDefault();
            }

        }
    }
}
