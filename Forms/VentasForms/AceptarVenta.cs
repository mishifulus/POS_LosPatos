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

namespace LosPatosSystem.Forms.VentasForms
{
    public partial class AceptarVenta: Form
    {
        public int IdUsuario { get; set; }
        public double Total { get; set; }

        public DataTable detalleVenta;
        public int IdVenta { get; set; }
        public string NombreUsuario { get; set; }

        public AceptarVenta(int IdUsuario, double Total, DataTable detalleVenta, int idVenta, string nombreUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            this.Total = Total;
            this.detalleVenta = detalleVenta;
            this.IdVenta = idVenta;
            this.NombreUsuario = nombreUsuario;
        }

        private void AceptarVenta_Load(object sender, EventArgs e)
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
            if (Convert.ToDouble(txtRecibido.Text) < Convert.ToDouble(txtTotal.Text))
            {
                MessageBox.Show("Ingrese la cantidad completa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable tablaSoloParaBD = detalleVenta.DefaultView.ToTable(false, "IdProducto", "Cantidad", "PrecioUnitario");

            VentaDAO ventaDAO = new VentaDAO();
            int idVenta = 0;
            bool result = ventaDAO.RegistrarVenta(Total, (int)cmbTipoPago.SelectedValue, IdUsuario, tablaSoloParaBD, out idVenta);
            if (result)
            {
                // GENERAR TICKET
                string ticket = GenerarContenidoTicket("VENTA", IdVenta, IdUsuario, NombreUsuario, detalleVenta, Convert.ToDouble(txtRecibido.Text), Convert.ToDouble(txtTotal.Text), Convert.ToDouble(txtCambio.Text));
                Console.WriteLine(ticket);

                MessageBox.Show("Venta registrada correctamente", "Venta registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCambio.Text = "$0";
                txtTotal.Text = "$0";
                cmbTipoPago.SelectedIndex = 0;
                txtRecibido.Text = string.Empty;
                detalleVenta.Clear();

                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

        private string GenerarContenidoTicket(string tipo, int folio, int cajero, string nombreCajero, DataTable detalle, double recibido, double total, double cambio)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("  DÉPOSITO: LOS PATOS ");
            sb.AppendLine("  DIRECCIÓN ");
            sb.AppendLine("  --------------------");
            sb.AppendLine($"Tipo: {tipo.ToUpper()}");
            sb.AppendLine($"Folio: {folio}");
            sb.AppendLine($"Fecha: {DateTime.Now}");
            sb.AppendLine($"Cajero: {cajero} - {nombreCajero.ToUpper()}");
            sb.AppendLine("----------------------------");
            sb.AppendLine("Cant Código Producto        Subtotal");

            foreach (DataRow row in detalle.Rows)
            {
                string producto = row["Producto"].ToString().PadRight(14).Substring(0, 14);
                string codigo = row["Codigo"].ToString();
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                double subtotal = Convert.ToDouble(row["Descuento"]) * cantidad;

                sb.AppendLine($"{cantidad.ToString().PadRight(4)} {codigo}  {producto} ${subtotal.ToString("0.00")}");
            }

            sb.AppendLine("----------------------------");
            sb.AppendLine($"TOTAL:           ${total.ToString("0.00")}");
            sb.AppendLine($"RECIBIDO:        ${recibido.ToString("0.00")}");
            sb.AppendLine($"CAMBIO:          ${cambio.ToString("0.00")}");
            sb.AppendLine("GRACIAS POR SU COMPRA");

            return sb.ToString();
        }
    }
}
