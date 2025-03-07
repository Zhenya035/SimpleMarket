using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMarket.Persistance.Entities;

namespace SimpleMarket.Persistance.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasMany(c => c.Products)
            .WithMany(p => p.Carts);
        
        builder.HasOne(c => c.User)
            .WithOne(u => u.Cart)
            .HasForeignKey<User>(u => u.CartId)
            .HasForeignKey<Cart>(c => c.UserId);
    }
}