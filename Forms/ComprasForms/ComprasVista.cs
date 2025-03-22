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

namespace LosPatosSystem.Forms.ComprasForms
{
    public partial class ComprasVista: Form
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }

        private DataTable detalleCompra;

        String fecha = DateTime.Now.ToString("dddd d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));

        public ComprasVista(int idUsuario, string username)
        {
            InitializeComponent();

            this.IdUsuario = idUsuario;
            this.Username = username;

            InicializarTabla();
            ObtenerIdCompra();
        }

        private void ComprasVista_Load(object sender, EventArgs e)
        {
            txtFecha.Text = fecha;
            txtUsername.Text = Username;
            ObtenerProductos();
        }

        private void InicializarTabla()
        {
            detalleCompra = new DataTable();
            detalleCompra.Columns.Add("IdProducto", typeof(int));
            detalleCompra.Columns.Add("Codigo", typeof(string));
            detalleCompra.Columns.Add("Producto", typeof(string));
            detalleCompra.Columns.Add("Descripcion", typeof(string));
            detalleCompra.Columns.Add("Cantidad", typeof(int));
            detalleCompra.Columns.Add("PrecioUnitario", typeof(double));
            detalleCompra.Columns.Add("Subtotal", typeof(double));
            dgvDetalleCompra.DataSource = detalleCompra;

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Text = "X";
            btnEliminar.Name = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvDetalleCompra.Columns.Add(btnEliminar);

            dgvDetalleCompra.Columns["IdProducto"].Visible = false;
            dgvDetalleCompra.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
            dgvDetalleCompra.Columns["Codigo"].HeaderText = "Código";
            dgvDetalleCompra.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C";
            dgvDetalleCompra.Columns["Subtotal"].DefaultCellStyle.Format = "C";
        }

        private void ObtenerIdCompra()
        {
            CompraDAO compraDAO = new CompraDAO();
            txtIdCompra.Text = compraDAO.ObtenerIdCompra().ToString();
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
            foreach (DataRow row in detalleCompra.Rows)
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
            string codigo = txtCodigo.Text;
            string producto = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double precioUnitario = Convert.ToDouble(txtPrecioCompra.Text);
            double subtotal = cantidad * precioUnitario;

            bool productoExistente = false;

            foreach (DataRow row in detalleCompra.Rows)
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
                detalleCompra.Rows.Add(idProducto, codigo, producto, descripcion, cantidad, precioUnitario, subtotal);
            }
            CalcularTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que deseas cancelar la compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                txtTotal.Text = "$0";
                detalleCompra.Clear();
            }
        }

        private void dgvDetalleCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalleCompra.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    detalleCompra.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            detalleCompra.Columns.Remove("Codigo");
            detalleCompra.Columns.Remove("Producto");
            detalleCompra.Columns.Remove("Descripcion");
            detalleCompra.Columns.Remove("Subtotal");

            AceptarCompra aceptarCompra = new AceptarCompra(IdUsuario, Convert.ToDouble(txtTotal.Text.Substring(1)), detalleCompra);

            InicializarTabla();

            aceptarCompra.Show();
        }
    }
}
