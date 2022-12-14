using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeBancoDotNet.Data;
using HomeBancoDotNet.Models;

namespace HomeBancoDotNet.Controllers
{
    public class PlazoFijoesController : Controller
    {
        private readonly MiContexto _context;

        public PlazoFijoesController(MiContexto context)
        {
            _context = context;
        }

        // GET: PlazoFijoes
        public async Task<IActionResult> Index()
        {
            var miContexto = _context.plazoFijos.Include(p => p.titularP);
            return View(await miContexto.ToListAsync());
        }

        // GET: PlazoFijoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.plazoFijos == null)
            {
                return NotFound();
            }

            var plazoFijo = await _context.plazoFijos
                .Include(p => p.titularP)
                .FirstOrDefaultAsync(m => m.idPlazoFijo == id);
            if (plazoFijo == null)
            {
                return NotFound();
            }

            return View(plazoFijo);
        }

        // GET: PlazoFijoes/Create
        public IActionResult Create()
        {
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario");
            return View();
        }

        // POST: PlazoFijoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPlazoFijo,NumUsuario,monto,fechaIni,fechaFin,tasa,pagado")] PlazoFijo plazoFijo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plazoFijo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario", plazoFijo.NumUsuario);
            return View(plazoFijo);
        }

        // GET: PlazoFijoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.plazoFijos == null)
            {
                return NotFound();
            }

            var plazoFijo = await _context.plazoFijos.FindAsync(id);
            if (plazoFijo == null)
            {
                return NotFound();
            }
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario", plazoFijo.NumUsuario);
            return View(plazoFijo);
        }

        // POST: PlazoFijoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPlazoFijo,NumUsuario,monto,fechaIni,fechaFin,tasa,pagado")] PlazoFijo plazoFijo)
        {
            if (id != plazoFijo.idPlazoFijo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plazoFijo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlazoFijoExists(plazoFijo.idPlazoFijo))
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
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario", plazoFijo.NumUsuario);
            return View(plazoFijo);
        }

        // GET: PlazoFijoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.plazoFijos == null)
            {
                return NotFound();
            }

            var plazoFijo = await _context.plazoFijos
                .Include(p => p.titularP)
                .FirstOrDefaultAsync(m => m.idPlazoFijo == id);
            if (plazoFijo == null)
            {
                return NotFound();
            }

            return View(plazoFijo);
        }

        // POST: PlazoFijoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.plazoFijos == null)
            {
                return Problem("Entity set 'MiContexto.plazoFijos'  is null.");
            }
            var plazoFijo = await _context.plazoFijos.FindAsync(id);
            if (plazoFijo != null)
            {
                _context.plazoFijos.Remove(plazoFijo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlazoFijoExists(int id)
        {
            return _context.plazoFijos.Any(e => e.idPlazoFijo == id);
        }
    }
}
