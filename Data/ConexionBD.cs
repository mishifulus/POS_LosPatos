using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Data
{
    public class ConexionBD
    {
        private static readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnectionLosPatos"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
