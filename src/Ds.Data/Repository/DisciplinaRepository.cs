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
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(EscolaContext db) : base(db) { }

        public async Task<Disciplina> VerificarNotasDisciplina(Guid idDisciplina)
        {
            return await Db.Disciplinas.AsNoTracking().
                Include(c => c.Nota).FirstOrDefaultAsync(c => c.Id == idDisciplina);
        }
    }
}
