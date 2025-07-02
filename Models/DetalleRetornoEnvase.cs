using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class DetalleRetornoEnvase
    {
        public int IdDetalle { get; set; }
        public int IdRetorno { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double MontoUnitario { get; set; }
        public double Subtotal { get; set; }
        public bool EstatusRegistro { get; set; } = true;
    }
}
