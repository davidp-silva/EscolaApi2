using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models
{
  public  class Pessoa :Entity
    {
        public string NomeCompleto { get; set; }

        public string Documento { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataNascimento { get; set; }

        public Endereco Endereco { get; set; }

        public string Telefone { get; set; }


    }
}
