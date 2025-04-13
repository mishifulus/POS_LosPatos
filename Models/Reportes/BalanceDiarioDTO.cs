using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models.Reportes
{
    public class BalanceDiarioDTO
    {
        public DateTime Fecha { get; set; }
        public double Ingresos { get; set; }
        public double Egresos { get; set; }
        public double Balance { get; set; }
    }
}
