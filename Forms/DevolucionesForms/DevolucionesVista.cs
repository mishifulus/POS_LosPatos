using LosPatosSystem.Data;
using LosPatosSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosPatosSystem.Forms.DevolucionesForms
{
    public partial class DevolucionesVista: Form
    {
        public int IdUsuario {  get; set; }
        public string Username { get; set; }

        private DataTable detalleDevolucion;

        string fecha = DateTime.Now.ToString("dddd d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));

        public DevolucionesVista(int IdUsuario, string Username)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            this.Username = Username;

            ObtenerIdDevolucion();
        }

        private void DevolucionesVista_Load(object sender, EventArgs e)
        {
            txtFecha.Text = fecha;
            txtUsername.Text = Username;
            dgvDetalleDevolucion.CellEndEdit += dgvDetalleDevolucion_CellEndEdit;
        }

        private void ObtenerIdDevolucion()
        {
            DevolucionDAO devolucionDAO = new DevolucionDAO();
            txtIdDevolucion.Text = devolucionDAO.ObtenerIdDevolucion().ToString();
        }

        private void ObtenerProductos(int IdVenta)
        {
            DevolucionDAO devolucionDAO = new DevolucionDAO();
            detalleDevolucion = devolucionDAO.ObtenerProductosVenta(IdVenta);

            dgvDetalleDevolucion.DataSource = detalleDevolucion;

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Text = "X";
            btnEliminar.Name = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvDetalleDevolucion.Columns.Add(btnEliminar);

            dgvDetalleDevolucion.Columns["IdProducto"].Visible = false;
            dgvDetalleDevolucion.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
            dgvDetalleDevolucion.Columns["Codigo"].HeaderText = "Código";
            dgvDetalleDevolucion.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C";
            dgvDetalleDevolucion.Columns["Subtotal"].DefaultCellStyle.Format = "C";
            dgvDetalleDevolucion.Columns["Cantidad"].ReadOnly = false;
            dgvDetalleDevolucion.Columns["Codigo"].ReadOnly = true;
            dgvDetalleDevolucion.Columns["Producto"].ReadOnly = true;
            dgvDetalleDevolucion.Columns["Descripcion"].ReadOnly = true;
            dgvDetalleDevolucion.Columns["PrecioUnitario"].ReadOnly = true;
            dgvDetalleDevolucion.Columns["Subtotal"].ReadOnly = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtIdDevolucion != null)
            {
                ObtenerProductos(Convert.ToInt32(txtIdDevolucion.Text));
            }
            else
            {
                MessageBox.Show("Debes agregar el folio de la venta para ver los productos", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            ActualizarSubtotalYTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que deseas cancelar la devolución?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                txtTotal.Text = "$0";
                detalleDevolucion.Clear();
            }
        }

        private void dgvDetalleDevolucion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalleDevolucion.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dgvDetalleDevolucion.Rows.RemoveAt(e.RowIndex);
                    ActualizarSubtotalYTotal();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (detalleDevolucion.Rows.Count > 0)
            {
                detalleDevolucion.Columns.Remove("Codigo");
                detalleDevolucion.Columns.Remove("Producto");
                detalleDevolucion.Columns.Remove("Descripcion");
                detalleDevolucion.Columns.Remove("Subtotal");

                AceptarDevolucion aceptarDevolucion = new AceptarDevolucion(IdUsuario, Convert.ToDouble(txtTotal.Text.Substring(1)), txtMotivo.Text, Convert.ToInt32(txtIdVenta.Text), detalleDevolucion);
                
                detalleDevolucion.Clear();
                detalleDevolucion.Columns.Clear();
                dgvDetalleDevolucion.Columns.Remove("Eliminar");
                txtTotal.Text = "$0";

                aceptarDevolucion.Show();
            }
            else
            {
                MessageBox.Show("No hay productos para devolver.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetalleDevolucion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleDevolucion.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0)
                {
                    int idProducto = Convert.ToInt32(dgvDetalleDevolucion.Rows[rowIndex].Cells["IdProducto"].Value);
                    int nuevaCantidad = Convert.ToInt32(dgvDetalleDevolucion.Rows[rowIndex].Cells["Cantidad"].Value);
                    double precioUnitario = Convert.ToDouble(dgvDetalleDevolucion.Rows[rowIndex].Cells["PrecioUnitario"].Value);
                    double subtotal = nuevaCantidad * precioUnitario;

                    dgvDetalleDevolucion.Rows[rowIndex].Cells["Subtotal"].Value = subtotal;

                    foreach (DataRow row in detalleDevolucion.Rows)
                    {
                        if (Convert.ToInt32(row["IdProducto"]) == idProducto)
                        {
                            row["Cantidad"] = nuevaCantidad;
                            row["Subtotal"] = subtotal;
                            break;
                        }
                    }

                    ActualizarSubtotalYTotal();
                }
            }
        }

        private void ActualizarSubtotalYTotal()
        {
            double total = 0;

            foreach (DataGridViewRow row in dgvDetalleDevolucion.Rows)
            {
                if (row.Cells["Cantidad"].Value != null && row.Cells["PrecioUnitario"].Value != null)
                {
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    double precioUnitario = Convert.ToDouble(row.Cells["PrecioUnitario"].Value);
                    double subtotal = cantidad * precioUnitario;

                    row.Cells["Subtotal"].Value = subtotal; // Actualizar el subtotal en la tabla
                    total += subtotal;
                }
            }

            txtTotal.Text = total.ToString("C"); // Mostrar el total en un Label
        }

    }
}
