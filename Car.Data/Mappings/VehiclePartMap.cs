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
    public class VehiclePartMap : IEntityTypeConfiguration<VehiclePart>
    {
        public void Configure(EntityTypeBuilder<VehiclePart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.CreatedDate).IsRequired();

            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.Property(c => c.IsActive).IsRequired();

            builder.Property(c => c.PartType).HasMaxLength(100);
            builder.Property(c => c.PartType).IsRequired();

            builder.Property(c => c.PartCode).HasMaxLength(100);
            builder.Property(c => c.PartCode).IsRequired();

            builder.Property(c => c.TaxStatus).HasMaxLength(100);
            builder.Property(c => c.TaxStatus).IsRequired();


            builder.Property(c => c.Stock).IsRequired();

            builder.Property(c => c.TaxRate).IsRequired();

            builder.Property(c => c.BuyPrice).IsRequired();

            builder.Property(c => c.SellPrice).IsRequired();

            builder.ToTable("VehicleParts");
            builder.HasData(new VehiclePart
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                PartType = "Akü",
                PartCode = "A81",
                TaxStatus = "Yüksek",
                Stock = 50,
                TaxRate = 18,
                BuyPrice = 300,
                SellPrice = 400,
                IsActive=true,
                VehicleId = 1
            },
           new VehiclePart
           {
               Id = 2,
               CreatedDate = DateTime.Now,
               ModifiedDate = DateTime.Now,
               PartType = "Cam",
               PartCode = "C54",
               TaxStatus = "Orta",
               Stock = 1000,
               TaxRate = 15,
               BuyPrice = 700,
               IsActive = true,
               SellPrice = 850,
               VehicleId = 2
           }, new VehiclePart
           {
               Id = 3,
               CreatedDate = DateTime.Now,
               ModifiedDate = DateTime.Now,
               PartType = "Jant",
               PartCode = "J34",
               TaxStatus = "Yüksek",
               Stock = 1000,
               TaxRate = 25,
               BuyPrice = 200,
               SellPrice = 400,
               IsActive = true,
               VehicleId = 3
           }, new VehiclePart
           {
               Id = 4,
               CreatedDate = DateTime.Now,
               ModifiedDate = DateTime.Now,
               PartType = "Silecek",
               PartCode = "S11",
               TaxStatus = "Yüksek",
               Stock = 1000,
               TaxRate = 10,
               BuyPrice = 50,
               SellPrice = 65,
               IsActive = true,
               VehicleId = 2
           });
        }
    }
}
