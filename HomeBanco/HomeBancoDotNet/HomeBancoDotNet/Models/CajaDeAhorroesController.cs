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
    public class CajaDeAhorroesController : Controller
    {
        private readonly MiContexto _context;

        public CajaDeAhorroesController(MiContexto context)
        {
            _context = context;
        }

        // GET: CajaDeAhorroes
        public async Task<IActionResult> Index()
        {
              return View(await _context.cajaDeAhorros.ToListAsync());
        }

        // GET: CajaDeAhorroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cajaDeAhorros == null)
            {
                return NotFound();
            }

            var cajaDeAhorro = await _context.cajaDeAhorros
                .FirstOrDefaultAsync(m => m.idCajaDeAhorro == id);
            if (cajaDeAhorro == null)
            {
                return NotFound();
            }

            return View(cajaDeAhorro);
        }

        // GET: CajaDeAhorroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CajaDeAhorroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCajaDeAhorro,cbu,saldo")] CajaDeAhorro cajaDeAhorro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cajaDeAhorro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cajaDeAhorro);
        }

        // GET: CajaDeAhorroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cajaDeAhorros == null)
            {
                return NotFound();
            }

            var cajaDeAhorro = await _context.cajaDeAhorros.FindAsync(id);
            if (cajaDeAhorro == null)
            {
                return NotFound();
            }
            return View(cajaDeAhorro);
        }

        // POST: CajaDeAhorroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCajaDeAhorro,cbu,saldo")] CajaDeAhorro cajaDeAhorro)
        {
            if (id != cajaDeAhorro.idCajaDeAhorro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cajaDeAhorro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CajaDeAhorroExists(cajaDeAhorro.idCajaDeAhorro))
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
            return View(cajaDeAhorro);
        }

        // GET: CajaDeAhorroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cajaDeAhorros == null)
            {
                return NotFound();
            }

            var cajaDeAhorro = await _context.cajaDeAhorros
                .FirstOrDefaultAsync(m => m.idCajaDeAhorro == id);
            if (cajaDeAhorro == null)
            {
                return NotFound();
            }

            return View(cajaDeAhorro);
        }

        // POST: CajaDeAhorroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cajaDeAhorros == null)
            {
                return Problem("Entity set 'MiContexto.cajaDeAhorros'  is null.");
            }
            var cajaDeAhorro = await _context.cajaDeAhorros.FindAsync(id);
            if (cajaDeAhorro != null)
            {
                _context.cajaDeAhorros.Remove(cajaDeAhorro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CajaDeAhorroExists(int id)
        {
          return _context.cajaDeAhorros.Any(e => e.idCajaDeAhorro == id);
        }
    }
}
