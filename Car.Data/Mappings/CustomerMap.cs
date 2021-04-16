using Car.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.CreatedDate).IsRequired();

            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Name).IsRequired();

            builder.Property(c => c.Email).HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired();
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.PhoneNumber).IsRequired();

            builder.Property(c => c.TaxNo).HasMaxLength(50);
            builder.Property(c => c.TaxNo).IsRequired();

            builder.Property(c => c.Adress).HasMaxLength(250);
            builder.Property(c => c.Adress).IsRequired();


            builder.Property(c => c.CreatedDate).IsRequired();

            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.Property(c => c.IsActive).IsRequired();

            builder.ToTable("Customers");

            builder.HasData(new Customer
            {
                Id = 1,
                Name = "test",
                Email = "test@test.com",
                PhoneNumber = "0533423424",
                TaxNo = "123456",
                Adress = "Düzce/Akçakoca",
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate=DateTime.Now,
            }, new Customer
            {
                Id = 2,
                Name = "test2",
                Email = "test2@test.com",
                PhoneNumber = "0539851524",
                TaxNo = "654321",
                Adress = "Düzce/Merkez",
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            }, new Customer
            {
                Id = 3,
                Name = "test3",
                Email = "test3@test.com",
                PhoneNumber = "0539851524",
                TaxNo = "232424",
                Adress = "Zonguldak/Merkez",
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            }, new Customer
            {
                Id = 4,
                Name = "test4",
                Email = "test4@test.com",
                PhoneNumber = "0554551524",
                TaxNo = "6543656",
                Adress = "Bolu/Merkez",
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            });

        }
    }
}
