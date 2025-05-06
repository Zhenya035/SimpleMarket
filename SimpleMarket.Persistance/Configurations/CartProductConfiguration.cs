using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Configurations;

public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
{
    public void Configure(EntityTypeBuilder<CartProduct> builder)
    {
        builder.HasKey(cp => cp.Id);
        builder.Property(cp => cp.CartId).IsRequired();
        
        builder.HasOne(c => c.Cart)
            .WithMany(c => c.Products)
            .HasForeignKey(c => c.CartId);
        
        builder.HasOne(c => c.Product)
            .WithMany(p => p.Carts)
            .HasForeignKey(c => c.ProductId);
    }
}