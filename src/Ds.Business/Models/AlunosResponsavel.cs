using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models
{
    public class AlunosResponsavel : Entity
    {

        public Guid AlunoId { get; set; }

        public Aluno Alunos { get; set; }

        public Guid ResponsavelId { get; set; }

        public Responsavel Responsaveis { get; set; }
    }
}
