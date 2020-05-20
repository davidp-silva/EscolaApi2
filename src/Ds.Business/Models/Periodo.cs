using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models
{
   public class Periodo :Entity
    {
        public string NomePeriodo { get; set; }

        public IEnumerable< Nota> Nota { get; set; }
    }
}
