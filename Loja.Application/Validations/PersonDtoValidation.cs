using FluentValidation;
using Loja.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Validations
{
    public class PersonDtoValidation : AbstractValidator<PersonDto>
    {
        public PersonDtoValidation()
        {
            RuleFor(x => x.CPF).NotEmpty().NotNull().WithMessage("Documento deve ser Informado!");
            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("Nome deve ser Informado!");
            RuleFor(x => x.Telefone).NotEmpty().NotNull().WithMessage("Telefone deve ser Informado!");
        }
    }
}
