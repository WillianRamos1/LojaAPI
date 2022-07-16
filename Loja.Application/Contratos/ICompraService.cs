using Loja.Application.Dtos;
using Loja.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Contratos
{
    public interface ICompraService
    {
        Task<ResultService<ICollection<DetalhesCompraDto>>> GetAllAsync();
        Task<ResultService<DetalhesCompraDto>> GetByIdAsync(int id);
        Task<ResultService<CompraDto>> CreateAsync(CompraDto compra);
        Task<ResultService> UpdateAsync(CompraDto compra);
        Task<ResultService> DeleteAsync(int id);
    }
}
