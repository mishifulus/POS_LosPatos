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
    public partial class CambiarPass: Form
    {
        int IdUsuario = 0;
        public CambiarPass(int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;

            txtIdUsuario.Text = IdUsuario.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Text = string.Empty;
            txtPass1.Text = string.Empty;
            txtPass2.Text = string.Empty;

            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Text = string.Empty;
            txtPass1.Text = string.Empty;
            txtPass2.Text = string.Empty;

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string pass1 = txtPass1.Text;
            string pass2 = txtPass2.Text;
            int IdUsuario = Convert.ToInt32(txtIdUsuario.Text);

            if (pass1 == string.Empty || pass2 == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pass1 != pass2)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario usuario = new Usuario();
            usuario.IdUsuario = IdUsuario;
            usuario.Pass = pass1;

            CambiarContraseña(usuario);

        }

        private void CambiarContraseña(Usuario usuario)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.ActualizarPass(usuario.IdUsuario, usuario.Pass);
            MessageBox.Show("Contraseña actualizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtIdUsuario.Text = string.Empty;
            txtPass1.Text = string.Empty;
            txtPass2.Text = string.Empty;

            this.Close();
        }
    }
}
