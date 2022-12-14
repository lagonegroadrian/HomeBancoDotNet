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
    public class PagoesController : Controller
    {
        private readonly MiContexto _context;

        public PagoesController(MiContexto context)
        {
            _context = context;
        }

        // GET: Pagoes
        public async Task<IActionResult> Index()
        {
            var miContexto = _context.pago.Include(p => p.user);
            return View(await miContexto.ToListAsync());
        }

        // GET: Pagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.pago == null)
            {
                return NotFound();
            }

            var pago = await _context.pago
                .Include(p => p.user)
                .FirstOrDefaultAsync(m => m.idPago == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagoes/Create
        public IActionResult Create()
        {
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario");
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPago,NumUsuario,nombre,monto,pagado,metodo")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario", pago.NumUsuario);
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pago == null)
            {
                return NotFound();
            }

            var pago = await _context.pago.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario", pago.NumUsuario);
            return View(pago);
        }

        // POST: Pagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPago,NumUsuario,nombre,monto,pagado,metodo")] Pago pago)
        {
            if (id != pago.idPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.idPago))
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
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario", pago.NumUsuario);
            return View(pago);
        }

        // GET: Pagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pago == null)
            {
                return NotFound();
            }

            var pago = await _context.pago
                .Include(p => p.user)
                .FirstOrDefaultAsync(m => m.idPago == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.pago == null)
            {
                return Problem("Entity set 'MiContexto.pago'  is null.");
            }
            var pago = await _context.pago.FindAsync(id);
            if (pago != null)
            {
                _context.pago.Remove(pago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
            return _context.pago.Any(e => e.idPago == id);
        }
    }
}
