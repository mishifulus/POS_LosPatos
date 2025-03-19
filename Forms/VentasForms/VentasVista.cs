using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using LosPatosSystem.Models;
using LosPatosSystem.Data;
using LosPatosSystem.Forms.ComprasForms;

namespace LosPatosSystem.Forms.VentasForms
{
    public partial class VentasVista: Form
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }

        private DataTable detalleVenta;

        string fecha = DateTime.Now.ToString("dddd d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
        public VentasVista(int IdUsuario, string Username)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            this.Username = Username;

            InicializarTabla();
            ObtenerIdVenta();
        }

        private void VentasVista_Load(object sender, EventArgs e)
        {
            txtFecha.Text = fecha;
            txtUsername.Text = Username;
            ObtenerProductos();
        }

        private void InicializarTabla()
        {
            detalleVenta = new DataTable();
            detalleVenta.Columns.Add("IdProducto", typeof(int));
            detalleVenta.Columns.Add("Producto", typeof(string));
            detalleVenta.Columns.Add("Descripcion", typeof(string));
            detalleVenta.Columns.Add("Cantidad", typeof(int));
            detalleVenta.Columns.Add("PrecioUnitario", typeof(double));
            detalleVenta.Columns.Add("Subtotal", typeof(double));
            dgvDetalleVenta.DataSource = detalleVenta;

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Text = "X";
            btnEliminar.Name = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvDetalleVenta.Columns.Add(btnEliminar);

            dgvDetalleVenta.Columns["IdProducto"].Visible = false;
            dgvDetalleVenta.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
            dgvDetalleVenta.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C";
            dgvDetalleVenta.Columns["Subtotal"].DefaultCellStyle.Format = "C";
        }

        private void ObtenerIdVenta()
        {
            VentaDAO ventaDAO = new VentaDAO();
            txtIdVenta.Text = ventaDAO.ObtenerIdVenta().ToString();
        }

        private void ObtenerProductos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            DataSet dataSet = productoDAO.selectProducto("L", null);

            cmbProducto.DataSource = dataSet.Tables[0];
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IdProducto";
            cmbProducto.BindingContext = new BindingContext();
        }

        private void BuscarProducto(Producto producto)
        {
            ProductoDAO productoDAO = new ProductoDAO();
            DataSet dataSet = productoDAO.selectProducto("S", producto);

            cmbProducto.DataSource = dataSet.Tables[0];
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IdProducto";
            cmbProducto.BindingContext = new BindingContext();
        }

        private void SeleccionarProducto(int IdProducto)
        {
            ProductoDAO productoDAO = new ProductoDAO();

            Producto producto = new Producto();
            producto.IdProducto = IdProducto;

            DataSet dataSet = productoDAO.selectProducto("R", producto);
            DataTable dataTable = dataSet.Tables["Producto"];
            DataRow row = dataTable.Rows[0];

            txtIdProducto.Text = row["IdProducto"].ToString();
            txtCodigo.Text = row["Codigo"].ToString();
            txtNombre.Text = row["Nombre"].ToString();
            txtDescripcion.Text = row["Descripcion"].ToString();
            txtPrecioCompra.Text = row["PrecioCompra"].ToString();
            txtUnidad.Text = row["Unidad"].ToString();
            txtCantidad.Text = "1";
            txtCantidad.Focus();
        }

        private void CalcularTotal()
        {
            double total = 0;
            foreach (DataRow row in detalleVenta.Rows)
            {
                total += Convert.ToDouble(row["Subtotal"]);
            }
            txtTotal.Text = total.ToString("C");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text == "")
            {
                ObtenerProductos();
            }
            else
            {
                Producto producto = new Producto();
                producto.Nombre = cmbProducto.Text;
                producto.Codigo = cmbProducto.Text;
                producto.Descripcion = cmbProducto.Text;

                BuscarProducto(producto);
            }
        }

        private void cmbProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem is DataRowView rowView)
            {
                int idProducto = Convert.ToInt32(rowView["IdProducto"]);
                SeleccionarProducto(idProducto);
            }
            else if (cmbProducto.SelectedValue != null && int.TryParse(cmbProducto.SelectedValue.ToString(), out int id))
            {
                SeleccionarProducto(id);
            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = (Convert.ToInt32(txtCantidad.Text) - 1).ToString();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = (Convert.ToInt32(txtCantidad.Text) + 1).ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(txtIdProducto.Text);
            string producto = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double precioUnitario = Convert.ToDouble(txtPrecioCompra.Text);
            double subtotal = cantidad * precioUnitario;

            bool productoExistente = false;

            foreach (DataRow row in detalleVenta.Rows)
            {
                if (Convert.ToInt32(row["IdProducto"]) == idProducto)
                {
                    row["Cantidad"] = Convert.ToInt32(row["Cantidad"]) + cantidad;
                    row["Subtotal"] = Convert.ToDouble(row["Subtotal"]) + subtotal;
                    productoExistente = true;
                    break;
                }
            }

            if (!productoExistente)
            {
                detalleVenta.Rows.Add(idProducto, producto, descripcion, cantidad, precioUnitario, subtotal);
            }
            CalcularTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que deseas cancelar la venta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                txtTotal.Text = "$0";
                detalleVenta.Clear();
            }
        }

        private void dgvDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalleVenta.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    detalleVenta.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            detalleVenta.Columns.Remove("Producto");
            detalleVenta.Columns.Remove("Descripcion");
            detalleVenta.Columns.Remove("Subtotal");

            AceptarVenta aceptarVenta = new AceptarVenta(IdUsuario, Convert.ToDouble(txtTotal.Text.Substring(1)), detalleVenta);

            InicializarTabla();

            aceptarVenta.Show();
            
        }
    }
}
