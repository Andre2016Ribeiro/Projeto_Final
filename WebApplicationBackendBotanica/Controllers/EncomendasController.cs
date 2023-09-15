using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassBackendBotanica;
using WebApplicationBackendBotanica.Data;

namespace WebApplicationBackendBotanica.Controllers
{
    public class EncomendasController : Controller
    {
        private readonly WebApplicationBackendBotanicaContext _context;

        public EncomendasController(WebApplicationBackendBotanicaContext context)
        {
            _context = context;
        }

        // GET: Encomendas
        public async Task<IActionResult> Index()
        {
            var webApplicationBackendBotanicaContext = _context.Encomenda.Include(e => e.Artigo).Include(e => e.Utilizador);
            return View(await webApplicationBackendBotanicaContext.ToListAsync());
        }

        // GET: Encomendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Encomenda == null)
            {
                return NotFound();
            }

            var encomenda = await _context.Encomenda
                .Include(e => e.Artigo)
                .Include(e => e.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encomenda == null)
            {
                return NotFound();
            }

            return View(encomenda);
        }

        // GET: Encomendas/Create
        public IActionResult Create()
        {
            ViewData["ArtigoId"] = new SelectList(_context.Artigo, "Id", "Nome");
            ViewData["UtilizadorId"] = new SelectList(_context.Utilizador, "Id", "Nome");
            return View();
        }

        // POST: Encomendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,DataEncomenda,UtilizadorId,ArtigoId")] Encomenda encomenda)
        {
            ModelState.Remove("Utilizador");
            ModelState.Remove("Artigo");
            if (ModelState.IsValid)
            {
                _context.Add(encomenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtigoId"] = new SelectList(_context.Artigo, "Id", "Nome", encomenda.ArtigoId);
            ViewData["UtilizadorId"] = new SelectList(_context.Utilizador, "Id", "Nome", encomenda.UtilizadorId);
            return View(encomenda);
        }

        // GET: Encomendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Encomenda == null)
            {
                return NotFound();
            }

            var encomenda = await _context.Encomenda.FindAsync(id);
            if (encomenda == null)
            {
                return NotFound();
            }
            ViewData["ArtigoId"] = new SelectList(_context.Artigo, "Id", "Nome", encomenda.ArtigoId);
            ViewData["UtilizadorId"] = new SelectList(_context.Utilizador, "Id", "Nome", encomenda.UtilizadorId);
            return View(encomenda);
        }

        // POST: Encomendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantidade,DataEncomenda,UtilizadorId,ArtigoId")] Encomenda encomenda)
        {
            if (id != encomenda.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Utilizador");
            ModelState.Remove("Artigo");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encomenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncomendaExists(encomenda.Id))
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
            ViewData["ArtigoId"] = new SelectList(_context.Artigo, "Id", "Nome", encomenda.ArtigoId);
            ViewData["UtilizadorId"] = new SelectList(_context.Utilizador, "Id", "Nome", encomenda.UtilizadorId);
            return View(encomenda);
        }

        // GET: Encomendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Encomenda == null)
            {
                return NotFound();
            }

            var encomenda = await _context.Encomenda
                .Include(e => e.Artigo)
                .Include(e => e.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encomenda == null)
            {
                return NotFound();
            }

            return View(encomenda);
        }

        // POST: Encomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Encomenda == null)
            {
                return Problem("Entity set 'WebApplicationBackendBotanicaContext.Encomenda'  is null.");
            }
            var encomenda = await _context.Encomenda.FindAsync(id);
            if (encomenda != null)
            {
                _context.Encomenda.Remove(encomenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncomendaExists(int id)
        {
          return (_context.Encomenda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
