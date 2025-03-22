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

namespace LosPatosSystem.Forms.DevolucionesForms
{
    public partial class AceptarDevolucion: Form
    {
        public int IdUsuario {  get; set; }

        public double Total {  get; set; }

        public string Motivo { get; set; }

        public int IdVenta { get; set; }

        public DataTable detalleDevolucion;

        public AceptarDevolucion(int idUsuario, double total, string motivo, int idVenta, DataTable detalleDevolucion)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
            Total = total;
            Motivo = motivo;
            IdVenta = idVenta;
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
            DevolucionDAO devolucionDAO = new DevolucionDAO();
            int idDevolucion = 0;
            bool result = devolucionDAO.RegistrarDevolucion(IdVenta, txtMotivo.Text, IdUsuario, detalleDevolucion, out idDevolucion);

            if (result)
            {
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
    }
}
