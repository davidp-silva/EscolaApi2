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
    public class SerieRepository : Repository<Serie>, ISerieRepository
    {
        public SerieRepository(EscolaContext db) : base(db){ }

        public async Task<IEnumerable<Serie>> ObterTurmasSerie(Guid serieId)
        {
            return await Db.Series.AsNoTracking()
                .Include(p => p.Turmas)
                .Where(p => p.Id == serieId).ToListAsync();
        }
    }
}
