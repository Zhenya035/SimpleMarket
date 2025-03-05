using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMarket.Persistance.Entities;

namespace SimpleMarket.Persistance.Configurations;

public class HistoryConfiguration : IEntityTypeConfiguration<HistoryEntity>
{
    public void Configure(EntityTypeBuilder<HistoryEntity> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Id).ValueGeneratedOnAdd();
        
        builder.HasOne(h => h.User)
            .WithOne(u => u.History)
            .HasForeignKey<HistoryEntity>(h => h.UserId)
            .HasForeignKey<UserEntity>(u => u.HistoryId);
    }
}