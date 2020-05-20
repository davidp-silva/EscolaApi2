using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data.Mappings
{
    class TurmaDisciplinaMappings : IEntityTypeConfiguration<TurmaDisciplina>
    {
        public void Configure(EntityTypeBuilder<TurmaDisciplina> builder)
        {
            builder.HasOne(p => p.Disciplinas)
                .WithMany(p => p.TurmasDisciplinas)
                .HasForeignKey(p => p.DisciplinaId);

            builder.HasOne(p => p.Turmas)
                .WithMany(p => p.TurmaDisciplinas)
                .HasForeignKey(p => p.TurmaId);
        }
    }
}
