using FluentValidation;
using Loja.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Validations
{
    public class ProdutoDtoValidation : AbstractValidator<ProdutoDto>
    {
        public ProdutoDtoValidation()
        {
            RuleFor(x => x.CodErp).NotEmpty().NotNull().WithMessage("Codigo ERP deve ser Informado!");
            RuleFor(x => x.NomeProduto).NotEmpty().NotNull().WithMessage("Nome do Produto deve ser Informado!");
            RuleFor(x => x.Preco).GreaterThan(0).WithMessage("Preço deve ser maior que Zero!");
        }
    }
}
