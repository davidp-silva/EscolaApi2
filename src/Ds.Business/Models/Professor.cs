using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models
{
   public class Professor :Pessoa
    {
        public IEnumerable<DisciplinaProfessor> DisciplinaProfessor { get; set; }

        public string Registro { get; set; }
    }
}
