using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IngeneoPT.Models;
using IngeneoPT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngeneoPT.Controllers
{
    public class LogicaController : Controller
    {
        private readonly TalycapGlobalContext _context;

        public LogicaController(TalycapGlobalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new LogicaViewModel
            {
                Clientes = _context.Clientes.ToList(),
                Productos = _context.Productos.ToList(),
                TiposTransporte = _context.TipoTransportes.ToList(),
                TiposProducto = _context.TipoProductos.ToList(),
                Ubicaciones = _context.Ubicacions.ToList(),
                Envio = _context.Envios.ToList()
            };

            return View(viewModel);
        }


        public IActionResult ViewData()
        {
            var viewModel = new LogicaViewModel
            {
                 Clientes = _context.Clientes.ToList(),
                Productos = _context.Productos.ToList(),
                TiposTransporte = _context.TipoTransportes.ToList(),
                TiposProducto = _context.TipoProductos.ToList(),
                Ubicaciones = _context.Ubicacions.ToList(),
                Envio = _context.Envios.ToList()
            
            };

            return View(viewModel);
        }
        

        // ...
        public IActionResult CreateEnvio()
        {
            var viewModel = new LogicaViewModel
            {
                Clientes = _context.Clientes.ToList(),
                Productos = _context.Productos.ToList(),
                TiposTransporte = _context.TipoTransportes.ToList(),
                TiposProducto = _context.TipoProductos.ToList(),
                Ubicaciones = _context.Ubicacions.ToList(),
                Envio = _context.Envios.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEnvio(LogicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes crear un nuevo envío con los datos seleccionados
                var nuevoEnvio = new Envio
                {
                    ClienteId = viewModel.Clientes.Count,
                    ProductoId = viewModel.Productos.Count,
                    
                };

                _context.Envios.Add(nuevoEnvio);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            // Si llegamos hasta aquí, hubo un error de validación, vuelve a cargar el ViewModel
            viewModel.Clientes = _context.Clientes.ToList();
            viewModel.Productos = _context.Productos.ToList();
            viewModel.TiposTransporte = _context.TipoTransportes.ToList();
            viewModel.Envio = _context.Envios.ToList();
            viewModel.TiposProducto = _context.TipoProductos.ToList();
            viewModel.Ubicaciones = _context.Ubicacions.ToList();
           


            return View(viewModel);
        }
        // ...
        
    }
}
