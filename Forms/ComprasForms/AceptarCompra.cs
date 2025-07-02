using LosPatosSystem.Data;
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

namespace LosPatosSystem.Forms.ComprasForms
{
    public partial class AceptarCompra: Form
    {
        public int IdUsuario { get; set; }
        public double Total { get; set; }

        public DataTable detalleCompra;

        public AceptarCompra(int IdUsuario, double Total, DataTable detalleCompra)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            this.Total = Total;
            this.detalleCompra = detalleCompra;
        }

        private void AceptarCompra_Load(object sender, EventArgs e)
        {
            CargarTipos();
            txtTotal.Text = Total.ToString();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

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
                { 1, "Efectivo" },
                { 2, "Tarjeta" },
                { 3, "Transferencia" }
            };
            cmbTipoPago.DataSource = new BindingSource(tipos, null);
            cmbTipoPago.DisplayMember = "Value";
            cmbTipoPago.ValueMember = "Key";
        }

        private void txtRecibido_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCambio.Text = "$0";
            txtTotal.Text = "$0";
            cmbTipoPago.SelectedIndex = 0;
            txtRecibido.Text = string.Empty;

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtRecibido.Text) < Convert.ToDouble(txtTotal.Text))
                {
                    MessageBox.Show("Ingrese la cantidad completa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CompraDAO compraDAO = new CompraDAO();
                int idCompra = 0;
                bool result = compraDAO.RegistrarCompra(Total, (int)cmbTipoPago.SelectedValue, IdUsuario, detalleCompra, out idCompra);
                if (result)
                {
                    MessageBox.Show("Compra registrada correctamente", "Compra registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCambio.Text = "$0";
                    txtTotal.Text = "$0";
                    cmbTipoPago.SelectedIndex = 0;
                    txtRecibido.Text = string.Empty;
                    detalleCompra.Clear();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un valor numérico válido para el monto recibido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecibido.Text))
            {
                txtCambio.Text = "$0";
                return;
            }

            double cambio = double.Parse(txtRecibido.Text) - Total;
            txtCambio.Text = cambio.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
