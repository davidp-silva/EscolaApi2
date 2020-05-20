using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data.Mappings
{
    class TurmaAlunoMappings : IEntityTypeConfiguration<TurmaAluno>
    {
        public void Configure(EntityTypeBuilder<TurmaAluno> builder)
        {
            builder.HasOne(p => p.Turmas)
                .WithMany(p => p.TurmaAlunos)
                .HasForeignKey(p => p.TurmaId);

            builder.HasOne(p => p.Alunos)
                .WithMany(p => p.TurmaAlunos)
                .HasForeignKey(p => p.AlunoId);

            builder.ToTable("TurmasAlunos");
                
        }
    }
}
