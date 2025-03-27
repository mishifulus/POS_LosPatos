using LosPatosSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosPatosSystem.Data
{
    class CajaDAO
    {
        public DataSet obtenerMovimientosDiarios()
        {
            DataSet dtMovimientos = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT M.IdMovimiento, M.Fecha, M.TipoMovimiento, CASE WHEN M.TipoMovimiento = 1 THEN 'Ingreso' WHEN M.TipoMovimiento = 0 THEN 'Egreso' ELSE 'Desconocido' END AS Movimiento, M.Monto, M.Descripcion, M.IdUsuario, U.Username, M.EstatusRegistro " +
                        "FROM Caja M LEFT JOIN Usuarios U ON M.IdUsuario = U.IdUsuario " +
                        "WHERE CONVERT(DATE, M.Fecha) = CONVERT(DATE, GETDATE()) AND M.EstatusRegistro = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dtMovimientos, "Caja");
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
            return dtMovimientos;
        }

        public DataSet obtenerMovimientosByTipo(int tipoMovimiento)
        {
            DataSet dtMovimientos = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT M.IdMovimiento, M.Fecha, M.TipoMovimiento, CASE WHEN M.TipoMovimiento = 1 THEN 'Ingreso' WHEN M.TipoMovimiento = 0 THEN 'Egreso' ELSE 'Desconocido' END AS Movimiento, M.Monto, M.Descripcion, M.IdUsuario, U.Username, M.EstatusRegistro " +
                        "FROM Caja M " +
                        "LEFT JOIN Usuarios U ON M.IdUsuario = U.IdUsuario " +
                        "WHERE CONVERT(DATE, M.Fecha) = CONVERT(DATE, GETDATE()) AND M.TipoMovimiento = @TipoMovimiento AND M.EstatusRegistro = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@TipoMovimiento", tipoMovimiento);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dtMovimientos, "Caja"); ;
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
            return dtMovimientos;
        }

        public double obtenerTotales(int tipoMovimiento)
        {
            double Total = 0; 

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT ISNULL(SUM(CASE WHEN TipoMovimiento = @TipoMovimiento THEN Monto ELSE 0 END),0) AS Total " +
                        "FROM Caja " +
                        "WHERE CONVERT(DATE, Fecha) = CONVERT(DATE, GETDATE()) AND EstatusRegistro = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@TipoMovimiento", tipoMovimiento);
                        Total = Convert.ToDouble(cmd.ExecuteScalar());
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
            return Total;
        }

        public double obtenerBalance()
        {
            double Balance = 0;

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT ISNULL((SUM(CASE WHEN TipoMovimiento = 1 THEN Monto ELSE 0 END) - SUM(CASE WHEN TipoMovimiento = 0 THEN Monto ELSE 0 END)),0) AS Balance " +
                        "FROM Caja " +
                        "WHERE CONVERT(DATE, Fecha) = CONVERT(DATE, GETDATE()) AND EstatusRegistro = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        Balance = Convert.ToDouble(cmd.ExecuteScalar());
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
            return Balance;
        }

        public void RegistrarIngreso(double Monto, string Descripcion, int IdUsuario)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarIngresoCaja", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Monto", Monto);
                        cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public void RegistrarEgreso(double Monto, string Descripcion, int IdUsuario)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarEgresoCaja", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Monto", Monto);
                        cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public DataSet obtenerMovimientoById(int IdMovimiento)
        {
            DataSet dtMovimientos = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    string query = "SELECT M.IdMovimiento, M.Fecha, M.TipoMovimiento, M.Monto, M.Descripcion " +
                        "FROM Caja M " +
                        "WHERE M.IdMotivacion = @IdMovimiento";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdMovimiento", IdMovimiento);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dtMovimientos, "Caja");
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
            return dtMovimientos;
        }

    }
}
