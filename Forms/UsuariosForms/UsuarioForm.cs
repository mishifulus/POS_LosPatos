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
    public partial class UsuarioForm: Form
    {

        string Accion = "";
        int IdUsuario = 0;

        public event Action NuevoUsuario;

        public UsuarioForm(string Accion, int IdUsuario)
        {
            InitializeComponent();
            this.Accion = Accion;
            this.IdUsuario = IdUsuario;

            txtIdUsuario.Text = IdUsuario.ToString();
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            CargarRoles();

            if (Accion == "Editar" && IdUsuario > 0)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = IdUsuario;

                UsuarioDAO usuarioDAO = new UsuarioDAO();
                DataSet dataSet = usuarioDAO.selectUsuario("R", usuario);
                DataTable dataTable = dataSet.Tables["Usuario"];

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    txtNombre.Text = row["Nombre"].ToString();
                    txtAPaterno.Text = row["APaterno"].ToString();
                    txtAMaterno.Text = row["AMaterno"].ToString();
                    txtUsername.Text = row["Username"].ToString();
                    cmbRol.SelectedValue = row["IdRol"];
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtPass1.Visible = false;
                txtPass2.Visible = false;
                lblPass1.Visible = false;
                lblPass2.Visible = false;
                btnPass1.Visible = false;
                btnPass2.Visible = false;
            }
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

        private void CargarRoles()
        {
            RolDAO rolDAO = new RolDAO();
            DataSet dataSet = rolDAO.selectRol("L", 0, null);
            cmbRol.DataSource = dataSet.Tables["Rol"];

            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "IdRol";
        }

        private void GuardarUsuario(Usuario usuario)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.CrudUsuario(usuario, "C");
            MessageBox.Show("Usuario guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtIdUsuario.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtAPaterno.Text = string.Empty;
            txtAMaterno.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPass1.Text = string.Empty;
            txtPass2.Text = string.Empty;
            cmbRol.SelectedIndex = 0;
            
            NuevoUsuario?.Invoke();

            this.Close();
        }

        private void ActualizarUsuario(Usuario usuario)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.CrudUsuario(usuario, "U");
            MessageBox.Show("Usuario actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            txtIdUsuario.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtAPaterno.Text = string.Empty;
            txtAMaterno.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPass1.Text = string.Empty;
            txtPass2.Text = string.Empty;
            cmbRol.SelectedIndex = 0;

            NuevoUsuario?.Invoke();

            this.Close();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtAPaterno.Text = string.Empty;
            txtAMaterno.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPass1.Text = string.Empty;
            txtPass2.Text = string.Empty;
            cmbRol.SelectedIndex = 0;

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string APaterno = txtAPaterno.Text;
            string AMaterno = txtAMaterno.Text;
            string Username = txtUsername.Text;
            string Pass = txtPass1.Text;
            string Pass2 = txtPass2.Text;
            int IdRol = (int)cmbRol.SelectedValue;

            if(Nombre == string.Empty || APaterno == string.Empty || AMaterno == string.Empty || Username == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtIdUsuario.Text == string.Empty)
            {
                if (Pass == string.Empty || Pass2 == string.Empty)
                {
                    MessageBox.Show("Las contraseñas son obligatorias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (Pass != Pass2)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario usuario = new Usuario();
            usuario.Nombre = Nombre;
            usuario.APaterno = APaterno;
            usuario.AMaterno = AMaterno;
            usuario.Username = Username;
            usuario.Pass = Pass;
            usuario.IdRol = IdRol;

            if (Accion == "Agregar")
            {
                GuardarUsuario(usuario);
            }
            else if (Accion == "Editar" && !string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                usuario.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
                ActualizarUsuario(usuario);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtAPaterno.Text = string.Empty;
            txtAMaterno.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPass1.Text = string.Empty;
            txtPass2.Text = string.Empty;
            cmbRol.SelectedIndex = 0;

            this.Close();
        }

        private void btnPass1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPass1.UseSystemPasswordChar = false;
        }

        private void btnPass1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPass1.UseSystemPasswordChar = true;
        }

        private void btnPass2_MouseDown(object sender, MouseEventArgs e)
        {
            txtPass2.UseSystemPasswordChar = false;
        }

        private void btnPass2_MouseUp(object sender, MouseEventArgs e)
        {
            txtPass2.UseSystemPasswordChar = true;
        }
    }
}
