﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string CodErp { get; set; }
        public decimal Preco { get; set; }
    }
}
