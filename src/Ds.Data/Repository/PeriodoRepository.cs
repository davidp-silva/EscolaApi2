using Ds.Business.Interfaces;
using Ds.Business.Models;
using Ds.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Data.Repository
{
    public class PeriodoRepository : Repository<Periodo>, IPeriodoRepository
    {
        public PeriodoRepository(EscolaContext db) : base(db) { }

        public async Task<Periodo> ObterNotasPeriodo(Guid periodoId)
        {
            return await Db.Periodos.AsNoTracking()
                .Include(p => p.Nota).FirstOrDefaultAsync(c => c.Id == periodoId);
        }
    }
}
