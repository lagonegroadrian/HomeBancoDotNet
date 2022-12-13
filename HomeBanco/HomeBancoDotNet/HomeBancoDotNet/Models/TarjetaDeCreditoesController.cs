using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeBancoDotNet.Data;

namespace HomeBancoDotNet.Models
{
    public class TarjetaDeCreditoesController : Controller
    {
        private readonly MiContexto _context;

        public TarjetaDeCreditoesController(MiContexto context)
        {
            _context = context;
        }

        // GET: TarjetaDeCreditoes
        public async Task<IActionResult> Index()
        {
            var miContexto = _context.tarjetaDeCredito.Include(t => t.titular);
            return View(await miContexto.ToListAsync());
        }

        // GET: TarjetaDeCreditoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tarjetaDeCredito == null)
            {
                return NotFound();
            }

            var tarjetaDeCredito = await _context.tarjetaDeCredito
                .Include(t => t.titular)
                .FirstOrDefaultAsync(m => m.idTarjetaDeCredito == id);
            if (tarjetaDeCredito == null)
            {
                return NotFound();
            }

            return View(tarjetaDeCredito);
        }

        // GET: TarjetaDeCreditoes/Create
        public IActionResult Create()
        {
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario");
            return View();
        }

        // POST: TarjetaDeCreditoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTarjetaDeCredito,NumUsuario,numero,codigoV,limite,consumos")] TarjetaDeCredito tarjetaDeCredito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarjetaDeCredito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario", tarjetaDeCredito.NumUsuario);
            return View(tarjetaDeCredito);
        }

        // GET: TarjetaDeCreditoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tarjetaDeCredito == null)
            {
                return NotFound();
            }

            var tarjetaDeCredito = await _context.tarjetaDeCredito.FindAsync(id);
            if (tarjetaDeCredito == null)
            {
                return NotFound();
            }
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario", tarjetaDeCredito.NumUsuario);
            return View(tarjetaDeCredito);
        }

        // POST: TarjetaDeCreditoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTarjetaDeCredito,NumUsuario,numero,codigoV,limite,consumos")] TarjetaDeCredito tarjetaDeCredito)
        {
            if (id != tarjetaDeCredito.idTarjetaDeCredito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarjetaDeCredito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarjetaDeCreditoExists(tarjetaDeCredito.idTarjetaDeCredito))
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
            ViewData["NumUsuario"] = new SelectList(_context.usuarios, "idUsuario", "idUsuario", tarjetaDeCredito.NumUsuario);
            return View(tarjetaDeCredito);
        }

        // GET: TarjetaDeCreditoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tarjetaDeCredito == null)
            {
                return NotFound();
            }

            var tarjetaDeCredito = await _context.tarjetaDeCredito
                .Include(t => t.titular)
                .FirstOrDefaultAsync(m => m.idTarjetaDeCredito == id);
            if (tarjetaDeCredito == null)
            {
                return NotFound();
            }

            return View(tarjetaDeCredito);
        }

        // POST: TarjetaDeCreditoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tarjetaDeCredito == null)
            {
                return Problem("Entity set 'MiContexto.tarjetaDeCredito'  is null.");
            }
            var tarjetaDeCredito = await _context.tarjetaDeCredito.FindAsync(id);
            if (tarjetaDeCredito != null)
            {
                _context.tarjetaDeCredito.Remove(tarjetaDeCredito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarjetaDeCreditoExists(int id)
        {
          return _context.tarjetaDeCredito.Any(e => e.idTarjetaDeCredito == id);
        }
    }
}
