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
    class DevolucionDAO
    {
        public int ObtenerIdDevolucion()
        {
            int IdDevolucion = 0;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT ISNULL(MAX(IdDevolucion), 0) + 1 FROM Devoluciones";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        IdDevolucion = (int)cmd.ExecuteScalar();
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
            return IdDevolucion;
        }

        public int ExisteDevolucion(int idVenta)
        {
            int existe = 0;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT ISNULL(MAX(IdDevolucion), 0) FROM Devoluciones WHERE IdVenta = @IdVenta";
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
                    string query = @"SELECT dv.IdProducto,p.Codigo, p.Nombre AS Producto, p.Descripcion, dv.Cantidad, dv.PrecioUnitario, dv.Subtotal
                     FROM DetalleVentas dv
                     INNER JOIN Productos p ON dv.IdProducto = p.IdProducto
                     WHERE dv.IdVenta = @IdVenta";
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

        public bool RegistrarDevolucion(int idVenta, string motivo, int idUsuario, DataTable productos, out int idDevolucion)
        {
            idDevolucion = 0;
            bool resultado = false;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try 
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarDevolucion", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                        cmd.Parameters.AddWithValue("@Motivo", motivo);
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        SqlParameter paramProductos = cmd.Parameters.AddWithValue("@ProductosDevoluciones", productos);
                        paramProductos.SqlDbType = SqlDbType.Structured;

                        SqlParameter paramIdDevolucion = new SqlParameter("@IdDevolucion", SqlDbType.Int);
                        paramIdDevolucion.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paramIdDevolucion);

                        cmd.ExecuteNonQuery();
                        idDevolucion = Convert.ToInt32(paramIdDevolucion.Value);
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
