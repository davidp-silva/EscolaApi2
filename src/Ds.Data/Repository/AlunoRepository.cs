using Ds.Business.Interfaces;
using Ds.Business.Models;
using Ds.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Data.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(EscolaContext db) : base(db)
        {

        }

        public async Task<Aluno> ObterAlunoEndereco(Guid id)
        {
            return await Db.Alunos.AsNoTracking()
                .Include(a => a.Endereco).FirstOrDefaultAsync(c => c.Id ==id);
        }

        public async Task<Aluno> ObterAlunoNotaCadastrada(Guid idAluno)
        {
            return await Db.Alunos.AsNoTracking()
                 .Include(a => a.Nota).FirstOrDefaultAsync(a => a.Id == idAluno);
                 
                 
        }
    }
}
