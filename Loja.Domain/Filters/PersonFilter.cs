using Loja.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Filters
{
    public class PersonFilter : PagedBaseRequest
    {
        public string? Nome { get; set; }
    }
}
