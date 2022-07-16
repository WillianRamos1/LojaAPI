using AutoMapper;
using Loja.Application.Contratos;
using Loja.Application.Dtos;
using Loja.Application.Service;
using Loja.Application.Validations;
using Loja.Domain.Entidades;
using Loja.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepositorio produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ICollection<ProdutoDto>>> GetAllAsync()
        {
            var products = await _produtoRepository.BuscarProdutos();
            return ResultService.OK<ICollection<ProdutoDto>>(_mapper.Map<ICollection<ProdutoDto>>(products));
        }

        public async Task<ResultService<ProdutoDto>> GetByIdAsync(int id)
        {
            var product = await _produtoRepository.BuscarProdutoById(id);
            if (product == null) return ResultService.Fail<ProdutoDto>("Produto Não Encontrado");
            return ResultService.OK<ProdutoDto>(_mapper.Map<ProdutoDto>(product));
        }

        public async Task<ResultService<ProdutoDto>> CreateAsync(ProdutoDto produto)
        {
            if (produto == null) return ResultService.Fail<ProdutoDto>("Objeto deve ser Informado.");

            var result = new ProdutoDtoValidation().Validate(produto);
            if (!result.IsValid)
                return ResultService.RequestError<ProdutoDto>("Problemas na Validação", result);

            var product = _mapper.Map<Produto>(produto);
            var data = await _produtoRepository.CriarProduto(product);
            return ResultService.OK<ProdutoDto>(_mapper.Map<ProdutoDto>(data));
        }

        public async Task<ResultService> UpdateAsync(ProdutoDto produto)
        {
            if(produto == null) return ResultService.Fail<ProdutoDto>("Objeto deve ser Informado.");

            var validar = new ProdutoDtoValidation().Validate(produto);
            if (validar.IsValid) return ResultService.RequestError("Problemas com a Validação dos Campos", validar);

            var product = await _produtoRepository.BuscarProdutoById(produto.Id);
            if(product == null) return ResultService.Fail("Produto Não Encontrado");

            product = _mapper.Map<ProdutoDto, Produto>(produto, product);
            await _produtoRepository.EditarProduto(product);
            return ResultService.OK("Edição Feita com Sucesso.");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var product = await _produtoRepository.BuscarProdutoById(id);
            if (product == null) return ResultService.Fail("Produto Não Encontrado");

            await _produtoRepository.DeletarProduto(product);
            return ResultService.OK($"O Produto ID: {id} foi removido.");
        }
    }
}
