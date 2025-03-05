using Microsoft.EntityFrameworkCore;
using SimpleMarket.Persistance.Configurations;
using SimpleMarket.Persistance.Entities;

namespace SimpleMarket.Persistance;

public class SimpleMarketDbContext(DbContextOptions<SimpleMarketDbContext> options) : DbContext(options)
{
    public DbSet<AddressEntity>? Addresses { get; set; }
    public DbSet<CardEntity>? Cards { get; set; } 
    public DbSet<CartEntity>? Carts { get; set; } 
    public DbSet<CategoryEntity>? Categories { get; set; } 
    public DbSet<FavouriteEntity>? Favourites { get; set; }
    public DbSet<FeedbackEntity>? Feedbacks { get; set; }
    public DbSet<HistoryEntity>? Histories { get; set; }
    public DbSet<ProductEntity>? Products { get; set; }
    public DbSet<UserEntity>? Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new CardConfiguration());
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new FavouriteConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new HistoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}