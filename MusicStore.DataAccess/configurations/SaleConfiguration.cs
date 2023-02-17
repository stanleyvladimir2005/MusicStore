using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.Property(p => p.OperationNumber)
            .IsUnicode(false)
            .HasMaxLength(20);

        builder.Property(p => p.Total)
            .HasPrecision(11, 2);

    }
}