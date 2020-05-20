using System.Collections.Generic;

namespace Ds.Business.Models
{
   public class Serie:Entity
    {
        public  string NomeSerie { get; set; }

        public IEnumerable<Turma> Turmas{ get; set; }
    }
}
