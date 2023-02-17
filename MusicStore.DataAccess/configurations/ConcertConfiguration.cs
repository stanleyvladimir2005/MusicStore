using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;

namespace MusicStore.DataAccess.configurations
{
    public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder.Property(con => con.Title)
             .HasMaxLength(100);

            builder.Property(con => con.Description)
                .HasMaxLength(500);

            builder.Property(con => con.Place)
                .HasMaxLength(100);

            builder.Property(con => con.ImageUrl)
                .IsUnicode(false)
                .HasMaxLength(1000);

            builder.Property(con => con.UnitPrice)
                .HasPrecision(11, 2);

            // Por si quieres personalizarla fecha y la hora.
            //builder.Property(p => p.DateEvent)
            //    .HasColumnType("DATE");
        }
    }
}
