using Microsoft.AspNetCore.Mvc;
using PIT.Data;
using PIT.Models.Vendas;
using PIT.Models.Vendas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIT.Controllers
{
    public class VendasController : Controller
    {
        private readonly PITContext _context;

        public VendasController(PITContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Produtos(int usuario, string categoria)
        {
            ViewData["logado"] = "true";
            ViewData["user"] = usuario;
            var produtos = from p in  _context.Produtos select p;
            if (!String.IsNullOrEmpty(categoria))
            {
                produtos = produtos.Where(x => x.Categoria == categoria);
            }
            ListaProdutos lista = new ListaProdutos()
            {
                Carrinho = new Carrinho()
                {
                    Usuario = new Models.Usuarios.Usuario()
                    {
                        UsuarioID = usuario
                    }
                },
                Produtos = produtos.ToList()
            };
            return View(lista);
        }

        [HttpGet]
        public IActionResult Confirmacao(Carrinho carrinho)
        {
            ViewData["logado"] = "true";
            ViewData["user"] = carrinho.Usuario.UsuarioID;
            carrinho.Compras =  carrinho.Compras.Select(x => {
                x.PrecoCompra = x.Produto.Preco * x.Quantidade;
                return x;
            }).ToList();
            carrinho.ValorTotal = carrinho.Compras.Sum(x => x.PrecoCompra);
            return View(carrinho);
        }

        [HttpPost]
        public IActionResult Finalizar(Carrinho carrinho)
        {
            ViewData["logado"] = "true";
            ViewData["user"] = carrinho.Usuario.UsuarioID;
            carrinho.Compras = carrinho.Compras.Select(x =>
            {
                x.Produto = null;
                return x;
            }).ToList();
            var p = new Pedido()
            {
                Compras = carrinho.Compras,
                UsuarioID = carrinho.Usuario.UsuarioID,
            };
            _context.Pedido.Add(p);
            _context.SaveChanges();
            ViewData["pedido"] = p.PedidoID;
            return View();
        }

        [HttpGet]
        public IActionResult AdicionarProduto(int produto)
        {
            return Ok(_context.Produtos.Find(produto));
        }
    }
}
