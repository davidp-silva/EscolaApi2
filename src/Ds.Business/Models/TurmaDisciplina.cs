using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models
{
    public class TurmaDisciplina :Entity
    {
        public Guid TurmaId { get; set; }
        public Turma Turmas { get; set; }

        public Guid DisciplinaId { get; set; }

        public Disciplina Disciplinas { get; set; }
    }
}
