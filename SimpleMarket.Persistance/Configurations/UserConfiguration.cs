using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMarket.Persistance.Entities;

namespace SimpleMarket.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        
        builder.HasMany(u => u.Cards)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId);

        builder.HasMany(u => u.Feedbacks).
            WithOne(f => f.User)
            .HasForeignKey(f => f.UserId);

        builder.HasMany(u => u.Addresses)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserID);
        
        builder.HasOne(u => u.History)
            .WithOne(h => h.User)
            .HasForeignKey<UserEntity>(u => u.HistoryId)
            .HasForeignKey<HistoryEntity>(h => h.UserId);
        
        builder.HasOne(u => u.Favourite)
            .WithOne(f => f.User)
            .HasForeignKey<UserEntity>(u => u.FavouriteId)
            .HasForeignKey<FavouriteEntity>(f => f.UserId);
        
        builder.HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<UserEntity>(u => u.CartId)
            .HasForeignKey<CartEntity>(c => c.UserId);
    }
}