using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data.Mappings
{
    class DisciplinaMappings : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p=>p.NomeDisciplina)
                .IsRequired()
                 .HasColumnType("varchar(200)");
            
            builder.ToTable("Disciplinas");
        }
    }
}
