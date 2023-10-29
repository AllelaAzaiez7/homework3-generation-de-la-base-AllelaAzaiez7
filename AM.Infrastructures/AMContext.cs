using AM.ApplicationCore.Domain;
using AM.Infrastructures.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AM.Infrastructures
{
    internal class AMContext : DbContext
    {
        //3eme declaration Dbset
        public DbSet <Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.fUllName, 
                Full => { 
                Full.Property(p => p.FirstName);
                Full.Property(p => p.LastName);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
