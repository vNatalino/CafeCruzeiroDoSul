using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIT.Models.Vendas
{
    [Table("TblCompras")]
    public class Compra
    {
        public int CompraID { get; set; }
        public Produto  Produto { get; set; }
        public int ProdutoID { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoID { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoCompra { get; set; }
    }
}
