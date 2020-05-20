using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models
{
   public class Aluno :Pessoa
    {
        
        public IEnumerable<AlunosResponsavel> AlunoResponsaveis { get; set; }

        public Diario Diario { get; set; }

        public IEnumerable<Nota> Nota { get; set; }

        public  IEnumerable<TurmaAluno> TurmaAlunos { get; set; }
    }
}


