using Loja.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Entidades
{
    public sealed class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string CodErp { get; set; }
        public decimal Preco { get; set; }
        public ICollection<Compra> Compras { get; set; }
    }
}
