using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIT.Data
{
    public class DbInitializer
    {
        public static void Initialize(PITContext context)
        {
            context.Database.EnsureCreated();

            if (context.Produtos.Any())
            {
                return;
            }

            var produtos = new Models.Vendas.Produto[]
            {
                new Models.Vendas.Produto{Descricao = "Café", Categoria = "Bebida" , Preco = 4.99m, Img = "https://www.thepackagingcompany.com/knowledge-sharing/wp-content/uploads/2021/01/ip-coffee-cup-sleeves-blog.jpg"},
                new Models.Vendas.Produto{Descricao = "Milk shake",Categoria = "Bebida", Preco = 11.99m, Img = "https://www.receitas-sem-fronteiras.com/uploads/media/milk_shake.jpg?1393263885"},
                new Models.Vendas.Produto{Descricao = "Chocolate quente",Categoria = "Bebida" , Preco = 6.99m, Img = "https://belavista.tur.br/wp-content/uploads/2020/07/belavistacafecolonialoficial_81738510_111613920278269_6355853114493564800_n.jpg"},
                new Models.Vendas.Produto{Descricao = "Água",Categoria = "Bebida", Preco = 2.99m, Img = "https://static.paodeacucar.com/img/uploads/1/383/19563383.jpg"},
                new Models.Vendas.Produto{Descricao = "Suco de laranja",Categoria = "Bebida" , Preco = 10.00m,Img = "https://img.itdg.com.br/tdg/images/recipes/000/098/564/333992/333992_original.jpg"},
                new Models.Vendas.Produto{Descricao = "Bolo de chocolate",Categoria = "Bolo", Preco = 8.50m, Img = "https://s2.glbimg.com/Vj_W2NFPB_2A-wNTUYjC6eg1tCc=/0x0:521x406/984x0/smart/filters:strip_icc()/s.glbimg.com/po/rc/media/2013/09/26/20_55_07_247_bolo_chocolate.jpg"},
                new Models.Vendas.Produto{Descricao = "Bolo de frutas vermelhas",Categoria = "Bolo", Preco = 9.00m, Img = "https://www.montaencanta.com.br/wp-content/uploads/2016/01/FullSizeRender.jpg"},
                new Models.Vendas.Produto{Descricao = "Bolo de cenoura",Categoria = "Bolo", Preco = 7.00m, Img = "https://www.montaencanta.com.br/wp-content/uploads/2016/01/FullSizeRender.jpg"},
                new Models.Vendas.Produto{Descricao = "Torta de limão",Categoria = "Torta", Preco = 7.90m, Img = "https://riomarrecife.com.br/recife/2022/05/Bolo-de-cenoura.png"},
                new Models.Vendas.Produto{Descricao = "Torta de maçã",Categoria = "Torta", Preco = 8.90m, Img = "https://cdn.urbano.com.br/uploads/ubn002-19h-segmentos-ubn-setembro-v2-culturanacozinha-1-800.jpg"},
            };
            foreach(var p in produtos)
            {
                context.Add(p);
            }
            context.SaveChanges();
        }
    }
}
