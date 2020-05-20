using Ds.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Business.Interfaces
{
   public interface INotaService : IDisposable
    {
        Task Adicionar(Nota nota);
        Task Atualizar(Nota nota);
        Task Remover(Guid id);
    }
}
