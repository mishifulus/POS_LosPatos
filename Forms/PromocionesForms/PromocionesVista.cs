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
            if (dgvPromociones.Width == 932 && dgvPromociones.Height == 577)
            {
                dgvPromociones.Width = dgvPromociones.Width + 610;
                dgvPromociones.Height = dgvPromociones.Height + 200;
            }
            else
            {
                dgvPromociones.Width = 932;
                dgvPromociones.Height = 577;
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
            dgvPromociones.Columns["IdProducto"].Visible = false;
            dgvPromociones.Columns["IdUsuario"].Visible = false;

        }
    }
}
