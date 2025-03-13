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
    class PromocionDAO
    {
        public DataSet selectPromocion(string pAction, Promocion promocion)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spPromociones", conexion))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Accion", pAction));
                        if (promocion != null)
                        {
                            cmd.Parameters.Add(new SqlParameter("@Nombre", promocion.Nombre));
                            cmd.Parameters.Add(new SqlParameter("@Descripcion", promocion.Descripcion));
                            cmd.Parameters.Add(new SqlParameter("@Tipo", promocion.Tipo));
                            cmd.Parameters.Add(new SqlParameter("@ProductoAsociado", promocion.ProductoAsociado));
                        }

                        dataAdapter.SelectCommand = cmd;
                        dataAdapter.Fill(dataSet, "Promocion");
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

        public void CrudPromocion(Promocion promocion, string pAction)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spPromociones", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Accion", pAction);
                        cmd.Parameters.AddWithValue("@Id", promocion.IdPromocion);
                        cmd.Parameters.AddWithValue("@Nombre", promocion.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", promocion.Descripcion);
                        cmd.Parameters.AddWithValue("@Tipo", promocion.Tipo);
                        cmd.Parameters.AddWithValue("@ValorDescuento", promocion.ValorDescuento);
                        cmd.Parameters.AddWithValue("@CantidadMinima", promocion.CantidadMinima);
                        cmd.Parameters.AddWithValue("@ProductoAsociado", promocion.ProductoAsociado);
                        cmd.Parameters.AddWithValue("@FechaInicio", promocion.FechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", promocion.FechaFin);
                        cmd.Parameters.AddWithValue("@IdUsuario", promocion.IdUsuario);
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
    }
}
