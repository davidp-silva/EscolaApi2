using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ds.App.ViewModels;
using Ds.Business.Interfaces;
using AutoMapper;
using Ds.Business.Models;
using Ds.Api.Controllers;
using Ds.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Ds.Api.Extensions;

namespace Ds.App.Controllers
{
    [Route("api/notas")]
    [Authorize]
    public class NotasController : MainController
    {
        private readonly INotaRepository _notaRepository;
        private readonly IMapper _mapper;
        private readonly INotaService _notaService;


        public NotasController(INotaRepository notaRepository, IMapper mapper,
            INotaService notaService, INotificador notificador)
            : base(notificador)
        {
            _notaRepository = notaRepository;
            _mapper = mapper;
            _notaService = notaService;

        }

        // GET: Notas
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<NotaViewModel>> ObterTodos()
        {
            var viewModel = _mapper.Map<IEnumerable<NotaViewModel>>(await _notaRepository.ObterTodos());
            return viewModel;
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<NotaViewModel>> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return (_mapper.Map<NotaViewModel>(await _notaRepository.ObterPorId(id)));
        }

        [ClaimsAuthorize("Notas", "Ad")]
        [HttpPost]
        public async Task<ActionResult<NotaViewModel>> Adicionar(NotaViewModel notaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _notaService.Adicionar(_mapper.Map<Nota>(notaViewModel));

            return CustomResponse(notaViewModel);
        }

        [HttpPut("{id:guid}")]
        [ClaimsAuthorize("Notas", "Ed")]
        public async Task<IActionResult> Edit(Guid id,NotaViewModel notaViewModel)
        {

            if (id != notaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(notaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _notaService.Atualizar(_mapper.Map<Nota>(notaViewModel));

            return CustomResponse(notaViewModel);
        }

        [HttpDelete("{id:guid}")]
        [ClaimsAuthorize("Notas", "Dl")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var notaViewModel = _mapper.Map<NotaViewModel>(await _notaRepository.ObterPorId(id));

            if (notaViewModel == null) return NotFound();

            await _notaService.Remover(id);

            return CustomResponse(notaViewModel);


        }
    }
}
