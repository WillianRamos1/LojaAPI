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
    public class CompraRepositorio : ICompraRepositorio
    {
        private readonly DatabaseContext _context;

        public CompraRepositorio(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Compra>> BuscarCompras()
        {
            return await _context.Compras.Include(p => p.Person).Include(p => p.Produto).ToListAsync();
        }

        public async Task<Compra> BuscarComprasById(int id)
        {
            return await _context.Compras.Include(p => p.Person).Include(p => p.Produto).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Compra>> BuscarComprasByPersonId(int personId)
        {
            return await _context.Compras.Include(p => p.Person).Include(p => p.Produto).Where(x => x.PersonId == personId).ToListAsync();
        }

        public async Task<ICollection<Compra>> BuscarComprasByProdutoId(int produtoId)
        {
            return await _context.Compras.Include(p => p.Produto).Include(p => p.Person).Where(x => x.ProdutoId == produtoId).ToListAsync();
        }

        public async Task<Compra> CriarCompra(Compra compra)
        {
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();
            return compra;
        }

        public async Task EditarCompra(Compra compra)
        {
            _context.Entry(compra).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarCompra(Compra compra)
        {
            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
        }
    }
}
