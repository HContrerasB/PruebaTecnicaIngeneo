using System;
using System.Collections.Generic;

namespace IngeneoPT.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Envios = new HashSet<Envio>();
        }

        public int Id { get; set; }
        public int TipoTransporteId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
