using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanArch.Infra.Data.EntityConfigurations;
using CleanArch.Infra.Data.Identity;

namespace CleanArch.Infra.Data.Context  
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
       public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfiguration());
        }
    }

}
