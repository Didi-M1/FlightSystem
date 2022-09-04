using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;
using DAL;
namespace EF6CodeFirst
{
    public class EF6_DB
    {
        public static void AddFlight(FlightInfoPartial flight)
        {
            using (var ctx = new LocalDB())
            {
                ctx.DBFligths.Add(flight);
                ctx.SaveChanges();
            }

        }

        public static void RemoveFlight(int id)
        {
            using (var ctx = new LocalDB())
            {
               ctx.DBFligths.Remove(ctx.DBFligths.Where(F => F.Id == id).FirstOrDefault());
                ctx.SaveChanges();
            }

        }
        public static FlightInfoPartial GetFlight(int  id)
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
