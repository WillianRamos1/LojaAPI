using FluentValidation;
using Loja.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Validations
{
    public class CompraDtoValidation : AbstractValidator<CompraDto>
    {
        public CompraDtoValidation()
        {
            RuleFor(x => x.CodErp).NotEmpty().NotNull().WithMessage("Codigo ERP deve ser informado.");
            RuleFor(x => x.Documento).NotEmpty().NotNull().WithMessage("Documento deve ser informado.");
        }
    }
}
