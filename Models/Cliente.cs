using System;
using System.Collections.Generic;

namespace IngeneoPT.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Envios = new HashSet<Envio>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
