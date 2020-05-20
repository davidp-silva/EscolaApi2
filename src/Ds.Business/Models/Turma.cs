using System;
using System.Collections.Generic;

namespace Ds.Business.Models
{
    public class Turma:Entity
    {
        public string NomeTurma { get; set; }

        public Guid SerieId  { get; set; }
        public IEnumerable<TurmaDisciplina> TurmaDisciplinas { get; set; }

        public IEnumerable<TurmaAluno> TurmaAlunos { get; set; }

        public Serie Serie { get; set; }
    }
}