using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        builder.HasMany(p => p.Feedbacks)
            .WithOne(f => f.Product)
            .HasForeignKey(f => f.ProductId);

        builder.HasMany(p => p.Histories)
            .WithOne(h => h.Product)
            .HasForeignKey(h => h.ProductId);
    }
}