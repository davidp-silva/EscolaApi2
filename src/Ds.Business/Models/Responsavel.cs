using System.Collections.Generic;

namespace Ds.Business.Models
{
    public class Responsavel :Pessoa
    {
        public string GrauParentesco { get; set; }

        public IEnumerable<AlunosResponsavel> AlunosResponsaveis { get; set; }
    }
}