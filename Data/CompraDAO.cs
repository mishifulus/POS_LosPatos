using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosPatosSystem.Data
{
    class CompraDAO
    {
        public int ObtenerIdCompra()
        {
            int IdCompra = 0;

            using(SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT ISNULL(MAX(IdCompra), 0) + 1 FROM Compras";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        IdCompra = (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }
            return IdCompra;
        }

        public bool RegistrarCompra(double total, int tipoPago, int idUsuario, DataTable productos, out int idCompra)
        {
            idCompra = 0;

            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarCompras", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.Parameters.AddWithValue("@TipoPago", tipoPago);
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        SqlParameter paramProductos = cmd.Parameters.AddWithValue("@Productos", productos);
                        paramProductos.SqlDbType = SqlDbType.Structured;

                        SqlParameter paramIdCompra = new SqlParameter("@IdCompra", SqlDbType.Int);
                        paramIdCompra.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paramIdCompra);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        idCompra = Convert.ToInt32(paramIdCompra.Value);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public int obtenerComprasDiarias()
        {
            int compras = 0;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT COUNT(*) FROM Compras WHERE CAST(Fecha AS DATE) = CAST(GETDATE() AS DATE) AND EstatusRegistro = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        compras = (int)cmd.ExecuteScalar();
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
            return compras;
        }
    }
}
