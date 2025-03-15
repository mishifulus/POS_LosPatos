using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class Promocion
    {
        public int IdPromocion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Tipo { get; set; }
        public string TipoDescuento { get; set; }
        public double ValorDescuento { get; set; }
        public int CantidadMinima { get; set; }
        public int ProductoAsociado { get; set; }
        public string ProductoAsociadoNombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public bool EstatusRegistro { get; set; } = true;
    }
}
