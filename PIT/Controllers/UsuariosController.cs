using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIT.Data;
using PIT.Models.Usuarios;

namespace PIT.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly PITContext _context;

        public UsuariosController(PITContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Entrar(string senha, string email)
        {
            if (!_context.Usuario.Where(x => x.Email == email).Any())
            {
                TempData["erro"] = "Email não encontrado";
                return RedirectToAction("Index", "Home", new { login = "false" });
            }

            var user = _context.Usuario.First(x => x.Email == email);

            if (user.Senha != senha)
            {
                TempData["erro"] = "Senha incorreta";
                return RedirectToAction("Index", "Home", new { login = "false" });
            }

            return RedirectToAction("Produtos", "Vendas", new { usuario = user.UsuarioID });
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.UsuarioID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public IActionResult Create()
        {
            ViewData["logado"] = "false";
            ViewData["user"] = 0;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioID,Nome,Email,Telefone,Endereco,Senha,ConfirmaSenha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Produtos", "Vendas", new { usuario = usuario.UsuarioID });
            }
            ViewData["logado"] = "false";
            ViewData["user"] = usuario.UsuarioID;
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuario = await _context.Usuario.FindAsync(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(usuario);
        //}

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("UsuarioID,Nome,Email,Telefone,Endereco,Senha")] Usuario usuario)
        //{
        //    if (id != usuario.UsuarioID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(usuario);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UsuarioExists(usuario.UsuarioID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(usuario);
        //}

        // GET: Usuarios/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuario = await _context.Usuario
        //        .FirstOrDefaultAsync(m => m.UsuarioID == id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuario);
        //}

        // POST: Usuarios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var usuario = await _context.Usuario.FindAsync(id);
        //    _context.Usuario.Remove(usuario);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UsuarioExists(int id)
        //{
        //    return _context.Usuario.Any(e => e.UsuarioID == id);
        //}
    }
}
