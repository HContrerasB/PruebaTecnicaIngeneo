using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IngeneoPT.Models;

namespace IngeneoPT.Controllers
{
    public class TipoTransportesController : Controller
    {
        private readonly TalycapGlobalContext _context;

        public TipoTransportesController(TalycapGlobalContext context)
        {
            _context = context;
        }

        // GET: TipoTransportes
        public async Task<IActionResult> Index()
        {
              return _context.TipoTransportes != null ? 
                          View(await _context.TipoTransportes.ToListAsync()) :
                          Problem("Entity set 'TalycapGlobalContext.TipoTransportes'  is null.");
        }

        // GET: TipoTransportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoTransportes == null)
            {
                return NotFound();
            }

            var tipoTransporte = await _context.TipoTransportes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTransporte == null)
            {
                return NotFound();
            }

            return View(tipoTransporte);
        }

        // GET: TipoTransportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTransportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo")] TipoTransporte tipoTransporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTransporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTransporte);
        }

        // GET: TipoTransportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoTransportes == null)
            {
                return NotFound();
            }

            var tipoTransporte = await _context.TipoTransportes.FindAsync(id);
            if (tipoTransporte == null)
            {
                return NotFound();
            }
            return View(tipoTransporte);
        }

        // POST: TipoTransportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo")] TipoTransporte tipoTransporte)
        {
            if (id != tipoTransporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTransporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTransporteExists(tipoTransporte.Id))
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
            return View(tipoTransporte);
        }

        // GET: TipoTransportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoTransportes == null)
            {
                return NotFound();
            }

            var tipoTransporte = await _context.TipoTransportes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTransporte == null)
            {
                return NotFound();
            }

            return View(tipoTransporte);
        }

        // POST: TipoTransportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoTransportes == null)
            {
                return Problem("Entity set 'TalycapGlobalContext.TipoTransportes'  is null.");
            }
            var tipoTransporte = await _context.TipoTransportes.FindAsync(id);
            if (tipoTransporte != null)
            {
                _context.TipoTransportes.Remove(tipoTransporte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTransporteExists(int id)
        {
          return (_context.TipoTransportes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
