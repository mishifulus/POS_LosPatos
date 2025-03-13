using LosPatosSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace LosPatosSystem.Data
{
    class ProductoDAO
    {
        public DataSet selectProducto(string pAction, Producto producto)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spProducto", conexion))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Accion", pAction));
                        if (producto != null)
                        {
                            cmd.Parameters.Add(new SqlParameter("@Nombre", producto.Nombre));
                            cmd.Parameters.Add(new SqlParameter("@Codigo", producto.Codigo));
                            cmd.Parameters.Add(new SqlParameter("@IdUnidad", producto.IdUnidad));
                            cmd.Parameters.Add(new SqlParameter("@Descripcion", producto.Descripcion));
                            cmd.Parameters.Add(new SqlParameter("@IdCategoria", producto.IdCategoria));
                        }

                        dataAdapter.SelectCommand = cmd;
                        dataAdapter.Fill(dataSet, "Producto");
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
                return dataSet;
            }
        }

        public void CrudProducto(Producto producto, string pAction)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spProducto", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Accion", pAction);
                        cmd.Parameters.AddWithValue("@Id", producto.IdUnidad);
                        cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        cmd.Parameters.AddWithValue("@IdUnidad", producto.IdUnidad);
                        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                        cmd.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                        cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                        cmd.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
                        cmd.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
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

        public string RevisarStock(int IdProducto)
        {
            string Mensaje = string.Empty;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spRevisarStock", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        cmd.Parameters.AddWithValue("@IdProducto", IdProducto);

                        SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 40)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(paramMensaje);

                        cmd.ExecuteNonQuery();

                        // Obtener valores de salida
                        Mensaje = paramMensaje.Value.ToString();

                        return Mensaje;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
    }
}
