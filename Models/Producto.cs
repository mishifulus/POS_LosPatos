using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdUnidad { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public bool EstatusRegistro { get; set; } = true;
    }
}
