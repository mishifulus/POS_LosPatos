using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class PromocionVenta
    {
        public int IdPromocionVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdPromocion { get; set; }
        public double DescuentoAplicado { get; set; }
        public int IdUsuario { get; set; }
        public bool EstatusRegistro { get; set; } = true;
    }
}
