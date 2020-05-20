using Ds.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Business.Interfaces
{
   public interface IPeriodoService : IDisposable
    {
        Task Adicionar(Periodo periodo);
        Task Atualizar(Periodo periodo);
        Task Remover(Guid id);
    }
}
