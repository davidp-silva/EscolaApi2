using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Business.Models.Validations
{
    class DisciplinaValidation : AbstractValidator<Disciplina>
    {
        public DisciplinaValidation()
        {

            RuleFor(d => d.NomeDisciplina)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100);
        
        }
    }
}
