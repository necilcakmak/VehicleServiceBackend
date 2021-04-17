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
    public class CompanyPersonMap : IEntityTypeConfiguration<CompanyPerson>
    {
        public void Configure(EntityTypeBuilder<CompanyPerson> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.CreatedDate).IsRequired();


            builder.Property(a => a.Role).IsRequired();

            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Name).IsRequired();

            builder.Property(c => c.Email).HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired();
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.Password).HasMaxLength(100);
            builder.Property(c => c.Password).IsRequired();

            builder.ToTable("CompanyPersons");

            builder.HasData(new CompanyPerson
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@admin.com",
                Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                Role="Admin",
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate=DateTime.Now
            }, new CompanyPerson
            {
                Id = 2,
                Name = "SuperAdmin",
                Email = "super@super.com",
                Role="Super",
                Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });
        }
    }
}
