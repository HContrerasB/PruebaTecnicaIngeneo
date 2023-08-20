using System;
using System.Collections.Generic;

namespace IngeneoPT.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Envios = new HashSet<Envio>();
        }

        public int Id { get; set; }
        public int? TipoProductoId { get; set; }
        public int? Cantidad { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
