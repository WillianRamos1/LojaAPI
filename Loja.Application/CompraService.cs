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
    public class CompraService : ICompraService
    {
        private readonly ICompraRepositorio _compraRepository;
        private readonly IProdutoRepositorio _produtoRepository;
        private readonly IPersonRepositorio _personRepository;
        private readonly IMapper _mapper;

        public CompraService(ICompraRepositorio compraRepository, IProdutoRepositorio produtoRepository, IPersonRepositorio personRepository, IMapper mapper)
        {
            _compraRepository = compraRepository;
            _produtoRepository = produtoRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ICollection<DetalhesCompraDto>>> GetAllAsync()
        {
            var compra = await _compraRepository.BuscarCompras();
            return ResultService.OK(_mapper.Map<ICollection<DetalhesCompraDto>>(compra));
        }

        public async Task<ResultService<DetalhesCompraDto>> GetByIdAsync(int id)
        {
            var compra = await _compraRepository.BuscarComprasById(id);
            if (compra == null) return ResultService.Fail<DetalhesCompraDto>("Compra Não Encontrada");
            return ResultService.OK(_mapper.Map<DetalhesCompraDto>(compra));
        }

        public async Task<ResultService<CompraDto>> CreateAsync(CompraDto compra)
        {
            if(compra == null) return ResultService.Fail<CompraDto>("Objeto deve ser Informado.");

            var validate = new CompraDtoValidation().Validate(compra);
            if (!validate.IsValid)
                return ResultService.RequestError<CompraDto>("Problemas na Validação", validate);

            var product = await _produtoRepository.GetIdByCodErp(compra.CodErp);
            var person = await _personRepository.GetIdByDocumento(compra.Documento);
            var purchase = new Compra(product, person);

            var data = await _compraRepository.CriarCompra(purchase);
            compra.Id = data.Id;
            return ResultService.OK<CompraDto>(compra);
        }

        public async Task<ResultService> UpdateAsync(CompraDto compra)
        {
            if (compra == null) return ResultService.Fail<CompraDto>("Objeto deve ser Informado.");

            var validar = new CompraDtoValidation().Validate(compra);
            if (validar.IsValid) return ResultService.RequestError("Problemas com a Validação dos Campos", validar);

            var purchase = await _compraRepository.BuscarComprasById(compra.Id);
            if (purchase == null) return ResultService.Fail("Compra Não Encontrada");

            var produtoId = await _produtoRepository.GetIdByCodErp(compra.CodErp);
            var personId = await _personRepository.GetIdByDocumento(compra.Documento);

            purchase.Edit(purchase.Id, produtoId, personId);
            await _compraRepository.EditarCompra(purchase);
            return ResultService.OK(purchase);
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var compra = await _compraRepository.BuscarComprasById(id);
            if (compra == null) return ResultService.Fail("Compra Não Encontrada");

            await _compraRepository.DeletarCompra(compra);
            return ResultService.OK($"Compra ID: {id} foi removida.");
        }
    }
}
