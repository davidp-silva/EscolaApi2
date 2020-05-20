using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ds.Business.Models;

namespace Ds.Business.Interfaces
{
  public  interface IProfessorRepository :IRepository<Professor>
    {
        Task <IEnumerable<Professor>> ObterProfessoresdaDisciplina(Guid disciplinaId);
    }
}
