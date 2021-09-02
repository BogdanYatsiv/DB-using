using CarsBD.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CarsBD
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new MyContext(connectionString: "Data Source=OMEN;Initial Catalog=CarsDB;Integrated Security=true;"))
            {
                var centers = context.ServiceJobs.Include(navigationPropertyPath: it => it.ServiceCenter).
                                                    Include(navigationPropertyPath: it => it.Car).ToList();

                

                foreach(var c in centers)
                {
                    Console.WriteLine($"{c.ServiceCenter.Name} - {c.Car.Brand}");
                }

                
                Console.ReadKey();
            }
        }
    }
}
