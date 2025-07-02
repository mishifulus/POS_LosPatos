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

namespace LosPatosSystem.Forms.CajaForms
{
    public partial class MovimientoForm : Form
    {
        public int IdUsuario { get; set; }

        public event Action NuevoMovimiento;

        public MovimientoForm(int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
        }

        private void MovimientoForm_Load(object sender, EventArgs e)
        {
            CargarTipos();
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

        private void CargarTipos()
        {
            Dictionary<int, string> tipos = new Dictionary<int, string>
            {
                { 1, "Ingreso" },
                { 0, "Egreso" }
            };
            cmbTipo.DataSource = new BindingSource(tipos, null);
            cmbTipo.DisplayMember = "Value";
            cmbTipo.ValueMember = "Key";
        }

        private void GuardarIngreso(string monto, string descripcion)
        {
            try
            {
                CajaDAO cajaDAO = new CajaDAO();
                cajaDAO.RegistrarIngreso(Convert.ToDouble(monto), descripcion, IdUsuario);

                MessageBox.Show("Ingreso guardada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMonto.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                cmbTipo.SelectedIndex = 0;

                NuevoMovimiento?.Invoke();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el ingreso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarEgreso(string monto, string descripcion)
        {
            try
            {
                CajaDAO cajaDAO = new CajaDAO();
                cajaDAO.RegistrarEgreso(Convert.ToDouble(monto), descripcion, IdUsuario);

                MessageBox.Show("Egreso guardada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMonto.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                cmbTipo.SelectedIndex = 0;

                NuevoMovimiento?.Invoke();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el egreso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            txtMonto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cmbTipo.SelectedIndex = 0;

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtMonto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cmbTipo.SelectedIndex = 0;

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int tipo = (int)cmbTipo.SelectedValue;
            

            if (txtMonto.Text.Length == 0 || txtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Ingresa la información del monto y la descripción del movimiento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tipo == 1)
            {
                GuardarIngreso(txtMonto.Text, txtDescripcion.Text);
            }

            if (tipo == 0)
            {
                GuardarEgreso(txtMonto.Text, txtDescripcion.Text);
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Evitar que se ingresen varios puntos decimales
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
