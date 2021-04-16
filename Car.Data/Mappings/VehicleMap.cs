using Car.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Mappings
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.CreatedDate).IsRequired();

            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.Property(c => c.Model).HasMaxLength(100);
            builder.Property(c => c.Model).IsRequired();

            builder.Property(c => c.Brand).HasMaxLength(100);
            builder.Property(c => c.Brand).IsRequired();

            builder.ToTable("Vehicles");
            builder.HasData(new Vehicle
            {
                Id = 1,
                ModifiedDate = DateTime.Now,
                Model = "Focus",
                Brand = "Ford",              
                IsActive = true,
                CreatedDate = DateTime.Now
            }, new Vehicle
            {
                Id = 2,
                ModifiedDate = DateTime.Now,
                Model = "S60",
                Brand = "Volvo",
                IsActive = true,
                CreatedDate = DateTime.Now
            }, new Vehicle
            {
                Id = 3,
                ModifiedDate = DateTime.Now,
                Model = "Quadrado",
                Brand = "Audi",
                IsActive = true,
                CreatedDate = DateTime.Now
            }, new Vehicle
            {
                Id = 4,
                ModifiedDate = DateTime.Now,
                Model = "Şahin",
                Brand = "Tofaş",
                IsActive = true,
                CreatedDate = DateTime.Now
            });

        }
    }
}
