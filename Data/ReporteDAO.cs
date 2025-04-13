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
    class ReporteDAO
    {
        public DataSet ObtenerReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet reporte = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteVentasFechas", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(reporte, "VentasDTO");
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
            return reporte;
        }

        public DataSet ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet reporte = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteProductosMasVendidos", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(reporte, "ProductosDTO");
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
            return reporte;
        }

        public DataSet ObtenerReporteVentasPromociones(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet reporte = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteVentasConPromociones", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(reporte, "VentasPromocionesDTO");
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
            return reporte;
        }

        public DataSet ObtenerReporteComprasFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet reporte = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteComprasPorFecha", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(reporte, "ComprasDTO");
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
            return reporte;
        }

        public DataSet ObtenerReporteBalanceDiario(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet reporte = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteBalanceDiario", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(reporte, "BalanceDiarioDTO");
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
            return reporte;
        }

        public DataSet ObtenerReporteDevoluciones(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet reporte = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteDevoluciones", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(reporte, "DevolucionesDTO");
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
            return reporte;
        }
    }
}
