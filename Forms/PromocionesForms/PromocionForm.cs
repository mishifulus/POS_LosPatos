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

namespace LosPatosSystem.Forms.PromocionesForms
{
    public partial class PromocionForm: Form
    {
        public int IdUsuario { get; set; }
        string Accion = "";
        int IdPromocion = 0;

        public event Action NuevaPromocion;
        public PromocionForm(string Accion, int IdUsuario, int IdPromocion)
        {
            InitializeComponent();
            this.Accion = Accion;
            this.IdUsuario = IdUsuario;
            this.IdPromocion = IdPromocion;

            txtIdPromocion.Text = IdPromocion.ToString();
        }

        private void PromocionForm_Load(object sender, EventArgs e)
        {
            CargarTipos();
            CargarProductos();

            if (Accion == "Editar" && IdPromocion > 0)
            {
                Promocion promocion = new Promocion();
                promocion.IdPromocion = IdPromocion;

                PromocionDAO promocionDAO = new PromocionDAO();
                DataSet dataSet = promocionDAO.selectPromocion("R", promocion);
                DataTable dataTable = dataSet.Tables["Promocion"];

                if (dataTable.Rows.Count > 0)
                {
                    txtNombre.Text = dataTable.Rows[0]["Nombre"].ToString();
                    txtDescripcion.Text = dataTable.Rows[0]["Descripcion"].ToString();
                    cmbTipo.SelectedValue = dataTable.Rows[0]["Tipo"];
                    txtValorDescuento.Text = dataTable.Rows[0]["ValorDescuento"].ToString();
                    txtCantidadMinima.Text = dataTable.Rows[0]["CantidadMinima"].ToString();
                    cmbProductoAsociado.SelectedValue = dataTable.Rows[0]["ProductoAsociado"].ToString();
                    dtpFechaInicio.Value = Convert.ToDateTime(dataTable.Rows[0]["FechaInicio"].ToString());
                    dtpFechaFin.Value = Convert.ToDateTime(dataTable.Rows[0]["FechaFin"].ToString());
                }
                else
                {
                    MessageBox.Show("No se encontró la promoción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
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

        private void CargarTipos()
        {
            Dictionary<int, string> tipos = new Dictionary<int, string>
            {
                { 1, "Descuento" },
                { 2, "Monto Fijo" },
                { 3, "2x1" }
            };
            cmbTipo.DataSource = new BindingSource(tipos, null);
            cmbTipo.DisplayMember = "Value";
            cmbTipo.ValueMember = "Key";
        }

        private void CargarProductos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            DataSet dataSet = productoDAO.selectProducto("L", null);

            DataTable dataTable = dataSet.Tables["Producto"];

            cmbProductoAsociado.DataSource = dataTable;
            cmbProductoAsociado.DisplayMember = "Nombre";
            cmbProductoAsociado.ValueMember = "IdProducto";
        }

        private void GuardarPromocion(Promocion promocion)
        {
            PromocionDAO promocionDAO = new PromocionDAO();
            promocionDAO.CrudPromocion(promocion, "C");
            MessageBox.Show("Promoción guardada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cmbTipo.SelectedIndex = 0;
            txtValorDescuento.Text = string.Empty;
            txtCantidadMinima.Text = string.Empty;
            cmbProductoAsociado.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            txtIdPromocion.Text = string.Empty;

            NuevaPromocion?.Invoke();

            this.Close();
        }

        private void ActualizarPromocion(Promocion promocion)
        {
            PromocionDAO promocionDAO = new PromocionDAO();
            promocionDAO.CrudPromocion(promocion, "U");
            MessageBox.Show("Promoción actualizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cmbTipo.SelectedIndex = 0;
            txtValorDescuento.Text = string.Empty;
            txtCantidadMinima.Text = string.Empty;
            cmbProductoAsociado.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            txtIdPromocion.Text = string.Empty;

            NuevaPromocion?.Invoke();

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
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cmbTipo.SelectedIndex = 0;
            txtValorDescuento.Text = string.Empty;
            txtCantidadMinima.Text = string.Empty;
            cmbProductoAsociado.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            txtIdPromocion.Text = string.Empty;

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtCantidadMinima.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            int tipo = (int)cmbTipo.SelectedValue;
            double valorDescuento = Convert.ToDouble(txtValorDescuento.Text);
            int cantidadMinima = Convert.ToInt32(txtCantidadMinima.Text);
            int productoAsociado = (int)cmbProductoAsociado.SelectedValue;
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(txtValorDescuento.Text) || string.IsNullOrEmpty(txtCantidadMinima.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Promocion promocion = new Promocion
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Tipo = tipo,
                ValorDescuento = valorDescuento,
                CantidadMinima = cantidadMinima,
                ProductoAsociado = productoAsociado,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                IdUsuario = IdUsuario
            };

            if (Accion == "Agregar")
            {
                GuardarPromocion(promocion);
            }
            else if (Accion == "Editar" && !string.IsNullOrEmpty(txtIdPromocion.Text))
            {
                promocion.IdPromocion = Convert.ToInt32(txtIdPromocion.Text);
                ActualizarPromocion(promocion);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cmbTipo.SelectedIndex = 0;
            txtValorDescuento.Text = string.Empty;
            txtCantidadMinima.Text = string.Empty;
            cmbProductoAsociado.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            txtIdPromocion.Text = string.Empty;

            this.Close();
        }

        private void txtValorDescuento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCantidadMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == 2)
            {
                txtCantidadMinima.Enabled = false;
            }
        }
    }
}
