using Loja.Application.Dtos;
using Loja.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Contratos
{
    public interface IProdutoService
    {
        Task<ResultService<ICollection<ProdutoDto>>> GetAllAsync();
        Task<ResultService<ProdutoDto>> GetByIdAsync(int id);
        Task<ResultService<ProdutoDto>> CreateAsync(ProdutoDto produto);
        Task<ResultService> UpdateAsync(ProdutoDto produto);
        Task<ResultService> DeleteAsync(int id);
    }
}
