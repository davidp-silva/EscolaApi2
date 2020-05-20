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
 public    class NotaRepository : Repository<Nota>, INotaRepository
    {
        public NotaRepository(EscolaContext db) : base(db) { }

        public async Task<IEnumerable<Nota>> ObterNotaPorAluno(Guid idAluno)
        {
            return await Db.Notas.AsNoTracking().Include(p => p.Aluno)
                .Where(p => p.AlunoId == idAluno).ToListAsync();
        }

        public async override Task<List<Nota>> ObterTodos()
        {
            return  await Db.Notas.AsNoTracking().Include(p => p.Aluno)
                .Include(p => p.Disciplina)
                .Include(p => p.Periodo).ToListAsync();          
        }

        public async override Task<Nota> ObterPorId(Guid id)
        {
            return await Db.Notas.AsNoTracking().Include(p => p.Aluno)
                .Include(p => p.Disciplina)
                .Include(p => p.Periodo).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Nota> VerificarAlunoAtivo(Guid idNota)
        {
            return await Db.Notas.AsNoTracking().Include(p => p.Aluno)
                .Where(c => c.Aluno.Ativo == true & c.Id == idNota).FirstOrDefaultAsync();
        }
    }
}
