using Ds.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Business.Interfaces
{
    public interface IDiarioRepository : IRepository<Diario>
    {
        Task <IEnumerable<Diario>> QuantidadedeFaltasporAluno (Guid idAluno);

        Task<IEnumerable<Diario>> QuantidadedeFaltasporMateria(Guid materiaId);


    }
}
