using Ds.Business.Interfaces;
using Ds.Business.Models;
using Ds.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ds.Business.Services
{
    public class PeriodoService : BaseService, IPeriodoService
    {
        private readonly IPeriodoRepository  _periodoRepository;
        public PeriodoService(INotificador notificador,IPeriodoRepository periodoRepository) : base(notificador)
        {
            _periodoRepository = periodoRepository;
        }

        public async Task Adicionar(Periodo periodo)
        {
            if (!ExecutarValidacao(new PeriodoValidation(), periodo)) return;

            if (_periodoRepository.Buscar(c => c.NomePeriodo==periodo.NomePeriodo).Result.Any())
            {
                Notificar("Já existe um  período com este nome");
                return;
            }
            await _periodoRepository.Adicionar(periodo);
        }

        public async Task Atualizar(Periodo periodo)
        {
            if (!ExecutarValidacao(new PeriodoValidation(), periodo)) return;

            if (_periodoRepository.Buscar(c => c.NomePeriodo == periodo.NomePeriodo && c.Id != periodo.Id).Result.Any())
            {
                Notificar("Já existe um  período com este nome");
                return;
            }

            await _periodoRepository.Atualizar(periodo);
        }

        public async Task Remover(Guid id)
        {
            if (_periodoRepository.ObterNotasPeriodo(id).Result.Nota.Any())
            {
                Notificar("Existe Notas Cadastradas para essa Disciplina");
                return;
            }
            await _periodoRepository.Remover(id);
        }

        public void Dispose()
        {
            _periodoRepository.Dispose();
        }
    }
}
