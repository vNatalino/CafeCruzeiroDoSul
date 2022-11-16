using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIT.Models.Vendas.ViewModel
{
    public class ListaProdutos
    {
        public Carrinho Carrinho { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
