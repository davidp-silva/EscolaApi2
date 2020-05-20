using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ds.Business.Models.Validations
{
    public class AlunoValidation : AbstractValidator<Aluno>
    {
        public AlunoValidation()
        {
            RuleFor(f => f.NomeCompleto)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(f => f.DataNascimento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.DataNascimento).LessThan(DateTime.Now)
                .WithMessage("O campo {PropertyName} precisa ser menor que a data atual");

            RuleFor(f => f.Documento)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Telefone)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 100)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
