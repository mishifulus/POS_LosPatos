using LosPatosSystem.Data;
using LosPatosSystem.Forms.DevolucionesForms;
using LosPatosSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosPatosSystem.Forms.RetornoEnvasesForms
{
    public partial class RetornosVista: Form
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }

        public DataTable detalleRetorno;

        string fecha = DateTime.Now.ToString("dddd d 'de' MMMM 'de' yyyy", new System.Globalization.CultureInfo("es-ES"));
        public RetornosVista(int IdUsuario, string Username)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            this.Username = Username;

            ObtenerIdRetorno();
        }

        private void RetornosVista_Load(object sender, EventArgs e)
        {
            txtFecha.Text = fecha;
            txtUsername.Text = Username;
            dgvDetalleRetorno.CellEndEdit += dgvDetalleRetorno_CellEndEdit;
        }

        private void ObtenerIdRetorno()
        {
            try
            {
                RetornoEnvaseDAO retornoEnvaseDAO = new RetornoEnvaseDAO();
                txtIdRetorno.Text = retornoEnvaseDAO.ObtenerIdRetorno().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el folio del retorno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerProductos(int IdVenta)
        {
            try
            {
                dgvDetalleRetorno.Columns.Clear();
                dgvDetalleRetorno.DataSource = null;
                dgvDetalleRetorno.Rows.Clear();

                RetornoEnvaseDAO retornoEnvaseDAO = new RetornoEnvaseDAO();
                detalleRetorno = retornoEnvaseDAO.ObtenerProductosVenta(IdVenta);

                dgvDetalleRetorno.DataSource = detalleRetorno;

                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "X";
                btnEliminar.Name = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dgvDetalleRetorno.Columns.Add(btnEliminar);

                dgvDetalleRetorno.Columns["IdProducto"].Visible = false;
                dgvDetalleRetorno.Columns["ImporteEnvase"].HeaderText = "Importe Envase";
                dgvDetalleRetorno.Columns["Codigo"].HeaderText = "Código";
                dgvDetalleRetorno.Columns["ImporteEnvase"].DefaultCellStyle.Format = "C";
                dgvDetalleRetorno.Columns["Subtotal"].DefaultCellStyle.Format = "C";
                dgvDetalleRetorno.Columns["Cantidad"].ReadOnly = false;
                dgvDetalleRetorno.Columns["Codigo"].ReadOnly = true;
                dgvDetalleRetorno.Columns["Producto"].ReadOnly = true;
                dgvDetalleRetorno.Columns["Descripcion"].ReadOnly = true;
                dgvDetalleRetorno.Columns["ImporteEnvase"].ReadOnly = true;
                dgvDetalleRetorno.Columns["Subtotal"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los productos de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtIdVenta.Text == String.Empty)
            {
                MessageBox.Show("Debes agregar el folio de la venta para ver los productos", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                ObtenerProductos(Convert.ToInt32(txtIdVenta.Text));
            }
            ActualizarSubtotalYTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que deseas cancelar el retorno de envases?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                txtTotal.Text = "$0";
                txtIdVenta.Text = string.Empty;
                detalleRetorno.Clear();
            }
        }

        private void dgvDetalleRetorno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalleRetorno.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dgvDetalleRetorno.Rows.RemoveAt(e.RowIndex);
                    ActualizarSubtotalYTotal();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (detalleRetorno.Rows.Count > 0)
            { 
                AceptarRetorno aceptarRetorno = new AceptarRetorno(IdUsuario, Convert.ToDouble(txtTotal.Text.Substring(1)), Convert.ToInt32(txtIdVenta.Text), ObtenerDetalleFiltrado(), Convert.ToInt32(txtIdRetorno.Text), txtUsername.Text);

                aceptarRetorno.ShowDialog();

                detalleRetorno.Clear();
                detalleRetorno.Columns.Clear();
                dgvDetalleRetorno.Columns.Remove("Eliminar");
                txtTotal.Text = "$0";
                txtIdVenta.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("No hay productos para retornar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetalleRetorno_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleRetorno.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0)
                {
                    int idProducto = Convert.ToInt32(dgvDetalleRetorno.Rows[rowIndex].Cells["IdProducto"].Value);
                    int nuevaCantidad = Convert.ToInt32(dgvDetalleRetorno.Rows[rowIndex].Cells["Cantidad"].Value);
                    double importeEnvase = Convert.ToDouble(dgvDetalleRetorno.Rows[rowIndex].Cells["ImporteEnvase"].Value);
                    double subtotal = nuevaCantidad * importeEnvase;

                    dgvDetalleRetorno.Rows[rowIndex].Cells["Subtotal"].Value = subtotal;

                    foreach (DataRow row in detalleRetorno.Rows)
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

            foreach (DataGridViewRow row in dgvDetalleRetorno.Rows)
            {
                if (row.Cells["Cantidad"].Value != null && row.Cells["ImporteEnvase"].Value != null)
                {
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    double importeEnvase = Convert.ToDouble(row.Cells["ImporteEnvase"].Value);
                    double subtotal = cantidad * importeEnvase;

                    row.Cells["Subtotal"].Value = subtotal;
                    total += subtotal;
                }
            }

            txtTotal.Text = total.ToString("C");
        }

        private DataTable ObtenerDetalleFiltrado()
        {
            DataTable tablaFiltrada = detalleRetorno.Clone();

            foreach (DataGridViewRow row in dgvDetalleRetorno.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow nuevaFila = tablaFiltrada.NewRow();
                    nuevaFila["IdProducto"] = row.Cells["IdProducto"].Value;
                    nuevaFila["Codigo"] = row.Cells["Codigo"].Value;
                    nuevaFila["Producto"] = row.Cells["Producto"].Value;
                    nuevaFila["Cantidad"] = row.Cells["Cantidad"].Value;
                    nuevaFila["ImporteEnvase"] = row.Cells["ImporteEnvase"].Value;
                    tablaFiltrada.Rows.Add(nuevaFila);
                }
            }
            return tablaFiltrada;
        }
    }
}
