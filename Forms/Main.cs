using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LosPatosSystem.Data;

namespace LosPatosSystem.Forms
{
    public partial class Main : Form
    {
        private int IdSesion { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Username { get; set; }


        public Main(int IdSesion, int IdUsuario, string Username, int IdRol)
        {
            InitializeComponent();

            Rectangle screenBounds = Screen.PrimaryScreen.WorkingArea;
            this.MaximizedBounds = screenBounds;

            this.WindowState = FormWindowState.Maximized;
            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;

            this.IdSesion = IdSesion;
            this.IdUsuario = IdUsuario;
            this.IdRol = IdRol;
            this.Username = Username;

            txtUsuario.Text = Username;
            txtTitle.Text = string.Empty;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Main_Load(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Forms.Inicio());
            if (IdRol != 1)
            {
                btnFUsuarios.Visible = false;
                btnFAjustes.Visible = false;
                btnFReportes.Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SesionDAO sesionDAO = new SesionDAO();

            sesionDAO.CerrarSesion(IdUsuario, IdSesion);
            MessageBox.Show("¡Adiós! Tu sesión se ha cerrado correctamente", "Cerrar Sesión");

            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;

            Rectangle screenBounds = Screen.PrimaryScreen.WorkingArea;
            int x = (screenBounds.Width - this.Width) / 2;
            int y = (screenBounds.Height - this.Height) / 2;

            this.Location = new Point(x, y);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnFProductos_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "PRODUCTOS";
            AbrirFormInPanel(new Forms.ProductosVista(IdUsuario, IdRol));
        }

        private void panelUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            SesionDAO sesionDAO = new SesionDAO();

            sesionDAO.CerrarSesion(IdUsuario, IdSesion);
            MessageBox.Show("¡Adiós! Tu sesión se ha cerrado correctamente", "Cerrar Sesión");

            Application.Exit();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            SesionDAO sesionDAO = new SesionDAO();

            sesionDAO.CerrarSesion(IdUsuario, IdSesion);
            MessageBox.Show("¡Adiós! Tu sesión se ha cerrado correctamente", "Cerrar Sesión");

            Application.Exit();
        }

        private void txtUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            SesionDAO sesionDAO = new SesionDAO();

            sesionDAO.CerrarSesion(IdUsuario, IdSesion);
            MessageBox.Show("¡Adiós! Tu sesión se ha cerrado correctamente", "Cerrar Sesión");

            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "INICIO";
            AbrirFormInPanel(new Forms.Inicio());
        }

        private void btnFUsuarios_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "USUARIOS";
            AbrirFormInPanel(new Forms.UsuariosForms.UsuariosVista());
        }

        private void btnFPromociones_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "PROMOCIONES";
            AbrirFormInPanel(new Forms.PromocionesForms.PromocionesVista(IdUsuario, IdRol));
        }

        private void btnFCompras_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "COMPRAS";
            AbrirFormInPanel(new Forms.ComprasForms.ComprasVista(IdUsuario, Username));
        }

        private void btnFVentas_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "VENTAS";
            AbrirFormInPanel(new Forms.VentasForms.VentasVista(IdUsuario, Username));
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "DEVOLUCIONES";
            AbrirFormInPanel(new Forms.DevolucionesForms.DevolucionesVista(IdUsuario, Username));
        }

        private void btnFCaja_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "CAJA";
            AbrirFormInPanel(new Forms.CajaForms.CajaVista(IdUsuario, IdRol));
        }
    }
}
