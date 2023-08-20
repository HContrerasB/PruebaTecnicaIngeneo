using System;
using System.Collections.Generic;
using IngeneoPT.Models;

namespace IngeneoPT.ViewModels
{
    public class LogicaViewModel
    {
        public List<Cliente> Clientes { get; set; }
        public List<Producto> Productos { get; set; }
        public List<TipoTransporte> TiposTransporte { get; set; }
        public List<TipoProducto> TiposProducto { get; set; }
        public List<Ubicacion> Ubicaciones { get; set; }
        public List<Envio> Envio { get; set; }
    }
}
