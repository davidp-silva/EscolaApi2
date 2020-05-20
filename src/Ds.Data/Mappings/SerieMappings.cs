using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data.Mappings
{
    class SerieMappings : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeSerie)
                .IsRequired()
                .HasColumnType("varchar(150)");
            builder.HasMany(p => p.Turmas)
                .WithOne(t => t.Serie)
                .HasForeignKey(p => p.SerieId);

            builder.ToTable("Series");
        }
    }
}
