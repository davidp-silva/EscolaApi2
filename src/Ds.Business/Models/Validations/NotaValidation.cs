using FluentValidation;
using System.Data;

namespace Ds.Business.Models.Validations
{
    class NotaValidation : AbstractValidator<Nota>
    {
        public NotaValidation()
        {
            RuleFor(n => n.ValorNota).NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(n => n.AlunoId).NotEmpty()
                .WithMessage("O campo { PropertyName}precisa ser fornecido");

            RuleFor(n => n.DisciplinaId).NotEmpty()
               .WithMessage("O campo { PropertyName}precisa ser fornecido");

            RuleFor(n => n.PeriodoId).NotEmpty()
               .WithMessage("O campo { PropertyName}precisa ser fornecido");
        }
    }
}
