using Loja.Domain.Entidades;
using Loja.Domain.Filters;
using Loja.Domain.Pagination;
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
    public class PersonRepository : IPersonRepositorio
    {
        private readonly DatabaseContext _context;

        public PersonRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Person>> BuscarPessoa()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> BuscarPessoaById(int id)
        {
            return await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Person> CriarPessoa(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task EditarPessoa(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarPessoa(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }


        public async Task<int> GetIdByDocumento(string documento)
        {
            return (await _context.Persons.FirstOrDefaultAsync(x => x.CPF == documento))?.Id ?? 0;
        }

        public async Task<PagedBaseResponse<Person>> GetPaged(PersonFilter request)
        {
            var people = _context.Persons.AsQueryable();
            if (!string.IsNullOrEmpty(request.Nome))
                people = people.Where(x => x.Nome.Contains(request.Nome));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Person>, Person>(people, request);
        }
    }
}
