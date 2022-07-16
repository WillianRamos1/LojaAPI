using Loja.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Repositorios
{
    public interface ICompraRepositorio
    {
        Task<ICollection<Compra>> BuscarCompras();
        Task<Compra> BuscarComprasById(int id);
        Task<ICollection<Compra>> BuscarComprasByPersonId(int personId);
        Task<ICollection<Compra>> BuscarComprasByProdutoId(int produtoId);
        Task<Compra> CriarCompra(Compra compra);
        Task EditarCompra(Compra compra);
        Task DeletarCompra(Compra compra);
    }
}
