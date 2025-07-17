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
    class RetornoEnvaseDAO
    {
        public int ObtenerIdRetorno()
        {
            int IdRetorno = 0;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT ISNULL(MAX(IdRetorno), 0) + 1 FROM RetornoEnvases";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        IdRetorno = (int)cmd.ExecuteScalar();
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
            return IdRetorno;
        }

        public int ExisteRetorno(int idVenta)
        {
            int existe = 0;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT ISNULL(MAX(IdRetorno), 0) FROM RetornoEnvases WHERE FolioVenta = @IdVenta";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                        existe = (int)cmd.ExecuteScalar();
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
            return existe;
        }

        public DataTable ObtenerProductosVenta(int idVenta)
        {
            DataTable dtProductos = new DataTable();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = @"SELECT dv.IdProducto,p.Codigo, p.Nombre AS Producto, p.Descripcion, dv.Cantidad, dv.ImporteEnvase, dv.ImporteEnvase * dv.Cantidad AS Subtotal
                     FROM DetalleVentas dv
                     INNER JOIN Productos p ON dv.IdProducto = p.IdProducto
                     WHERE dv.IdVenta = @IdVenta AND p.TieneImporte = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtProductos);
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
            return dtProductos;
        }

        public bool RegistrarRetorno(int folioVenta, int idUsuario, DataTable productos, out int idRetorno)
        {
            idRetorno = 0;
            bool resultado = false;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarRetornoEnvases", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FolioVenta", folioVenta);
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        SqlParameter paramProductos = cmd.Parameters.AddWithValue("@Detalle", productos);
                        paramProductos.SqlDbType = SqlDbType.Structured;

                        SqlParameter paramIdRetorno = new SqlParameter("@IdRetorno", SqlDbType.Int);
                        paramIdRetorno.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paramIdRetorno);

                        cmd.ExecuteNonQuery();
                        idRetorno = Convert.ToInt32(paramIdRetorno.Value);
                        resultado = true;
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
                return resultado;
            }
        }
    }
}
