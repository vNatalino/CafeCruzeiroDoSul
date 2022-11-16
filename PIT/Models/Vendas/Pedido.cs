using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIT.Models.Vendas
{
    [Table("TblPedidos")]
    public class Pedido
    {
        public int PedidoID { get; set; }
        public Usuarios.Usuario Usuario { get; set; }
        public int UsuarioID { get; set; }
        public List<Compra> Compras { get; set; }
    }
}
