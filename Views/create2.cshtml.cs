using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IngeneoPT.Models;

namespace IngeneoPT.Views
{
    public class create2Model : PageModel
    {
        private readonly IngeneoPT.Models.TalycapGlobalContext _context;

        public create2Model(IngeneoPT.Models.TalycapGlobalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
        ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id");
        ViewData["TipoTransporteId"] = new SelectList(_context.TipoTransportes, "Id", "Id");
        ViewData["UbicacionId"] = new SelectList(_context.Ubicacions, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Envio Envio { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Envios == null || Envio == null)
            {
                return Page();
            }

            _context.Envios.Add(Envio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
