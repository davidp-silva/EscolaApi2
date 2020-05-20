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
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(EscolaContext db) : base(db){ }

        public async Task<Pessoa> ObterEnderecoPessoa(Guid id)
        {
            return await Db.Pessoas.AsNoTracking().Include(p => p.Endereco)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
