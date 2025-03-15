using LosPatosSystem.Data;
using LosPatosSystem.Forms.Productos;
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
        public ProductosVista(int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            this.Resize += new EventHandler(ProductosVista_Resize);
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

        private void ObtenerProductos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            DataSet dataSet = productoDAO.selectProducto("L", null);
            dgvProductos.DataSource = dataSet.Tables["Producto"];
            
            dgvProductos.Columns["IdProducto"].Visible = false;
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            ObtenerProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoForm productoForm = new ProductoForm("Agregar");
            productoForm.Show();
        }

        private void btnUnidades_Click(object sender, EventArgs e)
        {
            UnidadesForm unidadesForm = new UnidadesForm(IdUsuario);
            unidadesForm.Show();
        }
    }
}
