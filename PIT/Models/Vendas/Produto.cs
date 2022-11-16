using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIT.Models.Vendas
{
    [Table("TblProdutos")]
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Img { get; set; }
        public string Categoria { get; set; }
    }
}