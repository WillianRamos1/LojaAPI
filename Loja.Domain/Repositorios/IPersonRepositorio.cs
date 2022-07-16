using Loja.Domain.Entidades;
using Loja.Domain.Filters;
using Loja.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Repositorios
{
    public interface IPersonRepositorio
    {
        Task<ICollection<Person>> BuscarPessoa();
        Task<Person> BuscarPessoaById(int id);
        Task<Person> CriarPessoa(Person person);
        Task EditarPessoa(Person person);
        Task DeletarPessoa(Person person);

        Task<int> GetIdByDocumento(string documento);

        Task<PagedBaseResponse<Person>> GetPaged(PersonFilter request);
    }
}
