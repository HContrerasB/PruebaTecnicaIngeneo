using System;
using System.Collections.Generic;

namespace IngeneoPT.Models
{
    public partial class TipoTransporte
    {
        public TipoTransporte()
        {
            Envios = new HashSet<Envio>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; } = null!;

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
