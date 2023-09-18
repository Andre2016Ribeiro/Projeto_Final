using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassBackendBotanica;
using BotanicaContext;

namespace WebApplicationBackendBotanica.Controllers
{
    public class ArtigosController : Controller
    {
        private readonly WebApplicationBackendBotanicaContext _context;

        public ArtigosController(WebApplicationBackendBotanicaContext context)
        {
            _context = context;
        }

        // GET: Artigos
        public async Task<IActionResult> Index()
        {
            var webApplicationBackendBotanicaContext = _context.Artigo.Include(a => a.Categoria);
            return View(await webApplicationBackendBotanicaContext.ToListAsync());
        }

        // GET: Artigos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artigo == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo
                .Include(a => a.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artigo == null)
            {
                return NotFound();
            }

            return View(artigo);
        }

        // GET: Artigos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Artigos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco,CategoriaId")] Artigo artigo)
        {
            ModelState.Remove("Categoria");
            ModelState.Remove("Encomendas");
            if (ModelState.IsValid)
            {
                _context.Add(artigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", artigo.CategoriaId);
            return View(artigo);
        }

        // GET: Artigos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artigo == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo.FindAsync(id);
            if (artigo == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", artigo.CategoriaId);
            return View(artigo);
        }

        // POST: Artigos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,CategoriaId")] Artigo artigo)
        {
            if (id != artigo.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Categoria");
            ModelState.Remove("Encomendas");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtigoExists(artigo.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", artigo.CategoriaId);
            return View(artigo);
        }

        // GET: Artigos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artigo == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo
                .Include(a => a.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artigo == null)
            {
                return NotFound();
            }

            return View(artigo);
        }

        // POST: Artigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artigo == null)
            {
                return Problem("Entity set 'WebApplicationBackendBotanicaContext.Artigo'  is null.");
            }
            var artigo = await _context.Artigo.FindAsync(id);
            if (artigo != null)
            {
                _context.Artigo.Remove(artigo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtigoExists(int id)
        {
          return (_context.Artigo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
