using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsBD.EF
{
    public class MyContext : DbContext
    {
        private readonly string _connectionString;
        public MyContext()
        {
            _connectionString = "Data Source=OMEN;Initial Catalog=NewCarsDB;Integrated Security=true;";
        }
        public MyContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, sqlServerOptionsAction: option => option.EnableRetryOnFailure());
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<ServiceCenter> ServiceCenters { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<ServiceJob> ServiceJobs { get; set; }
    }
}
