using Loja.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Entidades
{
    public class Compra
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PersonId { get; set; }
        public DateTime Data { get; set; }
        public Person Person { get; set; }
        public Produto Produto { get; set; }


        public Compra(int productId, int personId)
        {
            ProdutoId = productId;
            PersonId = personId;
        }

        public void Edit(int id, int productId, int personId)
        {
            Id = id;
            ProdutoId = productId;
            PersonId = personId;
        }
    }
}
