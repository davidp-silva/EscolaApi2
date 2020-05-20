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
    [Route("api/periodos")]
    [Authorize]
    public class PeriodosController : MainController
    {
       private readonly IPeriodoRepository _periodoRepository;
        private readonly IMapper _mapper;
        private readonly IPeriodoService _periodoService;

        public PeriodosController(IMapper mapper, IPeriodoRepository periodoRepository
            , INotificador notificador, IPeriodoService periodoService) : base(notificador)
        {
            _mapper = mapper;
            _periodoRepository = periodoRepository;
            _periodoService = periodoService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<PeriodoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PeriodoViewModel>>(await _periodoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<PeriodoViewModel>> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return _mapper.Map<PeriodoViewModel>(await _periodoRepository.ObterPorId(id));
        }

        [HttpPost]
        [ClaimsAuthorize("Periodos", "Ad")]
        public async Task<IActionResult> Create([Bind("Id,Adicionar")] PeriodoViewModel periodoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _periodoService.Adicionar(_mapper.Map<Periodo>(periodoViewModel));

            return CustomResponse(periodoViewModel);
        }

        [HttpPut("{id:guid}")]
        [ClaimsAuthorize("Periodos", "Ed")]
        public async Task<IActionResult> Edit(Guid id,PeriodoViewModel periodoViewModel)
        {
            if (id != periodoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(periodoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _periodoService.Atualizar(_mapper.Map<Periodo>(periodoViewModel));

            return CustomResponse(periodoViewModel);
        }

        [HttpDelete("{id:guid}")]
        [ClaimsAuthorize("Periodos", "Dl")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var periodoViewModel = _mapper.Map<PeriodoViewModel>(await _periodoRepository.ObterPorId(id));

            if (periodoViewModel == null) return NotFound();

            await _periodoService.Remover(id);

            return CustomResponse(periodoViewModel);
        }
    }
}
