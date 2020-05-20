using Ds.Business.Interfaces;
using Ds.Business.Models;
using Ds.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ds.Business.Services
{
    public class NotaService : BaseService, INotaService
    {
        private readonly INotaRepository _notaRepository;
        public NotaService(INotificador notificador,INotaRepository notaRepository) : base(notificador)
        {
            _notaRepository = notaRepository;
        }

        public async Task Adicionar(Nota nota)
        {
            if (!ExecutarValidacao(new NotaValidation(), nota)) return;

            if (_notaRepository.Buscar(c => c.AlunoId==nota.AlunoId && c.DisciplinaId==nota.DisciplinaId && c.PeriodoId ==nota.PeriodoId).Result.Any())
            {
                Notificar("Já existe uma nota lançada com essas informações.");
                return;
            }

            await _notaRepository.Adicionar(nota);
        }

        public async Task Atualizar(Nota nota)
        {
            if (!ExecutarValidacao(new NotaValidation(), nota)) return;

            if (_notaRepository.Buscar( c=> c.AlunoId == nota.AlunoId && c.DisciplinaId == nota.DisciplinaId && c.PeriodoId == nota.PeriodoId && c.Id != nota.Id).Result.Any())
            {
                Notificar("Já existe uma nota lançada com essas informações.");
                return;
            }

            await _notaRepository.Atualizar(nota);
        }

      

        public async Task Remover(Guid id)
        {
            if (_notaRepository.VerificarAlunoAtivo(id) == null)
            {
                Notificar("Nota não pode ser excluida para aluno desativado.");
                return;
            }
            await _notaRepository.Remover(id);
        }

        public void Dispose()
        {
            _notaRepository?.Dispose();
        }
    }
}
