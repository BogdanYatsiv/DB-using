using CarsBD.EF;
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
                var myCars = context.Cars.Select(it => it.Brand).ToList();

                foreach(var carBrand in myCars)
                {
                    Console.WriteLine(carBrand);
                }
                Console.ReadKey();
            }
        }
    }
}
