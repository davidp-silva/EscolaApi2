using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ds.Business.Models;

namespace Ds.Business.Interfaces
{
   public interface INotaRepository : IRepository<Nota>
    {
        Task< IEnumerable<Nota>> ObterNotaPorAluno(Guid idAluno);

        Task<Nota> VerificarAlunoAtivo(Guid idNota);
    }
}
