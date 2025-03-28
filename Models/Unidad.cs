﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Models
{
    class Unidad
    {
        public int IdUnidad { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public bool EstatusRegistro { get; set; } = true;
    }
}
