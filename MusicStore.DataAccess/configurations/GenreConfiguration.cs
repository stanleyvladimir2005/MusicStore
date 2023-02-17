using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DataAccess.configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(100);
            // .HasColumnName("T0001STR_NM")
            // builder.ToTable("T0001");

            // DataAccess Seeding para crear valores iniciales
            builder.HasData(
                new Genre { Id = 1, Name = "Rock" },
                new Genre { Id = 2, Name = "Pop" },
                new Genre { Id = 3, Name = "Metal" },
                new Genre { Id = 4, Name = "Reguea" },
                new Genre { Id = 5, Name = "Salsa" }
           );
        }
    }
}
