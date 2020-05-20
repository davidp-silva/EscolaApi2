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
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(EscolaContext db) : base(db){}

        public async Task<IEnumerable<Turma>> ObterListadeAlunosTurma(Guid turmaId)
        {
            return await Db.Turmas.AsNoTracking()
                  .Include(p => p.TurmaAlunos)
                  .Where(p => p.Id == turmaId).ToListAsync();            
        }
    }
}
