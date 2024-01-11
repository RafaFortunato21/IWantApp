using IWantApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    public DbSet<Product> Products;
    public DbSet<Category> Categories;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Product>().Property(p => p.Name).IsRequired();
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(255);

        builder.Entity<Category>().Property(c => c.Name).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<string>()
            .HaveMaxLength(100);
    }

}
