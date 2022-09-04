using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;
using DAL;
namespace EF6CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 1;
            AddFlight(new FlightInfoPartial(id,"TLV",1000,1000,DateTime.Now,"Natbag","Maroco","ffffff"));
            var f= GetFlight(1);
            RemoveFlight(f.Id);
        }
        static void AddFlight(FlightInfoPartial flight)
        {
            using (var ctx = new LocalDB())
            {
                ctx.DBFligths.Add(flight);
                ctx.SaveChanges();
            }

        }

        static void RemoveFlight(int id)
        {
            using (var ctx = new LocalDB())
            {
               ctx.DBFligths.Remove(ctx.DBFligths.Where(F => F.Id == id).FirstOrDefault());
                ctx.SaveChanges();
            }

        }
        static FlightInfoPartial GetFlight(int  id)
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
