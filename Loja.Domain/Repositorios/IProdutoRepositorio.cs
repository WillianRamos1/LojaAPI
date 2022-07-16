using Loja.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Repositorios
{
    public interface IProdutoRepositorio
    {
        Task<ICollection<Produto>> BuscarProdutos();
        Task<Produto> BuscarProdutoById(int id);
        Task<Produto> CriarProduto(Produto produto);
        Task EditarProduto(Produto produto);
        Task DeletarProduto(Produto produto);

        Task<int> GetIdByCodErp(string codErp);
    }
}
