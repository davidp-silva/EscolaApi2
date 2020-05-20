using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ds.App.ViewModels;
using Ds.Api.Controllers;
using Ds.Business.Interfaces;
using AutoMapper;
using Ds.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Ds.Api.Extensions;

namespace Ds.Api.Controllers
{
    [Route("api/alunos")]
    [Authorize]
    public class AlunosController : MainController
    {

      private readonly  IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        private readonly IAlunoService _alunoService;


        public AlunosController(IAlunoRepository alunoRepository, IMapper mapper, INotificador notificador,
              IAlunoService alunoService)  : base(notificador)
        {
            _alunoRepository = alunoRepository;
            _alunoService = alunoService;
            _mapper = mapper;

        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<AlunoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AlunoViewModel>>(await _alunoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<AlunoViewModel>> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return (_mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id)));
        }

        [HttpPost]
        [ClaimsAuthorize("Alunos","Ad")]
        public async Task<ActionResult> Create([Bind("Id,NomeCompleto,Documento,Ativo,DataNascimento,Telefone")] AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var aluno = _mapper.Map<Aluno>(alunoViewModel);

            await _alunoService.Adicionar(aluno);

            return CustomResponse(alunoViewModel);
        }

        [ClaimsAuthorize("Alunos", "Ed")]
        [HttpPut("{id:guid}")]
       
        public async Task<ActionResult<AlunoViewModel>> Edit(Guid id,AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(alunoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _alunoService.Atualizar(_mapper.Map<Aluno>(alunoViewModel));

            return CustomResponse(alunoViewModel);
        }

        [ClaimsAuthorize("Alunos", "Dl")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AlunoViewModel>> DeleteConfirmed(Guid id)
        {
            var alunoViewModel = _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id));

            if (alunoViewModel == null) return NotFound();

            await _alunoService.Remover(id);

            return CustomResponse(alunoViewModel);

        }
    }
}
