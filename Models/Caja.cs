using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class Caja
    {
        public int IdMovimiento { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public Boolean TipoMovimiento { get; set; }
        public string Movimiento { get; set; }
        public double Monto { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public bool EstatusRegistro { get; set; } = true;
    }
}
