using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ds.Business.Models;

namespace Ds.Business.Interfaces
{
 public   interface ISerieRepository : IRepository<Serie>
    {
        Task<IEnumerable< Serie>> ObterTurmasSerie( Guid serieId);
    }
}
