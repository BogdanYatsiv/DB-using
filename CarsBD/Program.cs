using CarsBD.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsBD
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new MyContext(connectionString: "Data Source=OMEN;Initial Catalog=NewCarsDB;Integrated Security=true;"))
            {
                context.Database.Migrate();

                var sal = context.Sales.Include(navigationPropertyPath: it => it.Car).
                    Include(navigationPropertyPath: it => it.Store).ToList();

                Console.WriteLine("Sales:");
                foreach(var s in sal)
                {
                    Console.WriteLine($"{s.Car.Brand} - {s.Price} by {s.Store.Name} date: {s.Date}");
                }
                Console.WriteLine();

                var jobs = context.ServiceJobs.Include(navigationPropertyPath: it=> it.Car).
                    Include(navigationPropertyPath: it => it.ServiceCenter).ToList();

                Console.WriteLine("Service Jobs:");
                foreach (var j in jobs)
                {
                    Console.WriteLine($"{j.ServiceCenter.Name} - {j.Car.Brand}");
                }
                Console.WriteLine();

                var centers = context.ServiceJobs.Join(context.Sales, sj => sj.car_id, s => s.car_id,
                                                    (sj, s) => new { service = sj.ServiceCenter.Name, price = s.Price }).
                                                    GroupBy(services => services.service).
                                                    Select(it => new { service = it.Key, price = it.Max(s => s.price) }).
                                                    OrderByDescending(it => it.price);

                Console.WriteLine("Service centers that serve cars that are sold by most price desc:");
                foreach(var s in centers)
                {
                    Console.WriteLine($"{s.service} - {s.price}");
                }
            }
        }
    }
}
