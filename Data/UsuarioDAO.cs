using LosPatosSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace LosPatosSystem.Data
{
    class UsuarioDAO
    {
        public DataSet selectUsuario(string pAction, Usuario usuario)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spUsuarios", conexion))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Accion", pAction));
                        if (usuario != null)
                        {
                            cmd.Parameters.Add(new SqlParameter("@Id", usuario.IdUsuario));
                            cmd.Parameters.Add(new SqlParameter("@Nombre", usuario.Nombre));
                            cmd.Parameters.Add(new SqlParameter("@APaterno", usuario.APaterno));
                            cmd.Parameters.Add(new SqlParameter("@AMaterno", usuario.AMaterno));
                            cmd.Parameters.Add(new SqlParameter("@Username", usuario.Username));
                            cmd.Parameters.Add(new SqlParameter("@IdRol", usuario.IdRol));
                        }

                        dataAdapter.SelectCommand = cmd;
                        dataAdapter.Fill(dataSet, "Usuario");
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

        public void CrudUsuario(Usuario usuario, string pAction)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spUsuarios", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Accion", pAction);
                        cmd.Parameters.AddWithValue("@Id", usuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@APaterno", usuario.APaterno);
                        cmd.Parameters.AddWithValue("@AMaterno", usuario.AMaterno);
                        cmd.Parameters.AddWithValue("@Username", usuario.Username);
                        cmd.Parameters.AddWithValue("@Pass", usuario.Pass);
                        cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);
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

        public void ActualizarPass(int IdUsuario, string Pass)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("spActualizarPass", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@NewPass", Pass);
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
