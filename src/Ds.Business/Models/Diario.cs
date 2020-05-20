using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models
{
    public class Diario: Entity
    {
        public DateTime Data { get; set; }
        public Guid DisciplinaId { get; set; }

        public Aluno Aluno { get; set; }

        public Disciplina Disciplina { get; set; }

        public Guid AlunoId { get; set; }

        public bool Presenca { get; set; }


    }
}
