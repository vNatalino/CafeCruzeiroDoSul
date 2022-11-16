using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIT.Models.Vendas.ViewModel
{
    public class Carrinho
    {
        public List<Compra> Compras { get; set; }
        public Usuarios.Usuario Usuario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
