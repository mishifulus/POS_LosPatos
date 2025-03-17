using LosPatosSystem.Data;
using LosPatosSystem.Forms.Productos;
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

namespace LosPatosSystem.Forms
{
    public partial class ProductosVista: Form
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public ProductosVista(int IdUsuario, int IdRol)
        {
            InitializeComponent();

            this.IdUsuario = IdUsuario;
            this.IdRol = IdRol;
            this.Resize += new EventHandler(ProductosVista_Resize);

            if (IdRol == 1)
            {
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                btnInactivos.Visible = true;
                btnCategorias.Visible = true;
                btnUnidades.Visible = true;
            }
            else
            {
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnInactivos.Visible = false;
                btnCategorias.Visible = false;
                btnUnidades.Visible = false;
                btnActivar.Visible = false;
            }
        }

        private void ProductosVista_Resize(object sender, EventArgs e)
        {
            if (dgvProductos.Width == 932 && dgvProductos.Height == 577)
            {
                dgvProductos.Width = dgvProductos.Width + 610;
                dgvProductos.Height = dgvProductos.Height + 200;
            } 
            else
            {
                dgvProductos.Width = 932;
                dgvProductos.Height = 577;
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            ObtenerProductos();
        }

        private void ObtenerProductos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            DataSet dataSet = productoDAO.selectProducto("L", null);
            dgvProductos.DataSource = dataSet.Tables["Producto"];

            dgvProductos.Columns["IdProducto"].Visible = false;
            dgvProductos.Columns["IdUnidad"].Visible = false;
            dgvProductos.Columns["IdCategoria"].Visible = false;
            dgvProductos.Columns["IdUsuario"].Visible = false;
            dgvProductos.Columns["Codigo"].HeaderText = "Código";
            dgvProductos.Columns["Nombre"].HeaderText = "Producto";
            dgvProductos.Columns["PrecioCompra"].HeaderText = "Precio Compra";
            dgvProductos.Columns["PrecioCompra"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["PrecioVenta"].HeaderText = "Precio Venta";
            dgvProductos.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["StockMinimo"].HeaderText = "Stock Mínimo";
            dgvProductos.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvProductos.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvProductos.Columns["EstatusRegistro"].HeaderCell.Value = "Estatus";

            dgvProductos.Columns["Codigo"].DisplayIndex = 0;
            dgvProductos.Columns["Nombre"].DisplayIndex = 1;
            dgvProductos.Columns["Descripcion"].DisplayIndex = 2;
            dgvProductos.Columns["Unidad"].DisplayIndex = 3;
            dgvProductos.Columns["Categoria"].DisplayIndex = 4;
        }

        private void ObtenerProductosInactivos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            DataSet dataSet = productoDAO.selectProducto("I", null);
            dgvProductos.DataSource = dataSet.Tables["Producto"];

            dgvProductos.Columns["IdProducto"].Visible = false;
            dgvProductos.Columns["IdUnidad"].Visible = false;
            dgvProductos.Columns["IdCategoria"].Visible = false;
            dgvProductos.Columns["IdUsuario"].Visible = false;
            dgvProductos.Columns["Codigo"].HeaderText = "Código";
            dgvProductos.Columns["Nombre"].HeaderText = "Producto";
            dgvProductos.Columns["PrecioCompra"].HeaderText = "Precio Compra";
            dgvProductos.Columns["PrecioCompra"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["PrecioVenta"].HeaderText = "Precio Venta";
            dgvProductos.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["StockMinimo"].HeaderText = "Stock Mínimo";
            dgvProductos.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvProductos.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvProductos.Columns["EstatusRegistro"].HeaderCell.Value = "Estatus";

            dgvProductos.Columns["Codigo"].DisplayIndex = 0;
            dgvProductos.Columns["Nombre"].DisplayIndex = 1;
            dgvProductos.Columns["Descripcion"].DisplayIndex = 2;
            dgvProductos.Columns["Unidad"].DisplayIndex = 3;
            dgvProductos.Columns["Categoria"].DisplayIndex = 4;
        }

        private void EliminarProducto(int idProducto, int idUsuario)
        {
            Producto producto = new Producto();
            producto.IdProducto = idProducto;
            producto.IdUsuario = idUsuario;

            ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.CrudProducto("D", producto);

            txtIdProducto.Text = string.Empty;

            ObtenerProductos();
        }

        private void ActivarProducto(int idProducto, int idUsuario)
        {
            Producto producto = new Producto();
            producto.IdProducto = idProducto;
            producto.IdUsuario = idUsuario;

            ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.CrudProducto("A", producto);

            txtIdProducto.Text = string.Empty;

            ObtenerProductosInactivos();
        }

        private void BuscarProducto(Producto producto)
        {
            ProductoDAO productoDAO = new ProductoDAO();
            DataSet dataSet = productoDAO.selectProducto("S", producto);

            dgvProductos.DataSource = dataSet.Tables["Producto"];

            dgvProductos.Columns["IdProducto"].Visible = false;
            dgvProductos.Columns["IdUnidad"].Visible = false;
            dgvProductos.Columns["IdCategoria"].Visible = false;
            dgvProductos.Columns["IdUsuario"].Visible = false;
            dgvProductos.Columns["Codigo"].HeaderText = "Código";
            dgvProductos.Columns["Nombre"].HeaderText = "Producto";
            dgvProductos.Columns["PrecioCompra"].HeaderText = "Precio Compra";
            dgvProductos.Columns["PrecioCompra"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["PrecioVenta"].HeaderText = "Precio Venta";
            dgvProductos.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["StockMinimo"].HeaderText = "Stock Mínimo";
            dgvProductos.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvProductos.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvProductos.Columns["EstatusRegistro"].HeaderCell.Value = "Estatus";

            dgvProductos.Columns["Codigo"].DisplayIndex = 0;
            dgvProductos.Columns["Nombre"].DisplayIndex = 1;
            dgvProductos.Columns["Descripcion"].DisplayIndex = 2;
            dgvProductos.Columns["Unidad"].DisplayIndex = 3;
            dgvProductos.Columns["Categoria"].DisplayIndex = 4;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoForm productoForm = new ProductoForm("Agregar", IdUsuario, 0);
            productoForm.NuevoProducto += ObtenerProductos;
            productoForm.Show();
        }

        private void btnUnidades_Click(object sender, EventArgs e)
        {
            UnidadesForm unidadesForm = new UnidadesForm(IdUsuario);
            unidadesForm.Show();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            CategoriasForm categoriasForm = new CategoriasForm(IdUsuario);
            categoriasForm.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Seleccione un producto para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int IdProducto = Convert.ToInt32(txtIdProducto.Text);
            ProductoForm productoForm = new ProductoForm("Editar", IdUsuario, IdProducto);
            productoForm.NuevoProducto += ObtenerProductos;
            productoForm.Show();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdProducto.Text = dgvProductos.Rows[e.RowIndex].Cells["IdProducto"].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Seleccione un producto para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int idProducto = Convert.ToInt32(txtIdProducto.Text);
                EliminarProducto(idProducto, IdUsuario);
            }
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            ObtenerProductosInactivos();

            btnAgregar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInactivos.Visible = false;
            btnCategorias.Visible = false;
            btnUnidades.Visible = false;
            btnActivar.Visible = true;
            btnProductosActivos.Visible = true;
            txtBuscar.Visible = false;
            btnBuscar.Visible = false;
            panelBusqueda.Visible = false;
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Seleccione un producto para activar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int idProducto = Convert.ToInt32(txtIdProducto.Text);
                ActivarProducto(idProducto, IdUsuario);
            }
        }

        private void btnProductosActivos_Click(object sender, EventArgs e)
        {
            ObtenerProductos();

            btnAgregar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnInactivos.Visible = true;
            btnCategorias.Visible = true;
            btnUnidades.Visible = true;
            btnActivar.Visible = false;
            btnProductosActivos.Visible = false;
            txtBuscar.Visible = true;
            btnBuscar.Visible = true;
            panelBusqueda.Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtBuscar.Text))
            {
                ObtenerProductos();
            }
            else
            {
                Producto producto = new Producto();
                producto.Nombre = txtBuscar.Text;
                producto.Codigo = txtBuscar.Text;
                producto.Descripcion = txtBuscar.Text;

                BuscarProducto(producto);
            }
        }

        private void btnCerveza_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.IdCategoria = 1;

            BuscarProducto(producto);
        }

        private void btnRefrescos_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.IdCategoria = 2;

            BuscarProducto(producto);
        }

        private void btnPapas_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.IdCategoria = 3;

            BuscarProducto(producto);
        }

        private void btnCigarros_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.IdCategoria = 4;

            BuscarProducto(producto);
        }

        private void btnDesechable_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.IdCategoria = 5;

            BuscarProducto(producto);
        }

        private void btnJugos_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.IdCategoria = 6;

            BuscarProducto(producto);
        }

        private void btnAguas_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.IdCategoria = 7;

            BuscarProducto(producto);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (string.IsNullOrEmpty(txtBuscar.Text))
                {
                    ObtenerProductos();
                }
                else
                {
                    Producto producto = new Producto();
                    producto.Nombre = txtBuscar.Text;
                    producto.Codigo = txtBuscar.Text;
                    producto.Descripcion = txtBuscar.Text;

                    BuscarProducto(producto);
                }
            }
        }
    }
}
