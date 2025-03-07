using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleMarket.Persistance.Entities;

namespace SimpleMarket.Persistance.Configurations;

public class HistoryConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Id).ValueGeneratedOnAdd();

        builder.HasOne(h => h.User)
            .WithOne(u => u.History)
            .HasForeignKey<History>(h => h.UserId);
    }
}