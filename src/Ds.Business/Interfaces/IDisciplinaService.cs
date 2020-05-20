using Ds.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Business.Interfaces
{
  public  interface IDisciplinaService : IDisposable,IRepository<Disciplina>
    {
        Task<Disciplina> VerificarNotasDisciplina(Guid idDisciplina);


    }
}
