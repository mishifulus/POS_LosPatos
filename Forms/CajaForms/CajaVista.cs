using LosPatosSystem.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosPatosSystem.Forms.CajaForms
{
    public partial class CajaVista : Form
    {
        public int IdUsuario { get; set; }

        public int IdRol { get; set; }

        public CajaVista(int IdUsuario, int IdRol)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            this.IdRol = IdRol;
        }

        private void CajaVista_Load(object sender, EventArgs e)
        {
            ObtenerMovimientos();
        }

        private void ObtenerMovimientos()
        {
            CajaDAO cajaDAO = new CajaDAO();
            DataSet dataSet = cajaDAO.obtenerMovimientosDiarios();
            dgvMovimientos.DataSource = dataSet.Tables["Caja"];

            dgvMovimientos.Columns["IdMovimiento"].Visible = false;
            dgvMovimientos.Columns["TipoMovimiento"].Visible = false;
            dgvMovimientos.Columns["IdUsuario"].Visible = false;
            dgvMovimientos.Columns["EstatusRegistro"].Visible = false;
            dgvMovimientos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMovimientos.Columns["Monto"].DefaultCellStyle.Format = "C2";

            txtIngresos.Text = ObtenerTotales(1).ToString("C");
            txtEgresos.Text = ObtenerTotales(0).ToString("C");
            txtBalance.Text = ObtenerBalance().ToString("C");
        }

        private void ObtenerByTipo(int TipoMovimiento)
        {
            CajaDAO cajaDAO = new CajaDAO();
            DataSet dataSet = cajaDAO.obtenerMovimientosByTipo(TipoMovimiento);
            dgvMovimientos.DataSource = dataSet.Tables["Caja"];

            if (dataSet == null || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
            {
                return;
            }

            dgvMovimientos.Columns["IdMovimiento"].Visible = false;
            dgvMovimientos.Columns["TipoMovimiento"].Visible = false;
            dgvMovimientos.Columns["IdUsuario"].Visible = false;
            dgvMovimientos.Columns["EstatusRegistro"].Visible = false;
            dgvMovimientos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMovimientos.Columns["Monto"].DefaultCellStyle.Format = "C2";
        }

        private double ObtenerTotales(int TipoMovimiento)
        {
            CajaDAO cajaDAO= new CajaDAO();
            double Total = 0;
            Total = cajaDAO.obtenerTotales(TipoMovimiento);
            
            return Total;
        }

        private double ObtenerBalance()
        {
            CajaDAO cajaDAO = new CajaDAO();
            double balance = 0;
            balance = cajaDAO.obtenerBalance();
            return balance;
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            ObtenerByTipo(1);
        }

        private void btnEgresos_Click(object sender, EventArgs e)
        {
            ObtenerByTipo(0);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MovimientoForm movimientoForm = new MovimientoForm(IdUsuario);
            movimientoForm.NuevoMovimiento += ObtenerMovimientos;
            movimientoForm.Show();
        }
    }
}
