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
    public class DisciplinaProfessorRepository : Repository<DisciplinaProfessor>, IDisciplinaProfessorRepository
    {
        public DisciplinaProfessorRepository(EscolaContext db) : base(db){}

        public async Task<IEnumerable<DisciplinaProfessor>> ObterProfessorDisciplina(Guid idProfessor)
        {
            return await Db.DisciplinaProfessores.AsNoTracking()
                .Include(p => p.Disciplinas)
                .Include(p => p.Professores)
                .Where(p => p.ProfessorId == idProfessor).ToListAsync();
        }
    }
}
