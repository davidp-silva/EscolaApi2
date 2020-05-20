using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ds.Business.Models;

namespace Ds.Business.Interfaces
{
    public interface IResponsavelRepository : IRepository<Responsavel>
    {
      //  Task<IEnumerable< Responsavel>> ObterAlunosdoResponsavel(Guid responsavelId);
        Task<Responsavel> ObterEnderecoResponsavel(Guid responsavelId);
    }
}
