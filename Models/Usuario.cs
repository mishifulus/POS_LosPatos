using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public bool Estado { get; set; } = false;
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool EstatusRegistro { get; set; } = true;
    }
}
