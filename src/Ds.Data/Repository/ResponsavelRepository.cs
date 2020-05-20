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
    public class ResponsavelRepository : Repository<Responsavel>, IResponsavelRepository
    {
        public ResponsavelRepository(EscolaContext db) : base(db){ }

        public async Task<Responsavel> ObterEnderecoResponsavel(Guid responsavelId)
        {
            return await Db.Responsaveis.AsNoTracking().Include(p => p.Endereco)
                .SingleOrDefaultAsync(p => p.Id == responsavelId);
        }
    }
}
