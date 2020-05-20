using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data.Mappings
{
    class DisciplinaProfessorMappings : IEntityTypeConfiguration<DisciplinaProfessor>
    {
        public void Configure(EntityTypeBuilder<DisciplinaProfessor> builder)
        {
            builder.HasOne(p => p.Disciplinas)
                .WithMany(p => p.DisciplinaProfessores)
                .HasForeignKey(p => p.DisciplinaId);

            builder.HasOne(p => p.Professores)
                .WithMany(p => p.DisciplinaProfessor)
                .HasForeignKey(p => p.ProfessorId);
        }
    }
}
