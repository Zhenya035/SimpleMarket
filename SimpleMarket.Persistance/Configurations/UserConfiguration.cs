using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMarket.Persistance.Entities;

namespace SimpleMarket.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
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
            .HasForeignKey<History>(h => h.UserId)
            .HasForeignKey<User>(u => u.HistoryId);
        
        builder.HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<User>(u => u.CartId)
            .HasForeignKey<Cart>(c => c.UserId);
    }
}