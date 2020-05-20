using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ds.Business.Models;

namespace Ds.Business.Interfaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<IEnumerable<Turma>> ObterListadeAlunosTurma(Guid turmaId);
    }
}
