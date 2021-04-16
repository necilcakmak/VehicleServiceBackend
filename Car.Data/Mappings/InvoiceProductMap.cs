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
    public class InvoiceProductMap : IEntityTypeConfiguration<InvoiceProduct>
    {
        public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.CreatedDate).IsRequired();

            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.Property(c => c.Quantity).IsRequired();

            builder.Property(c => c.TotalPrice).IsRequired();

            builder.Property(c => c.SubTotal).IsRequired();

            builder.Property(c => c.TotalTax).IsRequired();

            builder.HasOne<Invoice>(a => a.Invoice).WithMany(c => c.InvoiceProducts).HasForeignKey(a => a.InvoiceId);

            builder.ToTable("InvoiceProducts");
        }
    }
}
