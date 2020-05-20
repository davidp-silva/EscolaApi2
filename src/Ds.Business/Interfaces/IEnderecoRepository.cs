using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ds.Business.Models;

namespace Ds.Business.Interfaces
{
  public  interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorPessoa(Guid pessoaId);
    }
}
