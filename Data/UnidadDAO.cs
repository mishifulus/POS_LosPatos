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
    class UnidadDAO
    {
        public DataSet selectUnidad(string pAction, int IdUnidad, string Nombre)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spUnidades", conexion))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Accion", pAction));
                        if (IdUnidad > 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@Id", IdUnidad));
                        }
                        if (Nombre != null)
                        {
                            cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                        }

                        dataAdapter.SelectCommand = cmd;
                        dataAdapter.Fill(dataSet, "Unidad");
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

        public void CrudUnidad(Unidad unidad, string pAction)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spUnidades", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Accion", pAction);
                        cmd.Parameters.AddWithValue("@Id", unidad.IdUnidad);
                        cmd.Parameters.AddWithValue("@Nombre", unidad.Nombre);
                        cmd.Parameters.AddWithValue("@IdUsuario", unidad.IdUsuario);
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
