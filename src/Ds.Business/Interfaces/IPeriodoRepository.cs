using Ds.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Business.Interfaces
{
   public interface IPeriodoRepository:IRepository<Periodo>
    {
        Task<Periodo> ObterNotasPeriodo(Guid periodoId);
    }
}
