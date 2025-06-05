using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Total)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();



            builder.Property(i => i.UserId).IsRequired();
            builder.HasMany(i => i.InvoiceProducts)
                   .WithOne(ip => ip.Invoice)
                   .HasForeignKey(ip => ip.InvoiceId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
