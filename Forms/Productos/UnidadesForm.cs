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
    public partial class UnidadesForm: Form
    {
        public int IdUsuario { get; set; }
        public UnidadesForm(int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UnidadesForm.ActiveForm.Close();
        }

        private void UnidadesForm_Load(object sender, EventArgs e)
        {
            ObtenerUnidades();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreUnidad = txtNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombreUnidad))
            {
                MessageBox.Show("Ingrese el nombre de la unidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtIdUnidad.Text))
            {
                GuardarUnidad(nombreUnidad, IdUsuario);
            }
            else
            {
                int idUnidad = Convert.ToInt32(txtIdUnidad.Text);
                ActualizarUnidad(idUnidad, nombreUnidad, IdUsuario);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtIdUnidad.Text = string.Empty;
        }

        private void dgvUnidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idUnidad = Convert.ToInt32(dgvUnidades.Rows[e.RowIndex].Cells["IdUnidad"].Value);
                string nombreUnidad = dgvUnidades.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                txtIdUnidad.Text = idUnidad.ToString();
                txtNombre.Text = nombreUnidad;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUnidad.Text))
            {
                MessageBox.Show("Seleccione una unidad para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int idUnidad = Convert.ToInt32(txtIdUnidad.Text);
                EliminarUnidad(idUnidad, IdUsuario);
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

        private void ObtenerUnidades()
        {
            UnidadDAO unidadDAO = new UnidadDAO();
            DataSet dataSet = unidadDAO.selectUnidad("L", 0, null);
            dgvUnidades.DataSource = dataSet.Tables["Unidad"];

            dgvUnidades.Columns["IdUnidad"].Visible = false;
            dgvUnidades.Columns["Nombre"].HeaderText = "Unidad";
            dgvUnidades.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvUnidades.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvUnidades.Columns["EstatusRegistro"].Visible = false;
            dgvUnidades.Columns["IdUsuario"].Visible = false;
        }

        private void GuardarUnidad(string nombreUnidad, int idUsuario)
        {
            Unidad unidad = new Unidad();
            unidad.Nombre = nombreUnidad;
            unidad.IdUsuario = idUsuario;

            UnidadDAO unidadDAO = new UnidadDAO();
            unidadDAO.CrudUnidad(unidad, "C");

            MessageBox.Show("Unidad agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = string.Empty;
            ObtenerUnidades();
        }

        private void ActualizarUnidad(int idUnidad, string nombreUnidad, int idUsuario)
        {
            Unidad unidad = new Unidad();
            unidad.IdUnidad = idUnidad;
            unidad.Nombre = nombreUnidad;
            unidad.IdUsuario = idUsuario;

            UnidadDAO unidadDAO = new UnidadDAO();
            unidadDAO.CrudUnidad(unidad, "U");

            MessageBox.Show("Unidad editada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = string.Empty;
            txtIdUnidad.Text = string.Empty;
            ObtenerUnidades();
        }

        private void EliminarUnidad(int idUnidad, int idUsuario)
        {
            Unidad unidad = new Unidad();
            unidad.IdUnidad = idUnidad;
            unidad.IdUsuario = idUsuario;
            UnidadDAO unidadDAO = new UnidadDAO();
            unidadDAO.CrudUnidad(unidad, "D");
            MessageBox.Show("Unidad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = string.Empty;
            txtIdUnidad.Text = string.Empty;
            ObtenerUnidades();
        }
    }
}
