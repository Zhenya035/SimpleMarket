using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMarket.Persistance.Entities;

namespace SimpleMarket.Persistance.Configurations;

public class FavouriteConfiguration : IEntityTypeConfiguration<FavouriteEntity>
{
    public void Configure(EntityTypeBuilder<FavouriteEntity> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id).ValueGeneratedOnAdd();

        builder.HasOne(f => f.User)
            .WithOne(u => u.Favourite)
            .HasForeignKey<FavouriteEntity>(f => f.UserId)
            .HasForeignKey<UserEntity>(u => u.FavouriteId);
        
        builder.HasMany(f => f.Products)
            .WithMany(p => p.Favourites);
    }
}