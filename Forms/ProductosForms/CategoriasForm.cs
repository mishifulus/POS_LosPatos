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
    public partial class CategoriasForm: Form
    {
        public int IdUsuario { get; set; }
        public CategoriasForm(int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
        }

        private void CategoriasForm_Load(object sender, EventArgs e)
        {
            ObtenerCategorias();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            UnidadesForm.ActiveForm.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreCategoria = txtNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombreCategoria))
            {
                MessageBox.Show("Ingrese el nombre de la categoría", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                GuardarCategoria(nombreCategoria, IdUsuario);
            }
            else
            {
                int idCategoria = Convert.ToInt32(txtIdCategoria.Text);
                ActualizarCategoria(idCategoria, nombreCategoria, IdUsuario);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtIdCategoria.Text = string.Empty;
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idCategoria = Convert.ToInt32(dgvCategorias.Rows[e.RowIndex].Cells["IdCategoria"].Value);
                string nombreCategoria = dgvCategorias.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                txtIdCategoria.Text = idCategoria.ToString();
                txtNombre.Text = nombreCategoria;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                MessageBox.Show("Seleccione una categoría para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int idCategoria = Convert.ToInt32(txtIdCategoria.Text);
                EliminarCategoria(idCategoria, IdUsuario);
            }
        }

        private void ObtenerCategorias()
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            DataSet dataSet = categoriaDAO.selectCategoria("L", 0, null);
            dgvCategorias.DataSource = dataSet.Tables["Categoria"];

            dgvCategorias.Columns["IdCategoria"].Visible = false;
            dgvCategorias.Columns["Nombre"].HeaderText = "Categoria";
            dgvCategorias.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
            dgvCategorias.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCategorias.Columns["EstatusRegistro"].Visible = false;
            dgvCategorias.Columns["IdUsuario"].Visible = false;
        }

        private void GuardarCategoria(string nombreCategoria, int idUsuario)
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = nombreCategoria;
            categoria.IdUsuario = idUsuario;

            CategoriaDAO categoriaDAO = new CategoriaDAO();
            categoriaDAO.CrudCategoria(categoria, "C");

            MessageBox.Show("Categoria agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = string.Empty;
            ObtenerCategorias();
        }

        private void ActualizarCategoria(int idCategoria, string nombreCategoria, int idUsuario)
        {
            Categoria categoria = new Categoria();
            categoria.IdCategoria = idCategoria;
            categoria.Nombre = nombreCategoria;
            categoria.IdUsuario = idUsuario;

            CategoriaDAO categoriaDAO = new CategoriaDAO();
            categoriaDAO.CrudCategoria(categoria, "U");

            MessageBox.Show("Categoria editada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = string.Empty;
            txtIdCategoria.Text = string.Empty;
            ObtenerCategorias();
        }

        private void EliminarCategoria(int idCategoria, int idUsuario)
        {
            Categoria categoria = new Categoria();
            categoria.IdCategoria = idCategoria;
            categoria.IdUsuario = idUsuario;

            CategoriaDAO categoriaDAO = new CategoriaDAO();
            categoriaDAO.CrudCategoria(categoria, "D");
            MessageBox.Show("Categoria eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = string.Empty;
            txtIdCategoria.Text = string.Empty;
            ObtenerCategorias();
        }
    }
}
