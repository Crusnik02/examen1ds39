using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using examen1ds39.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace examen1ds39.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDBContext _context;

        public UsuariosController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return _context.Usuarios != null ? 
                          View(await _context.Usuarios.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Usuarios'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.CodUser == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodUser,NombreUsuario,Contra,NivelUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodUser,NombreUsuario,Contra,NivelUsuario")] Usuario usuario)
        {
            if (id != usuario.CodUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.CodUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.CodUser == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'AppDBContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string NombreUsuario, string password)
        {
            var usuario = _context
                .Usuarios
                .Where(s => s.NombreUsuario == NombreUsuario).First();
            if (usuario != null)
            {
                if (usuario.Contra == password)
                {
                    List<string> sessionInfo = new List<string>();
                    if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariable.SessionKeyUsername)))
                    {
                        HttpContext.Session.SetString(SessionVariable.SessionKeyUsername, usuario.NombreUsuario);
                        HttpContext.Session.SetString(SessionVariable.SessionKeyId, usuario.CodUser.ToString());
                        HttpContext.Session.SetString(SessionVariable.SessionKeyNivel, usuario.NivelUsuario);
                    }
                    var username = HttpContext.Session.GetString(SessionVariable.SessionKeyUsername);
                    var nivel = HttpContext.Session.GetString(SessionVariable.SessionKeyNivel);
                    sessionInfo.Add(username);
                    sessionInfo.Add(nivel);
                    ViewData["MENSAJE"] = "Felicidades su session inicio con exito.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["MENSAJE"] = "La tarea fallo con exito.";
                    return RedirectToAction("Index", "Home"); ;
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
            
        }

        public async Task<IActionResult> LogOut()
        {
          
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.CodUser == id)).GetValueOrDefault();
        }
    }
}
