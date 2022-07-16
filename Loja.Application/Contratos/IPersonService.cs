using Loja.Application.Dtos;
using Loja.Application.Service;
using Loja.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Contratos
{
    public interface IPersonService
    {
        Task<ResultService<ICollection<PersonDto>>> GetAllAsync();
        Task<ResultService<PersonDto>> GetByIdAsync(int id);
        Task<ResultService<PersonDto>> CreateAsync(PersonDto person);
        Task<ResultService> UpdateAsync(PersonDto person);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<PagedBaseResponseDto<PersonDto>>> GetPage(PersonFilter personFilter);
    }
}
