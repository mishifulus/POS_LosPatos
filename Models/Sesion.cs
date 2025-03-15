using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class Sesion
    {
        public int IdSesion { get; set; }
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; } = true;
    }
}
