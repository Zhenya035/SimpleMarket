using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Models;
using SimpleMarket.Persistance.Configurations;

namespace SimpleMarket.Persistance;

public class SimpleMarketDbContext(DbContextOptions<SimpleMarketDbContext> options) : DbContext(options)
{
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Cart>? Carts { get; set; } 
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Feedback>? Feedbacks { get; set; }
    public DbSet<History>? Histories { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<User>? Users { get; set; }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new HistoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}