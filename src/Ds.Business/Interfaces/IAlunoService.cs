using Ds.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Business.Interfaces
{
   public interface IAlunoService : IDisposable
    {
        Task Adicionar(Aluno aluno);
        Task Atualizar(Aluno aluno);
        Task Remover(Guid id);
    }
}
