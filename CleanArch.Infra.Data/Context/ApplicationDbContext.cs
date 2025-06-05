using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanArch.Infra.Data.EntityConfigurations;
using CleanArch.Infra.Data.Identity;
using System.Reflection.Emit;

namespace CleanArch.Infra.Data.Context  
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
       public DbSet<Product> Products { get; set; }
       public DbSet<Category> Categories { get; set; }

       public DbSet<Invoice> Invoices { get; set; }
       public DbSet<InvoiceProduct> InvoiceProducts { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new InvoiceConfiguration());
            builder.ApplyConfiguration(new InvoiceProductConfiguration());
        }
    }

}
