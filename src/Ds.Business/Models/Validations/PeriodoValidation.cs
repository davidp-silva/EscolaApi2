using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models.Validations
{
    class PeriodoValidation : AbstractValidator<Periodo>
    {
        public PeriodoValidation()
        {
            RuleFor(p => p.NomePeriodo )
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 100);
        }

    }
}
