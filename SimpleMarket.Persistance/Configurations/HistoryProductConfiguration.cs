using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Configurations;

public class HistoryProductConfiguration : IEntityTypeConfiguration<HistoryProduct>
{
    public void Configure(EntityTypeBuilder<HistoryProduct> builder)
    {
        builder.HasKey(hp => hp.Id);
        builder.Property(hp => hp.Id).IsRequired();
        
        builder.HasOne(hp => hp.Product)
            .WithMany(p => p.Histories)
            .HasForeignKey(hp => hp.ProductId);
        
        builder.HasOne(hp => hp.History)
            .WithMany(h => h.Products)
            .HasForeignKey(hp => hp.HistoryId);
    }
}