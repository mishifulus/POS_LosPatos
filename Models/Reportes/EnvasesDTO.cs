using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models.Reportes
{
    class EnvasesDTO
    {
        public int IdRetorno { get; set; }
        public int FolioVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Username { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public double Monto { get; set; }
        public double Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
    }
}
