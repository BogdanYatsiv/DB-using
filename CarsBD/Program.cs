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
                Console.ReadKey();
                Console.WriteLine();


                var jobs = context.ServiceJobs.Include(navigationPropertyPath: it=> it.Car).
                    Include(navigationPropertyPath: it => it.ServiceCenter).ToList();

                Console.WriteLine("Service Jobs:");
                foreach (var j in jobs)
                {
                    Console.WriteLine($"{j.ServiceCenter.Name} - {j.Car.Brand}");
                }
                Console.ReadKey();
                Console.WriteLine();

                var serviceCenters = context.ServiceJobs.Include(navigationPropertyPath: sj => sj.Car.Sales).
                    AsEnumerable().GroupBy(sj => sj.ServiceCenter.Name).
                    Select(sc => new { 
                        Name = sc.Key, 
                        Price = sc.Select(s => s.Car.Sales.Max(car => car.Price).Value).First()
                    });
                Dictionary<string, int> servicePrice = new();


                //foreach(var sc in serviceCenters)
                //{
                //    int maxPrice = 0;

                //    foreach(var car in sc)
                //    {
                //        var sales = car.Car.Sales.ToList();
                //        foreach (var s in sales)
                //        {
                //            if (s.Price > maxPrice) maxPrice = (int)s.Price;
                //        }
                //    }
                //    servicePrice.Add(sc.Key, maxPrice);
                //}

                Console.WriteLine("Service centers that serve cars that are sold by most price desc:");
                foreach(var sc in serviceCenters)
                {
                    Console.WriteLine($"{sc.Name} - {sc.Price}");
                }
                //servicePrice.OrderByDescending(s => s.Value);
                //foreach (var sp in servicePrice)
                //{
                //    Console.WriteLine($"{sp.Key} - {sp.Value}");
                //}
            }
        }
    }
}
