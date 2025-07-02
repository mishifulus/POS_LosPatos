using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class RetornoEnvase
    {
        public int IdRetorno { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int FolioVenta { get; set; }
        public double TotalDevuelto { get; set; }
        public int IdUsuario { get; set; }
        public bool EstatusRegistro { get; set; } = true;
    }
}
