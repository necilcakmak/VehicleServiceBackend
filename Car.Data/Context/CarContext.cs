using Car.Data.Mappings;
using Car.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Context
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VehiclePart> VehicleParts { get; set; }
        public DbSet<CompanyPerson> CompanyPersons { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceProduct> InvoicesProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new InvoiceMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new VehiclePartMap());
            modelBuilder.ApplyConfiguration(new InvoiceProductMap());
            modelBuilder.ApplyConfiguration(new CompanyPersonMap());
        }
    }
}
