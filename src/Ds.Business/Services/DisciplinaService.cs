using Ds.Business.Interfaces;
using Ds.Business.Models;
using Ds.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ds.Business.Services
{
    public class DisciplinaService : BaseService, IDisciplinaService 
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        public DisciplinaService(INotificador notificador,IDisciplinaRepository disciplinaRepository) : base(notificador)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task Adicionar(Disciplina disciplina)
        {
            if (!ExecutarValidacao(new DisciplinaValidation(), disciplina)) return;

            if (_disciplinaRepository.Buscar(c => c.NomeDisciplina == disciplina.NomeDisciplina).Result.Any())
            {
                Notificar("Já existe uma disciplina com este nome");
                return;
            }
            await _disciplinaRepository.Adicionar(disciplina);
        }

        public async Task Atualizar(Disciplina disciplina)
        {
            if (!ExecutarValidacao(new DisciplinaValidation(), disciplina)) return;

            if (_disciplinaRepository.Buscar(c => c.NomeDisciplina ==disciplina.NomeDisciplina && c.Id != disciplina.Id).Result.Any())
            {
                Notificar("Já existe uma disciplina com este nome.");
                return;
            }

            await _disciplinaRepository.Atualizar(disciplina);
        }

     

        public async Task Remover(Guid id)
        {
            
            if (_disciplinaRepository.VerificarNotasDisciplina(id).Result.Nota.Any())            
            {
                Notificar("Existe Nota(s) Cadastrada(s) para essa Disciplina");
                return;
            }
            

            await _disciplinaRepository.Remover(id);
        }

        public void Dispose()
        {
            _disciplinaRepository?.Dispose();
        }

        public async Task<Disciplina> VerificarNotasDisciplina(Guid idDisciplina)
        {
           return  await _disciplinaRepository.VerificarNotasDisciplina(idDisciplina);
        }

        public async Task<Disciplina> ObterPorId(Guid id)
        {
            return await _disciplinaRepository.ObterPorId(id);
        }

        public async Task<List<Disciplina>> ObterTodos()
        {
            return await _disciplinaRepository.ObterTodos();
        }

        public async Task<IEnumerable<Disciplina>> Buscar(Expression<Func<Disciplina, bool>> predicate)
        {
            return await _disciplinaRepository.Buscar(predicate);
        }

        public Task<int> SaveChanges()
        {
            return _disciplinaRepository.SaveChanges();
        }
    }
}
