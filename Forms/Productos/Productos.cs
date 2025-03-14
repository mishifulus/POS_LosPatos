using LosPatosSystem.Data;
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
    public partial class Productos: Form
    {
        public Productos()
        {
            InitializeComponent();
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
    }
}
