using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data.Mappings
{
    class DiarioMappings : IEntityTypeConfiguration<Diario>
    {
        public void Configure(EntityTypeBuilder<Diario> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Data).IsRequired();

            builder.HasOne(p => p.Aluno)
                .WithOne(e => e.Diario);

            builder.HasOne(p => p.Disciplina)
                .WithOne(e => e.Diario);

            builder.ToTable("Diarios");

        }
    }
}
