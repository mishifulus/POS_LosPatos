using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models.Reportes
{
    public class VentasDTO
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Username { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
    }
}
