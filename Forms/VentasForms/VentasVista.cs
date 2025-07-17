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

            dgvDetalleVenta.CellPainting += new DataGridViewCellPaintingEventHandler(dgvDetalleVenta_CellPainting);
        }

        private void InicializarTabla()
        {
            detalleVenta = new DataTable();
            detalleVenta.Columns.Add("IdProducto", typeof(int));
            detalleVenta.Columns.Add("Codigo", typeof(string));
            detalleVenta.Columns.Add("Producto", typeof(string));
            detalleVenta.Columns.Add("Descripcion", typeof(string));
            detalleVenta.Columns.Add("Cantidad", typeof(int));
            detalleVenta.Columns.Add("PrecioUnitario", typeof(double));
            detalleVenta.Columns.Add("Descuento", typeof(double));
            detalleVenta.Columns.Add("Subtotal", typeof(double));
            detalleVenta.Columns.Add("ImporteEnvase", typeof(double));
            detalleVenta.Columns.Add("SubtotalEnvase", typeof(double));
            dgvDetalleVenta.DataSource = detalleVenta;

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Text = "X";
            btnEliminar.Name = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvDetalleVenta.Columns.Add(btnEliminar);

            dgvDetalleVenta.Columns["IdProducto"].Visible = false;
            dgvDetalleVenta.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
            dgvDetalleVenta.Columns["Codigo"].HeaderText = "Código";
            dgvDetalleVenta.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C";
            dgvDetalleVenta.Columns["Descuento"].HeaderText = "Precio Con Descuento";
            dgvDetalleVenta.Columns["Descuento"].DefaultCellStyle.Format = "C";
            dgvDetalleVenta.Columns["Subtotal"].DefaultCellStyle.Format = "C";
            dgvDetalleVenta.Columns["ImporteEnvase"].HeaderText = "Importe Envase";
            dgvDetalleVenta.Columns["ImporteEnvase"].DefaultCellStyle.Format = "C";
            dgvDetalleVenta.Columns["SubtotalEnvase"].HeaderText = "Subtotal Envase";
            dgvDetalleVenta.Columns["SubtotalEnvase"].DefaultCellStyle.Format = "C";
        }

        private void ObtenerIdVenta()
        {
            try
            {
                VentaDAO ventaDAO = new VentaDAO();
                txtIdVenta.Text = ventaDAO.ObtenerIdVenta().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ID de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdVenta.Text = "0";
            }
        }

        private void ObtenerProductos()
        {
            try
            {
                ProductoDAO productoDAO = new ProductoDAO();
                DataSet dataSet = productoDAO.selectProducto("L", null);

                cmbProducto.DataSource = dataSet.Tables[0];
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "IdProducto";
                cmbProducto.BindingContext = new BindingContext();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarProducto(Producto producto)
        {
            try
            {
                ProductoDAO productoDAO = new ProductoDAO();
                DataSet dataSet = productoDAO.selectProducto("S", producto);

                cmbProducto.DataSource = dataSet.Tables[0];
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "IdProducto";
                cmbProducto.BindingContext = new BindingContext();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarProducto(int IdProducto)
        {
            try
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
                txtPrecioVenta.Text = row["PrecioVenta"].ToString();
                txtImporteEnvase.Text = row["ImporteEnvase"].ToString();
                txtUnidad.Text = row["Unidad"].ToString();
                txtStockDisponible.Text = row["Stock"].ToString();
                txtCantidad.Text = "1";
                txtCantidad.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularTotal()
        {
            double total = 0;
            double totalEnvases = 0;
            foreach (DataRow row in detalleVenta.Rows)
            {
                totalEnvases += Convert.ToDouble(row["SubtotalEnvase"]);
                total += Convert.ToDouble(row["Subtotal"]);
            }
            total += totalEnvases;
            txtTotal.Text = total.ToString("C");
            txtTotalEnvases.Text = totalEnvases.ToString("C");
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
            int cantidadActual = int.Parse(txtCantidad.Text);

            if (cantidadActual > 1)
            {
                cantidadActual--;
                txtCantidad.Text = cantidadActual.ToString();
            }
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            int cantidadActual = int.Parse(txtCantidad.Text);
            int stockDisponible = int.Parse(txtStockDisponible.Text);

            if (cantidadActual < stockDisponible)
            {
                cantidadActual++;
                txtCantidad.Text = cantidadActual.ToString();
            }
            else
            {
                MessageBox.Show("No puedes vender más de lo que hay en stock.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(txtIdProducto.Text);
            string codigo = txtCodigo.Text;
            string producto = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double precioUnitario = Convert.ToDouble(txtPrecioVenta.Text);
            double importeEnvase = Convert.ToDouble(txtImporteEnvase.Text);
            double subtotal = cantidad * precioUnitario;

            bool productoExistente = false;

            foreach (DataRow row in detalleVenta.Rows)
            {
                if (Convert.ToInt32(row["IdProducto"]) == idProducto)
                {
                    int newCantidad = Convert.ToInt32(row["Cantidad"]) + cantidad;

                    VentaDAO ventaDAO = new VentaDAO();
                    double descuento = ventaDAO.AplicarPromocion(idProducto, newCantidad, precioUnitario);
                    double precioConDescuento = precioUnitario - (descuento / newCantidad);
                    subtotal = newCantidad * Convert.ToInt32(row["Descuento"]);
                    double subtotalEnvase = importeEnvase * newCantidad;

                    row["Cantidad"] = newCantidad;
                    row["Descuento"] = precioConDescuento;
                    row["Subtotal"] = subtotal;
                    row["SubtotalEnvase"] = subtotalEnvase;
                    productoExistente = true;
                    break;
                }
            }

            if (!productoExistente)
            {
                VentaDAO ventaDAO = new VentaDAO();
                double descuento = ventaDAO.AplicarPromocion(idProducto, cantidad, precioUnitario);
                double precioConDescuento = precioUnitario - (descuento / cantidad);
                subtotal = cantidad * precioConDescuento;
                double subtotalEnvase = importeEnvase * cantidad;

                detalleVenta.Rows.Add(idProducto, codigo, producto, descripcion, cantidad, precioUnitario, precioConDescuento, subtotal, importeEnvase, subtotalEnvase);
            }
            CalcularTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que deseas cancelar la venta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                txtTotal.Text = "$0";
                txtTotalEnvases.Text = "$0";
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
                    CalcularTotal();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (detalleVenta.Rows.Count > 0)
            {
                AceptarVenta aceptarVenta = new AceptarVenta(IdUsuario, Convert.ToDouble(txtTotal.Text.Substring(1)), detalleVenta, Convert.ToInt32(txtIdVenta.Text), txtUsername.Text, Convert.ToDouble(txtTotalEnvases.Text.Substring(1)));

                aceptarVenta.ShowDialog();

                InicializarTabla();
                txtTotal.Text = "$0";
                txtTotalEnvases.Text = "$0";
                ObtenerIdVenta();
            }
            else
            {
                MessageBox.Show("No hay productos para vender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dgvDetalleVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dgvDetalleVenta.Columns[e.ColumnIndex].Name == "PrecioUnitario" && e.RowIndex >= 0)
            {
                double precioConDescuento = Convert.ToDouble(dgvDetalleVenta.Rows[e.RowIndex].Cells["Descuento"].Value ?? 0);
                double precioOriginal = Convert.ToDouble(dgvDetalleVenta.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);

                e.PaintBackground(e.CellBounds, true);

                if (precioConDescuento < precioOriginal)
                {

                    using (Font fontTachado = new Font(e.CellStyle.Font, FontStyle.Strikeout))
                    {
                        SizeF textSize = e.Graphics.MeasureString(precioOriginal.ToString("C"), fontTachado);

                        // Calcular posición centrada en la celda
                        float posX = e.CellBounds.X + (e.CellBounds.Width - textSize.Width) / 2;
                        float posY = e.CellBounds.Y + (e.CellBounds.Height - textSize.Height) / 2;

                        // Dibujar el texto centrado
                        e.Graphics.DrawString(precioOriginal.ToString("C"), fontTachado, Brushes.Red, e.CellBounds.Left, posY);
                    }

                    e.Handled = true;
                }
            }
        }
    }
}
