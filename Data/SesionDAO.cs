using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace LosPatosSystem.Data
{
    class SesionDAO
    {
        public void CerrarSesion(int IdUsuario, int IdSesion)
        {
            using(SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spCerrarSesion", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@IdSesion", IdSesion);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public bool IniciarSesion(string Username, string Password, out int IdSesion, out int IdUsuario, out int IdRol, out string Mensaje)
        {
            IdSesion = 0;
            IdUsuario = 0;
            IdRol = 0;
            Mensaje = string.Empty;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spIniciarSesion", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Pass", Password);

                        // Parámetros de salida
                        SqlParameter paramIdSesion = new SqlParameter("@IdSesion", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(paramIdSesion);

                        SqlParameter paramIdUsuario = new SqlParameter("@IdUsuario", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(paramIdUsuario);

                        SqlParameter paramIdRol = new SqlParameter("@IdRol", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(paramIdRol);

                        SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 40)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(paramMensaje);

                        cmd.ExecuteNonQuery();

                        // Obtener valores de salida
                        IdSesion = (paramIdSesion.Value != DBNull.Value) ? Convert.ToInt32(paramIdSesion.Value) : 0;
                        IdUsuario = (paramIdSesion.Value != DBNull.Value) ? Convert.ToInt32(paramIdUsuario.Value) : 0;
                        IdRol = (paramIdRol.Value != DBNull.Value) ? Convert.ToInt32(paramIdRol.Value) : 0;
                        Mensaje = paramMensaje.Value.ToString();

                        return IdSesion > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
    }
}
