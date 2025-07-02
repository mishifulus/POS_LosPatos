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

namespace LosPatosSystem.Forms
{
    public partial class Inicio: Form
    {
        private Timer timer;
        String fecha = DateTime.Now.ToString("dddd d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
        DataTable productosStock {  get; set; }
        public Inicio()
        {
            InitializeComponent();

            IniciarTimer();
            txtFecha.Text = fecha;
        }

        private void IniciarTimer()
        {
            timer = new Timer();
            timer.Interval = 60000;
            timer.Tick += (sender, e) => ActualizarHora();
            timer.Start();
            ActualizarHora();
        }

        private void ActualizarHora()
        {
            DateTime fecha = DateTime.Now;
            txtHora.Text = fecha.ToString("HH:mm");
        }

        private void CargarProductosBajoStock()
        {
            try
            {
                ProductoDAO productoDAO = new ProductoDAO();
                productosStock = productoDAO.obtenerProductosBajoStock();
                dgvBajoStock.DataSource = productosStock;

                dgvBajoStock.Columns["IdProducto"].Visible = false;
                dgvBajoStock.Columns["Codigo"].HeaderText = "Código";
                dgvBajoStock.Columns["Nombre"].HeaderText = "Producto";
                dgvBajoStock.Columns["StockMinimo"].HeaderText = "Stock Mínimo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos bajo stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CargarProductosBajoStock();
            txtBalance.Text = ObtenerBalance().ToString("C");
            txtVentas.Text = ObtenerVentas().ToString();
            txtCompras.Text = ObtenerCompras().ToString();
        }

        private double ObtenerBalance()
        {
            try
            {
                CajaDAO cajaDAO = new CajaDAO();
                double balance = 0;
                balance = cajaDAO.obtenerBalance();
                return balance;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el balance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private int ObtenerVentas()
        {
            try
            {
                VentaDAO ventaDAO = new VentaDAO();
                int totalVentas = 0;
                totalVentas = ventaDAO.obtenerVentasDiarias();
                return totalVentas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private int ObtenerCompras()
        {
            try
            {
                CompraDAO compraDAO = new CompraDAO();
                int totalCompras = 0;
                totalCompras = compraDAO.obtenerComprasDiarias();
                return totalCompras;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las compras: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
