using Loja.Domain.Entidades;
using Loja.Domain.Repositorios;
using Loja.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra.Data.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly DatabaseContext _context;

        public ProdutoRepositorio(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Produto>> BuscarProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> BuscarProdutoById(int id)
        {
            return await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Produto> CriarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task EditarProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }



        public async Task<int> GetIdByCodErp(string codErp)
        {
            return (await _context.Produtos.FirstOrDefaultAsync(x => x.CodErp == codErp))?.Id??0;
        }
    }
}
