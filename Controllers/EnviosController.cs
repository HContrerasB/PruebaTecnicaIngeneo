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
    public class EnviosController : Controller
    {
        private readonly TalycapGlobalContext _context;

        public EnviosController(TalycapGlobalContext context)
        {
            _context = context;
        }

        // GET: Envios
        public async Task<IActionResult> Index()
        {
            var talycapGlobalContext = _context.Envios.Include(e => e.Cliente).Include(e => e.Producto).Include(e => e.TipoTransporte).Include(e => e.Ubicacion);
            return View(await talycapGlobalContext.ToListAsync());
        }

        // GET: Envios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Envios == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Producto)
                .Include(e => e.TipoTransporte)
                .Include(e => e.Ubicacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (envio == null)
            {
                return NotFound();
            }

            return View(envio);
        }

        // GET: Envios/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["ProductoId"] = new SelectList(_context.TipoProductos, "Id", "Nombre");
            ViewData["TipoTransporteId"] = new SelectList(_context.TipoTransportes, "Id", "Tipo");
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacions, "Id", "Nombre");
            return View();
        }

        // POST: Envios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ProductoId,TipoTransporteId,UbicacionId,Matricula,NumeroGuia,FechaRegistro,FechaEntrega,PrecioEnvio,Descuento,ValorDescuento,PrecioTotal")] Envio envio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(envio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", envio.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.TipoProductos, "Id", "Nombre", envio.ProductoId);
            ViewData["TipoTransporteId"] = new SelectList(_context.TipoTransportes, "Id", "Tipo", envio.TipoTransporteId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacions, "Id", "Nombre", envio.UbicacionId);
            return View(envio);
        }

        // GET: Envios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Envios == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios.FindAsync(id);
            if (envio == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", envio.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", envio.ProductoId);
            ViewData["TipoTransporteId"] = new SelectList(_context.TipoTransportes, "Id", "Tipo", envio.TipoTransporteId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacions, "Id", "Nombre", envio.UbicacionId);
            return View(envio);
        }

        // POST: Envios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ProductoId,TipoTransporteId,UbicacionId,Matricula,NumeroGuia,FechaRegistro,FechaEntrega,PrecioEnvio,Descuento,ValorDescuento,PrecioTotal")] Envio envio)
        {
            if (id != envio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(envio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvioExists(envio.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", envio.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", envio.ProductoId);
            ViewData["TipoTransporteId"] = new SelectList(_context.TipoTransportes, "Id", "Id", envio.TipoTransporteId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacions, "Id", "Id", envio.UbicacionId);
            return View(envio);
        }

        // GET: Envios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Envios == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Producto)
                .Include(e => e.TipoTransporte)
                .Include(e => e.Ubicacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (envio == null)
            {
                return NotFound();
            }

            return View(envio);
        }

        // POST: Envios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Envios == null)
            {
                return Problem("Entity set 'TalycapGlobalContext.Envios'  is null.");
            }
            var envio = await _context.Envios.FindAsync(id);
            if (envio != null)
            {
                _context.Envios.Remove(envio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvioExists(int id)
        {
          return (_context.Envios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
