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
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(EscolaContext db) : base(db){}

        public async Task<IEnumerable<Professor>> ObterProfessoresdaDisciplina(Guid disciplinaId)
        {
            return await Db.Professores.AsNoTracking()
                .Include(p => p.DisciplinaProfessor)
                .Where(p => ((DisciplinaProfessor)p.DisciplinaProfessor).DisciplinaId == disciplinaId).ToListAsync();
                
        }
    }
}
