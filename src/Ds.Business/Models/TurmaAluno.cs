using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models
{
    public class TurmaAluno :Entity
    {
        public Guid TurmaId { get; set; }

        public Turma Turmas { get; set; }

        public Guid AlunoId { get; set; }

        public Aluno Alunos { get; set; }
    }
}
