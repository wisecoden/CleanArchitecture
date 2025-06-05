using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class InvoiceProductConfiguration : IEntityTypeConfiguration<InvoiceProduct>
    {
        public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
        {
            builder.HasKey(ip => ip.Id);

            builder.Property(ip => ip.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(ip => ip.Quantity)
                   .IsRequired();

            builder.HasOne(ip => ip.Product)
                   .WithMany()
                   .HasForeignKey(ip => ip.ProductId);
        }
    }
}
