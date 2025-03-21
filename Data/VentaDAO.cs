using LosPatosSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPatosSystem.Data
{
    class VentaDAO
    {
        public int ObtenerIdVenta()
        {
            int IdVenta = 0;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT ISNULL(MAX(IdVenta), 0) + 1 FROM Ventas";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        IdVenta = (int)cmd.ExecuteScalar();
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
            return IdVenta;
        }

        public bool RegistrarVenta(double total, int tipoPago, int idUsuario, DataTable productos, out int idVenta)
        {
            idVenta = 0;

            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.Parameters.AddWithValue("@TipoPago", tipoPago);
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        SqlParameter paramProductos = cmd.Parameters.AddWithValue("@Productos", productos);
                        paramProductos.SqlDbType = SqlDbType.Structured;

                        SqlParameter paramIdVenta = new SqlParameter("@IdVenta", SqlDbType.Int);
                        paramIdVenta.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paramIdVenta);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        idVenta = Convert.ToInt32(paramIdVenta.Value);
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

        public double AplicarPromocion(int idProducto, int cantidad, double precioVenta)
        {
            double descuentoAplicado = 0;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("sp_AplicarPromocion", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@PrecioVenta", precioVenta);

                    SqlParameter outputDescuento = new SqlParameter("@DescuentoAplicado", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(outputDescuento);

                    cmd.ExecuteNonQuery();
                    descuentoAplicado = Convert.ToDouble(outputDescuento.Value);
                }
            }

            return descuentoAplicado;
        }
    }
}
