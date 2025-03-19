using LosPatosSystem.Data;
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

namespace LosPatosSystem.Forms.PromocionesForms
{
    public partial class PromocionesVista: Form
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public PromocionesVista(int IdUsuario, int IdRol)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            this.IdRol = IdRol;
            this.Resize += new EventHandler(PromocionesVista_Resize);

            if (IdRol == 1)
            {
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                btnInactivos.Visible = true;
            }
            else
            {
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnInactivos.Visible = false;
                btnActivar.Visible = false;
            }
        }

        private void PromocionesVista_Resize(object sender, EventArgs e)
        {
            if (dgvPromociones.Width == 932 && dgvPromociones.Height == 617)
            {
                dgvPromociones.Width = dgvPromociones.Width + 610;
                dgvPromociones.Height = dgvPromociones.Height + 200;
            }
            else
            {
                dgvPromociones.Width = 932;
                dgvPromociones.Height = 617;
            }
        }

        private void PromocionesVista_Load(object sender, EventArgs e)
        {
            ObtenerPromociones();
        }

        private void ObtenerPromociones()
        {
            PromocionDAO promocionDAO = new PromocionDAO();
            DataSet dataSet = promocionDAO.selectPromocion("L", null);
            dgvPromociones.DataSource = dataSet.Tables["Promocion"];

            dgvPromociones.Columns["IdPromocion"].Visible = false;
            dgvPromociones.Columns["IdUsuario"].Visible = false;
            dgvPromociones.Columns["Tipo"].Visible = false;
            dgvPromociones.Columns["ProductoAsociado"].Visible = false;
            dgvPromociones.Columns["TipoDescuento"].HeaderText = "Tipo de Descuento";
            dgvPromociones.Columns["ValorDescuento"].HeaderText = "Valor de Descuento";
            dgvPromociones.Columns["CantidadMinima"].HeaderText = "Cantidad Mínima";
            dgvPromociones.Columns["ProductoAsociadoNombre"].HeaderText = "Producto";
            dgvPromociones.Columns["FechaInicio"].HeaderText = "Inicio";
            dgvPromociones.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPromociones.Columns["FechaFin"].HeaderText = "Fin";
            dgvPromociones.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPromociones.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvPromociones.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPromociones.Columns["EstatusRegistro"].HeaderCell.Value = "Estatus";
        }

        private void ObtenerPromocionesInactivas()
        {
            PromocionDAO promocionDAO = new PromocionDAO();
            DataSet dataSet = promocionDAO.selectPromocion("I", null);
            dgvPromociones.DataSource = dataSet.Tables["Promocion"];

            dgvPromociones.Columns["IdPromocion"].Visible = false;
            dgvPromociones.Columns["IdUsuario"].Visible = false;
            dgvPromociones.Columns["Tipo"].Visible = false;
            dgvPromociones.Columns["ProductoAsociado"].Visible = false;
            dgvPromociones.Columns["TipoDescuento"].HeaderText = "Tipo de Descuento";
            dgvPromociones.Columns["ValorDescuento"].HeaderText = "Valor de Descuento";
            dgvPromociones.Columns["CantidadMinima"].HeaderText = "Cantidad Mínima";
            dgvPromociones.Columns["ProductoAsociadoNombre"].HeaderText = "Producto";
            dgvPromociones.Columns["FechaInicio"].HeaderText = "Inicio";
            dgvPromociones.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPromociones.Columns["FechaFin"].HeaderText = "Fin";
            dgvPromociones.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPromociones.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvPromociones.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPromociones.Columns["EstatusRegistro"].HeaderCell.Value = "Estatus";
        }

        private void EliminarPromocion(int idPromocion, int idUsuario)
        {
            Promocion promocion = new Promocion();
            promocion.IdPromocion = idPromocion;
            promocion.IdUsuario = idUsuario;

            PromocionDAO promocionDAO = new PromocionDAO();
            promocionDAO.CrudPromocion(promocion, "D");

            txtIdPromocion.Text = string.Empty;

            ObtenerPromociones();
        }

        private void ActivarPromocion(int idPromocion, int idUsuario)
        {
            Promocion promocion = new Promocion();
            promocion.IdPromocion = idPromocion;
            promocion.IdUsuario = idUsuario;

            PromocionDAO promocionDAO = new PromocionDAO();
            promocionDAO.CrudPromocion(promocion, "A");

            txtIdPromocion.Text = string.Empty;

            ObtenerPromocionesInactivas();
        }

        private void BuscarPromocion(Promocion promocion)
        {
            PromocionDAO promocionDAO = new PromocionDAO();
            DataSet dataSet = promocionDAO.selectPromocion("S", promocion);

            dgvPromociones.DataSource = dataSet.Tables["Promocion"];

            dgvPromociones.Columns["IdPromocion"].Visible = false;
            dgvPromociones.Columns["IdUsuario"].Visible = false;
            dgvPromociones.Columns["Tipo"].Visible = false;
            dgvPromociones.Columns["ProductoAsociado"].Visible = false;
            dgvPromociones.Columns["TipoDescuento"].HeaderText = "Tipo de Descuento";
            dgvPromociones.Columns["ValorDescuento"].HeaderText = "Valor de Descuento";
            dgvPromociones.Columns["CantidadMinima"].HeaderText = "Cantidad Mínima";
            dgvPromociones.Columns["ProductoAsociadoNombre"].HeaderText = "Producto";
            dgvPromociones.Columns["FechaInicio"].HeaderText = "Inicio";
            dgvPromociones.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPromociones.Columns["FechaFin"].HeaderText = "Fin";
            dgvPromociones.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPromociones.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvPromociones.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPromociones.Columns["EstatusRegistro"].HeaderCell.Value = "Estatus";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PromocionForm promocionForm = new PromocionForm("Agregar", IdUsuario, 0);
            promocionForm.NuevaPromocion += ObtenerPromociones;
            promocionForm.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPromocion.Text))
            {
                MessageBox.Show("Seleccione una promoción para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPromocion = Convert.ToInt32(txtIdPromocion.Text);
            PromocionForm promocionForm = new PromocionForm("Editar", IdUsuario, idPromocion);
            promocionForm.NuevaPromocion += ObtenerPromociones;
            promocionForm.Show();
        }

        private void dgvPromociones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdPromocion.Text = dgvPromociones.Rows[e.RowIndex].Cells["IdPromocion"].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPromocion.Text))
            {
                MessageBox.Show("Seleccione una promoción para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int idPromocion = Convert.ToInt32(txtIdPromocion.Text);
                EliminarPromocion(idPromocion, IdUsuario);
            }
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            ObtenerPromocionesInactivas();

            btnAgregar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInactivos.Visible = false;
            btnActivar.Visible = true;
            btnPromocionesActivos.Visible = true;
            txtBuscar.Visible = false;
            btnBuscar.Visible = false;
            panelBusqueda.Visible = false;
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPromocion.Text))
            {
                MessageBox.Show("Seleccione una promoción para activar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int idPromocion = Convert.ToInt32(txtIdPromocion.Text);
                ActivarPromocion(idPromocion, IdUsuario);
            }
        }

        private void btnPromocionesActivos_Click(object sender, EventArgs e)
        {
            ObtenerPromociones();

            btnAgregar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnInactivos.Visible = true;
            btnActivar.Visible = false;
            btnPromocionesActivos.Visible = false;
            txtBuscar.Visible = true;
            btnBuscar.Visible = true;
            panelBusqueda.Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                ObtenerPromociones();
            }
            else
            {
                Promocion promocion = new Promocion();
                promocion.Nombre = txtBuscar.Text;
                promocion.Descripcion = txtBuscar.Text;

                BuscarPromocion(promocion);
            }
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            Promocion promocion = new Promocion();
            promocion.Tipo = 1;

            BuscarPromocion(promocion);
        }

        private void btnMonto_Click(object sender, EventArgs e)
        {
            Promocion promocion = new Promocion();
            promocion.Tipo = 2;

            BuscarPromocion(promocion);
        }

        private void btn2x1_Click(object sender, EventArgs e)
        {
            Promocion promocion = new Promocion();
            promocion.Tipo = 3;

            BuscarPromocion(promocion);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (string.IsNullOrEmpty(txtBuscar.Text))
                {
                    ObtenerPromociones();
                }
                else
                {
                    Promocion promocion = new Promocion();
                    promocion.Nombre = txtBuscar.Text;
                    promocion.Descripcion = txtBuscar.Text;

                    BuscarPromocion(promocion);
                }
            }
        }
    }
}
