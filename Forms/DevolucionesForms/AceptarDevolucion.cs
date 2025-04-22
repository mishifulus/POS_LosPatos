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

namespace LosPatosSystem.Forms.DevolucionesForms
{
    public partial class AceptarDevolucion: Form
    {
        public int IdUsuario {  get; set; }

        public double Total {  get; set; }

        public string Motivo { get; set; }

        public int IdVenta { get; set; }

        public int IdDevolucion { get; set; }
        public string NombreUsuario { get; set; }

        public DataTable detalleDevolucion;

        public AceptarDevolucion(int idUsuario, double total, string motivo, int idVenta, DataTable detalleDevolucion, int idDevolucion, string nombreUsuario)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
            Total = total;
            Motivo = motivo;
            IdVenta = idVenta;
            IdDevolucion = idDevolucion;
            NombreUsuario = nombreUsuario;
            this.detalleDevolucion = detalleDevolucion;
        }

        private void AceptarDevolucion_Load(object sender, EventArgs e)
        {
            txtTotal.Text = Total.ToString();
            txtMotivo.Text = Motivo;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTotal.Text = "$0";
            txtMotivo.Text = String.Empty;

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (detalleDevolucion == null || detalleDevolucion.Columns.Count == 0)
            {
                Console.WriteLine("Error: La tabla de productos no tiene columnas.");
                return;
            }

            DataTable tablaSoloParaBD = detalleDevolucion.DefaultView.ToTable(false, "IdProducto", "Cantidad", "PrecioUnitario");

            DevolucionDAO devolucionDAO = new DevolucionDAO();
            int idDevolucion = 0;
            bool result = devolucionDAO.RegistrarDevolucion(IdVenta, txtMotivo.Text, IdUsuario, tablaSoloParaBD, out idDevolucion);

            if (result)
            {
                // GENERAR TICKET
                string ticket = GenerarContenidoTicket("DEVOLUCIÓN", IdDevolucion, IdUsuario, NombreUsuario, detalleDevolucion, 0, Convert.ToDouble(txtTotal.Text), 0);
                Console.WriteLine(ticket);

                MessageBox.Show("Devolución registrada correctamente", "Devolución registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTotal.Text = "$0";
                txtMotivo.Text = String.Empty;
                detalleDevolucion.Clear();

                this.Close();

            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar la devolución", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                double subtotal = Convert.ToDouble(row["PrecioUnitario"]) * cantidad;

                sb.AppendLine($"{cantidad.ToString().PadRight(4)} {codigo}  {producto} ${subtotal.ToString("0.00")}");
            }

            sb.AppendLine("----------------------------");
            sb.AppendLine($"TOTAL:          ${total.ToString("0.00")}");
            sb.AppendLine("GRACIAS POR SU COMPRA");

            return sb.ToString();
        }
    }
}
