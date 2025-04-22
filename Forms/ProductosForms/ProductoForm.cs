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

namespace LosPatosSystem.Forms.Productos
{
    public partial class ProductoForm: Form
    {
        public int IdUsuario { get; set; }
        string Accion = "";
        int IdProducto = 0;

        public event Action NuevoProducto;

        public ProductoForm(string Accion, int IdUsuario, int IdProducto)
        {
            InitializeComponent();
            this.Accion = Accion;
            this.IdProducto = IdProducto;
            this.IdUsuario = IdUsuario;

            txtIdProducto.Text = IdProducto.ToString();
        }

        private void ProductoForm_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarUnidades();

            if (Accion == "Editar" && IdProducto > 0)
            {
                Producto producto = new Producto();
                producto.IdProducto = IdProducto;

                ProductoDAO productoDAO = new ProductoDAO();
                DataSet dataSet = productoDAO.selectProducto("R", producto);
                DataTable dataTable = dataSet.Tables["Producto"];

                if (dataTable.Rows.Count > 0)
                {
                    txtNombre.Text = dataTable.Rows[0]["Nombre"].ToString();
                    txtCodigo.Text = dataTable.Rows[0]["Codigo"].ToString();
                    txtDescripcion.Text = dataTable.Rows[0]["Descripcion"].ToString();
                    txtPrecioCompra.Text = dataTable.Rows[0]["PrecioCompra"].ToString();
                    txtPrecioVenta.Text = dataTable.Rows[0]["PrecioVenta"].ToString();
                    txtStock.Text = dataTable.Rows[0]["Stock"].ToString();
                    txtStockMinimo.Text = dataTable.Rows[0]["StockMinimo"].ToString();
                    cmbCategoria.SelectedValue = dataTable.Rows[0]["IdCategoria"];
                    cmbUnidad.SelectedValue = dataTable.Rows[0]["IdUnidad"];
                }
                else
                {
                    MessageBox.Show("No se encontró el producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void CargarCategorias()
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            DataSet dataSet = categoriaDAO.selectCategoria("L", 0, null);
            cmbCategoria.DataSource = dataSet.Tables["Categoria"];

            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";

        }

        private void CargarUnidades()
        {
            UnidadDAO unidadDAO = new UnidadDAO();
            DataSet dataSet = unidadDAO.selectUnidad("L", 0, null);
            cmbUnidad.DataSource = dataSet.Tables["Unidad"];

            cmbUnidad.DisplayMember = "Nombre";
            cmbUnidad.ValueMember = "IdUnidad";

        }

        private void GuardarProducto(Producto producto)
        {
            ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.CrudProducto("C", producto);
            MessageBox.Show("Producto guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombre.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtStockMinimo.Text = string.Empty;
            txtIdProducto.Text = string.Empty;
            cmbCategoria.SelectedIndex = 0;
            cmbUnidad.SelectedIndex = 0;

            NuevoProducto?.Invoke();

            this.Close();
        }

        private void ActualizarProducto(Producto producto)
        {
            ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.CrudProducto("U", producto );
            MessageBox.Show("Producto actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombre.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtStockMinimo.Text = string.Empty;
            txtIdProducto.Text = string.Empty;
            cmbCategoria.SelectedIndex = 0;
            cmbUnidad.SelectedIndex = 0;

            NuevoProducto?.Invoke();

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
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtStockMinimo.Text = string.Empty;
            txtIdProducto.Text = string.Empty;
            cmbCategoria.SelectedIndex = 0;
            cmbUnidad.SelectedIndex = 0;

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtPrecioCompra.Text) || string.IsNullOrEmpty(txtPrecioVenta.Text) || string.IsNullOrEmpty(txtStock.Text) || string.IsNullOrEmpty(txtStockMinimo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string codigo = txtCodigo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            double precioCompra = Convert.ToDouble(txtPrecioCompra.Text);
            double precioVenta = Convert.ToDouble(txtPrecioVenta.Text);
            int stock = Convert.ToInt32(txtStock.Text);
            int stockMinimo = Convert.ToInt32(txtStockMinimo.Text);
            int idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            int idUnidad = Convert.ToInt32(cmbUnidad.SelectedValue);

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(txtPrecioCompra.Text) || string.IsNullOrEmpty(txtPrecioVenta.Text) || string.IsNullOrEmpty(txtStock.Text) || string.IsNullOrEmpty(txtStockMinimo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Producto producto = new Producto()
            {
                Nombre = nombre,
                Codigo = codigo,
                Descripcion = descripcion,
                PrecioCompra = precioCompra,
                PrecioVenta = precioVenta,
                Stock = stock,
                StockMinimo = stockMinimo,
                IdCategoria = idCategoria,
                IdUnidad = idUnidad,
                IdUsuario = IdUsuario
            };

            if (Accion == "Agregar")
            {
                GuardarProducto(producto);
            }
            else if (Accion == "Editar" && !string.IsNullOrEmpty(txtIdProducto.Text))
            {
                producto.IdProducto = Convert.ToInt32(txtIdProducto.Text);
                ActualizarProducto(producto);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtStockMinimo.Text = string.Empty;
            txtIdProducto.Text = string.Empty;
            cmbCategoria.SelectedIndex = 0;
            cmbUnidad.SelectedIndex = 0;

            this.Close();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
