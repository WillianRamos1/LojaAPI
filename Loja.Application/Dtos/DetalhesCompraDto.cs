using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Dtos
{
    public class DetalhesCompraDto
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string Produto { get; set; }
        public DateTime Data { get; set; }
    }
}
