using AutoMapper;
using Loja.Application.Dtos;
using Loja.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Helpers
{
    public class DomainMapping : Profile
    {
        public DomainMapping()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<Compra, CompraDto>().ReverseMap();
            CreateMap<Compra, DetalhesCompraDto>().ForMember(x => x.Person, opt => opt.Ignore()).ForMember(x => x.Produto, opt => opt.Ignore()).ConstructUsing((model, context) => 
            {
                var dto = new DetalhesCompraDto
                {
                    Produto = model.Produto.NomeProduto,
                    Id = model.Id,
                    Data = model.Data,
                    Person = model.Person.Nome,
                };
                return dto;
            });
        }
    }
}
