using Ds.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Business.Interfaces
{
   public interface IAlunoRepository : IRepository<Aluno>
    {
       Task<Aluno>  ObterAlunoEndereco(Guid idAluno);

        Task<Aluno> ObterAlunoNotaCadastrada(Guid idAluno);
    }
}
