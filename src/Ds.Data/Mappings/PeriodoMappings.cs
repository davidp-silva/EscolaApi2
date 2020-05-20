using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data.Mappings
{
    class PeriodoMappings : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomePeriodo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Periodos");

        }
    }
}
