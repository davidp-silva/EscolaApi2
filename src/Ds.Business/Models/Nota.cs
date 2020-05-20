using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models
{
   public class Nota :Entity
    {
        public decimal ValorNota { get; set; }

        public Guid DisciplinaId { get; set; }

        public Guid PeriodoId { get; set; }

        public Guid AlunoId { get; set; }

        public Disciplina Disciplina { get; set; }

        public Periodo Periodo { get; set; }
       
        public Aluno Aluno { get; set; }

    }
}
