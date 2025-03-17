using LosPatosSystem.Data;
using LosPatosSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosPatosSystem.Forms.UsuariosForms
{
    public partial class RolesForm: Form
    {
        public RolesForm()
        {
            InitializeComponent();
        }

        private void RolesForm_Load(object sender, EventArgs e)
        {
            ObtenerRoles();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color borderColor = Color.FromArgb(11, 25, 86);
            int borderWidth = 2;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RolesForm.ActiveForm.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreRol = txtNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombreRol))
            {
                MessageBox.Show("El nombre del rol es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtIdRol.Text))
            {
                GuardarRol(nombreRol);
            }
            else
            {
                int idRol = Convert.ToInt32(txtIdRol.Text);
                ActualizarRol(nombreRol, idRol);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtIdRol.Text = string.Empty;
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idRol = Convert.ToInt32(dgvRoles.Rows[e.RowIndex].Cells["IdRol"].Value);
                string nombreRol = dgvRoles.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                txtIdRol.Text = idRol.ToString();
                txtNombre.Text = nombreRol;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdRol.Text))
            {
                MessageBox.Show("Seleccione un rol para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int idRol = Convert.ToInt32(txtIdRol.Text);
                EliminarRol(idRol);
            }
        }

        private void ObtenerRoles()
        {
            RolDAO rolDAO = new RolDAO();
            DataSet dataSet = rolDAO.selectRol("L", 0, null);
            dgvRoles.DataSource = dataSet.Tables["Rol"];

            dgvRoles.Columns["IdRol"].Visible = false;
            dgvRoles.Columns["Nombre"].HeaderText = "Rol";
            dgvRoles.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvRoles.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRoles.Columns["EstatusRegistro"].Visible = false;
        }

        private void GuardarRol(string nombreRol)
        {
            Rol rol = new Rol();
            rol.Nombre = nombreRol;

            RolDAO rolDAO = new RolDAO();
            rolDAO.CrudRol(rol, "C");

            MessageBox.Show("Rol agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = string.Empty;
            ObtenerRoles();
        }

        private void ActualizarRol(string nombreRol, int idRol)
        {
            Rol rol = new Rol();
            rol.IdRol = idRol;
            rol.Nombre = nombreRol;

            RolDAO rolDAO = new RolDAO();
            rolDAO.CrudRol(rol, "U");

            MessageBox.Show("Rol actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = string.Empty;
            txtIdRol.Text = string.Empty;
            ObtenerRoles();
        }

        private void EliminarRol(int idRol)
        {
            Rol rol = new Rol();
            rol.IdRol = idRol;

            RolDAO rolDAO = new RolDAO();
            rolDAO.CrudRol(rol, "D");
            MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombre.Text = string.Empty;
            txtIdRol.Text = string.Empty;
            ObtenerRoles();
        }
    }
}
