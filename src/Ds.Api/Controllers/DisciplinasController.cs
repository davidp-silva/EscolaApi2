using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ds.App.ViewModels;
using Ds.Business.Interfaces;
using AutoMapper;
using Ds.Business.Models;
using Ds.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Ds.Api.Extensions;

namespace Ds.App.Controllers
{
    [Route("api/disciplinas")]
    [Authorize]
    public class DisciplinasController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinasController(IMapper mapper, IDisciplinaService disciplinaService, INotificador notificador): base(notificador)
        {

            _mapper = mapper;
            _disciplinaService = disciplinaService;
        }

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<DisciplinaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<DisciplinaViewModel>>(await _disciplinaService.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<DisciplinaViewModel>> ObterPorId(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return await ObterDisciplina(id);
        }

     
        [HttpPost]
        [ClaimsAuthorize("Disciplinas", "Ad")]
        public async Task<ActionResult<DisciplinaViewModel>> Create(DisciplinaViewModel disciplinaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var aluno = _mapper.Map<Disciplina>(disciplinaViewModel);
            await _disciplinaService.Adicionar(aluno);

            //if (!OperacaoValida()) return View(disciplinaViewModel);

            return RedirectToAction("Index");
        }

        [HttpPut("{id:guid}")]
        [ClaimsAuthorize("Disciplinas", "Ed")]
        public async Task<ActionResult<DisciplinaViewModel>> Edit(Guid id,DisciplinaViewModel disciplinaViewModel)
        {
            if (id != disciplinaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(disciplinaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _disciplinaService.Atualizar(_mapper.Map<Disciplina>(disciplinaViewModel));

            return CustomResponse(disciplinaViewModel);

        }
       
        [HttpDelete]
        [ClaimsAuthorize("Disciplinas", "Dl")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var disciplinaViewModel = await ObterDisciplina(id);

            if (disciplinaViewModel == null) return NotFound();

            await _disciplinaService.Remover(id);

            return CustomResponse(disciplinaViewModel);
        }

        private async Task<DisciplinaViewModel> ObterDisciplina(Guid id)
        {
            return _mapper.Map<DisciplinaViewModel>(await _disciplinaService.ObterPorId(id));
        }

    }
}
