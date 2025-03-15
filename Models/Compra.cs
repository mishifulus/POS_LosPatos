using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class Compra
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double Total { get; set; }
        public int TipoPago { get; set; }
        public string TipoPagoNombre { get; set; }
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public bool EstatusRegistro { get; set; } = true;
    }
}
