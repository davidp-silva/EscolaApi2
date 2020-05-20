using System;

namespace Ds.Business.Models
{
    public class DisciplinaProfessor:Entity
    {
        public Professor Professores { get; set; }

        public Guid ProfessorId { get; set; }

        public Disciplina Disciplinas { get; set; }

        public Guid DisciplinaId { get; set; }
    }
}