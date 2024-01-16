namespace IWantApp.Infra.Data.Context;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }


    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Order> Order { get; set; }

     

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();
        builder.Entity<Product>().Property(p => p.Name).IsRequired();
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(255);
        
        builder.Entity<Order>().Property(p => p.ClientId).IsRequired();
        builder.Entity<Order>().Property(p => p.DeliveryAddress).IsRequired();

        builder.Entity<Order>().HasMany(p => p.Products)
                               .WithMany(p => p.Orders)
                               .UsingEntity(x => x.ToTable("OrderProduct"));

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<string>()
            .HaveMaxLength(100);
    }

}
