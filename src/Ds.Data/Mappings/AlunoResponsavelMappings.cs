using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data.Mappings
{
    class AlunoResponsavelMappings : IEntityTypeConfiguration<AlunosResponsavel>
    {
        public void Configure(EntityTypeBuilder<AlunosResponsavel> builder)
        {
            builder.HasOne(p => p.Alunos)
                .WithMany(p => p.AlunoResponsaveis)
                .HasForeignKey(p => p.AlunoId);

            builder.HasOne(p => p.Responsaveis)
                .WithMany(p => p.AlunosResponsaveis)
                .HasForeignKey(p => p.ResponsavelId);
        }
    }
}
