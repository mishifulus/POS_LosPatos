using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class Devolucion
    {
        public int IdDevolucion { get; set; }
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double TotalDevuelto { get; set; }
        public string Motivo { get; set; }
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public bool EstatusRegistro { get; set; } = true;
    }
}
