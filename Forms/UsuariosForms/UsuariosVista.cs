using LosPatosSystem.Data;
using LosPatosSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosPatosSystem.Forms.UsuariosForms
{
    public partial class UsuariosVista: Form
    {
        public UsuariosVista()
        {
            InitializeComponent();
            this.Resize += new EventHandler(UsuariosVista_Resize);
        }

        private void UsuariosVista_Load(object sender, EventArgs e)
        {
            ObtenerUsuarios();
        }

        private void UsuariosVista_Resize(object sender, EventArgs e)
        {
            if (dgvUsuarios.Width == 978 && dgvUsuarios.Height == 633)
            {
                dgvUsuarios.Width = dgvUsuarios.Width + 610;
                dgvUsuarios.Height = dgvUsuarios.Height + 200;
            }
            else
            {
                dgvUsuarios.Width = 978;
                dgvUsuarios.Height = 633;
            }
        }

        private void ObtenerUsuarios()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            DataSet dataSet = usuarioDAO.selectUsuario("L", null);
            dgvUsuarios.DataSource = dataSet.Tables["Usuario"];

            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["IdRol"].Visible = false;
            dgvUsuarios.Columns["APaterno"].HeaderText = "Apellido Paterno";
            dgvUsuarios.Columns["AMaterno"].HeaderText = "Apellido Materno";
            dgvUsuarios.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvUsuarios.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvUsuarios.Columns["EstatusRegistro"].HeaderCell.Value = "Estatus";
        }

        private void ObtenerUsuariosInactivos()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            DataSet dataSet = usuarioDAO.selectUsuario("I", null);
            dgvUsuarios.DataSource = dataSet.Tables["Usuario"];

            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["IdRol"].Visible = false;
            dgvUsuarios.Columns["APaterno"].HeaderText = "Apellido Paterno";
            dgvUsuarios.Columns["AMaterno"].HeaderText = "Apellido Materno";
            dgvUsuarios.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvUsuarios.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvUsuarios.Columns["EstatusRegistro"].HeaderCell.Value = "Estatus";
        }

        private void EliminarUsuario(int idUsuario)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = idUsuario;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.CrudUsuario(usuario, "D");

            txtIdUsuario.Text = string.Empty;

            ObtenerUsuarios();
        }

        private void ActivarUsuario(int idUsuario)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = idUsuario;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.CrudUsuario(usuario, "A");

            txtIdUsuario.Text = string.Empty;

            ObtenerUsuariosInactivos();
        }

        private void BuscarUsuario(Usuario usuario)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            DataSet dataSet = usuarioDAO.selectUsuario("S", usuario);

            dgvUsuarios.DataSource = dataSet.Tables["Usuario"];

            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["IdRol"].Visible = false;
            dgvUsuarios.Columns["APaterno"].HeaderText = "Apellido Paterno";
            dgvUsuarios.Columns["AMaterno"].HeaderText = "Apellido Materno";
            dgvUsuarios.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvUsuarios.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvUsuarios.Columns["EstatusRegistro"].HeaderCell.Value = "Estatus";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            UsuarioForm usuarioForm = new UsuarioForm("Agregar", 0);
            usuarioForm.NuevoUsuario += ObtenerUsuarios;
            usuarioForm.Show();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            RolesForm rolesForm = new RolesForm();
            rolesForm.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
            UsuarioForm usuarioForm = new UsuarioForm("Editar", IdUsuario);
            usuarioForm.NuevoUsuario += ObtenerUsuarios;
            usuarioForm.Show();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells["IdUsuario"].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
                EliminarUsuario(IdUsuario);
            }
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            ObtenerUsuariosInactivos();

            btnAgregar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnCambiarPass.Visible = false;
            btnInactivos.Visible = false;
            btnRoles.Visible = false;
            btnActivar.Visible = true;
            btnUsuariosActivos.Visible = true;
            txtBuscar.Visible = false;
            btnBuscar.Visible = false;
            panelBusqueda.Visible = false;
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario para activar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
                ActivarUsuario(IdUsuario);
            }
        }

        private void btnUsuariosActivos_Click(object sender, EventArgs e)
        {
            ObtenerUsuarios();

            btnAgregar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnCambiarPass.Visible = true;
            btnInactivos.Visible = true;
            btnRoles.Visible = true;
            btnActivar.Visible = false;
            btnUsuariosActivos.Visible = false;
            txtBuscar.Visible = true;
            btnBuscar.Visible = true;
            panelBusqueda.Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtBuscar.Text))
            {
                ObtenerUsuarios();
            }
            else
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = txtBuscar.Text;
                usuario.APaterno = txtBuscar.Text;
                usuario.AMaterno = txtBuscar.Text;
                usuario.Username = txtBuscar.Text;

                BuscarUsuario(usuario);
            }
        }

        private void btnCambiarPass_Click(object sender, EventArgs e)
        {
            int IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
            if (IdUsuario == 0)
            {
                CambiarPass cambiarPass = new CambiarPass(IdUsuario);
                cambiarPass.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para cambiar contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (string.IsNullOrEmpty(txtBuscar.Text))
                {
                    ObtenerUsuarios();
                }
                else
                {
                    Usuario usuario = new Usuario();
                    usuario.Nombre = txtBuscar.Text;
                    usuario.APaterno = txtBuscar.Text;
                    usuario.AMaterno = txtBuscar.Text;
                    usuario.Username = txtBuscar.Text;

                    BuscarUsuario(usuario);
                }
            }
        }
    }
}
