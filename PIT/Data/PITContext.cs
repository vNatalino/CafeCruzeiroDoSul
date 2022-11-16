using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PIT.Models.Usuarios;
using PIT.Models.Vendas;

namespace PIT.Data
{
    public class PITContext : DbContext
    {
        public PITContext (DbContextOptions<PITContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}
