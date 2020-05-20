using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ds.Business.Models;

namespace Ds.Business.Interfaces
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        Task<Disciplina> VerificarNotasDisciplina(Guid idDisciplina);
    }
}
