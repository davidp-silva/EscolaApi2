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
    public class DiarioRepository : Repository<Diario>,IDiarioRepository
    {
        public DiarioRepository(EscolaContext db) : base(db)
        {
        }
        public async Task<IEnumerable<Diario>> QuantidadedeFaltasporAluno(Guid idAluno)
        {
            return await Db.Diarios.AsNoTracking()
            .Include(p => p.Aluno)
            .Where(p => p.AlunoId == idAluno).ToListAsync();

        }

        public async Task<IEnumerable<Diario>> QuantidadedeFaltasporMateria(Guid materiaId)
        {
            return await Db.Diarios.AsNoTracking()
                 .Include(p => p.Disciplina)
                 .Where(p => p.DisciplinaId == materiaId).ToListAsync();
        }
    }
}
