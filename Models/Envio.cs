using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IngeneoPT.Models
{
    public partial class Envio
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? ProductoId { get; set; }
        public int TipoTransporteId { get; set; }
        public int? UbicacionId { get; set; }
        public string? Matricula { get; set; }
        [Editable(false)]
        public string? NumeroGuia { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal? PrecioEnvio { get; set; }
        public byte Descuento { get; set; }
        public decimal ValorDescuento { get; set; }
        public decimal PrecioTotal { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual Producto? Producto { get; set; }
        public virtual TipoTransporte TipoTransporte { get; set; } = null!;
        public virtual Ubicacion? Ubicacion { get; set; }
    }
}
