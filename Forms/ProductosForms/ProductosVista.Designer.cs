namespace LosPatosSystem.Forms
{
    partial class ProductosVista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductosVista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.btnProductosActivos = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnAguas = new System.Windows.Forms.Button();
            this.btnJugos = new System.Windows.Forms.Button();
            this.btnDesechable = new System.Windows.Forms.Button();
            this.btnCigarros = new System.Windows.Forms.Button();
            this.btnPapas = new System.Windows.Forms.Button();
            this.btnRefrescos = new System.Windows.Forms.Button();
            this.btnCerveza = new System.Windows.Forms.Button();
            this.btnInactivos = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnUnidades = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.btnBuscar);
            this.panelBusqueda.Location = new System.Drawing.Point(33, 38);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(274, 45);
            this.panelBusqueda.TabIndex = 4;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(56, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(208, 25);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(3, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(47, 39);
            this.btnBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductos.Location = new System.Drawing.Point(32, 114);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 62;
            this.dgvProductos.RowTemplate.Height = 28;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(932, 623);
            this.dgvProductos.TabIndex = 40;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(878, 7);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(100, 26);
            this.txtIdProducto.TabIndex = 41;
            this.txtIdProducto.Visible = false;
            // 
            // btnProductosActivos
            // 
            this.btnProductosActivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnProductosActivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductosActivos.FlatAppearance.BorderSize = 0;
            this.btnProductosActivos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnProductosActivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductosActivos.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductosActivos.ForeColor = System.Drawing.Color.White;
            this.btnProductosActivos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductosActivos.Image")));
            this.btnProductosActivos.Location = new System.Drawing.Point(518, 38);
            this.btnProductosActivos.Name = "btnProductosActivos";
            this.btnProductosActivos.Size = new System.Drawing.Size(46, 45);
            this.btnProductosActivos.TabIndex = 43;
            this.btnProductosActivos.UseVisualStyleBackColor = false;
            this.btnProductosActivos.Visible = false;
            this.btnProductosActivos.Click += new System.EventHandler(this.btnProductosActivos_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnActivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivar.FlatAppearance.BorderSize = 0;
            this.btnActivar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.ForeColor = System.Drawing.Color.White;
            this.btnActivar.Image = ((System.Drawing.Image)(resources.GetObject("btnActivar.Image")));
            this.btnActivar.Location = new System.Drawing.Point(452, 39);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(46, 45);
            this.btnActivar.TabIndex = 42;
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Visible = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnAguas
            // 
            this.btnAguas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAguas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnAguas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAguas.FlatAppearance.BorderSize = 0;
            this.btnAguas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAguas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAguas.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAguas.ForeColor = System.Drawing.Color.White;
            this.btnAguas.Image = ((System.Drawing.Image)(resources.GetObject("btnAguas.Image")));
            this.btnAguas.Location = new System.Drawing.Point(982, 500);
            this.btnAguas.Name = "btnAguas";
            this.btnAguas.Size = new System.Drawing.Size(46, 45);
            this.btnAguas.TabIndex = 17;
            this.btnAguas.UseVisualStyleBackColor = false;
            this.btnAguas.Click += new System.EventHandler(this.btnAguas_Click);
            // 
            // btnJugos
            // 
            this.btnJugos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnJugos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnJugos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJugos.FlatAppearance.BorderSize = 0;
            this.btnJugos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnJugos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJugos.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugos.ForeColor = System.Drawing.Color.White;
            this.btnJugos.Image = ((System.Drawing.Image)(resources.GetObject("btnJugos.Image")));
            this.btnJugos.Location = new System.Drawing.Point(982, 435);
            this.btnJugos.Name = "btnJugos";
            this.btnJugos.Size = new System.Drawing.Size(46, 45);
            this.btnJugos.TabIndex = 16;
            this.btnJugos.UseVisualStyleBackColor = false;
            this.btnJugos.Click += new System.EventHandler(this.btnJugos_Click);
            // 
            // btnDesechable
            // 
            this.btnDesechable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDesechable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnDesechable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesechable.FlatAppearance.BorderSize = 0;
            this.btnDesechable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDesechable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesechable.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesechable.ForeColor = System.Drawing.Color.White;
            this.btnDesechable.Image = ((System.Drawing.Image)(resources.GetObject("btnDesechable.Image")));
            this.btnDesechable.Location = new System.Drawing.Point(982, 372);
            this.btnDesechable.Name = "btnDesechable";
            this.btnDesechable.Size = new System.Drawing.Size(46, 45);
            this.btnDesechable.TabIndex = 15;
            this.btnDesechable.UseVisualStyleBackColor = false;
            this.btnDesechable.Click += new System.EventHandler(this.btnDesechable_Click);
            // 
            // btnCigarros
            // 
            this.btnCigarros.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCigarros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnCigarros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCigarros.FlatAppearance.BorderSize = 0;
            this.btnCigarros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCigarros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCigarros.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCigarros.ForeColor = System.Drawing.Color.White;
            this.btnCigarros.Image = ((System.Drawing.Image)(resources.GetObject("btnCigarros.Image")));
            this.btnCigarros.Location = new System.Drawing.Point(982, 311);
            this.btnCigarros.Name = "btnCigarros";
            this.btnCigarros.Size = new System.Drawing.Size(46, 45);
            this.btnCigarros.TabIndex = 14;
            this.btnCigarros.UseVisualStyleBackColor = false;
            this.btnCigarros.Click += new System.EventHandler(this.btnCigarros_Click);
            // 
            // btnPapas
            // 
            this.btnPapas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPapas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnPapas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPapas.FlatAppearance.BorderSize = 0;
            this.btnPapas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPapas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPapas.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPapas.ForeColor = System.Drawing.Color.White;
            this.btnPapas.Image = ((System.Drawing.Image)(resources.GetObject("btnPapas.Image")));
            this.btnPapas.Location = new System.Drawing.Point(982, 246);
            this.btnPapas.Name = "btnPapas";
            this.btnPapas.Size = new System.Drawing.Size(46, 45);
            this.btnPapas.TabIndex = 13;
            this.btnPapas.UseVisualStyleBackColor = false;
            this.btnPapas.Click += new System.EventHandler(this.btnPapas_Click);
            // 
            // btnRefrescos
            // 
            this.btnRefrescos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRefrescos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnRefrescos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescos.FlatAppearance.BorderSize = 0;
            this.btnRefrescos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRefrescos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescos.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescos.ForeColor = System.Drawing.Color.White;
            this.btnRefrescos.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescos.Image")));
            this.btnRefrescos.Location = new System.Drawing.Point(982, 179);
            this.btnRefrescos.Name = "btnRefrescos";
            this.btnRefrescos.Size = new System.Drawing.Size(46, 45);
            this.btnRefrescos.TabIndex = 12;
            this.btnRefrescos.UseVisualStyleBackColor = false;
            this.btnRefrescos.Click += new System.EventHandler(this.btnRefrescos_Click);
            // 
            // btnCerveza
            // 
            this.btnCerveza.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerveza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnCerveza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerveza.FlatAppearance.BorderSize = 0;
            this.btnCerveza.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCerveza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerveza.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerveza.ForeColor = System.Drawing.Color.White;
            this.btnCerveza.Image = ((System.Drawing.Image)(resources.GetObject("btnCerveza.Image")));
            this.btnCerveza.Location = new System.Drawing.Point(982, 114);
            this.btnCerveza.Name = "btnCerveza";
            this.btnCerveza.Size = new System.Drawing.Size(46, 45);
            this.btnCerveza.TabIndex = 11;
            this.btnCerveza.UseVisualStyleBackColor = false;
            this.btnCerveza.Click += new System.EventHandler(this.btnCerveza_Click);
            // 
            // btnInactivos
            // 
            this.btnInactivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnInactivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInactivos.FlatAppearance.BorderSize = 0;
            this.btnInactivos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnInactivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInactivos.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInactivos.ForeColor = System.Drawing.Color.White;
            this.btnInactivos.Image = ((System.Drawing.Image)(resources.GetObject("btnInactivos.Image")));
            this.btnInactivos.Location = new System.Drawing.Point(518, 39);
            this.btnInactivos.Name = "btnInactivos";
            this.btnInactivos.Size = new System.Drawing.Size(46, 45);
            this.btnInactivos.TabIndex = 10;
            this.btnInactivos.UseVisualStyleBackColor = false;
            this.btnInactivos.Click += new System.EventHandler(this.btnInactivos_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.Color.White;
            this.btnCategorias.Image = ((System.Drawing.Image)(resources.GetObject("btnCategorias.Image")));
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(827, 39);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(181, 45);
            this.btnCategorias.TabIndex = 9;
            this.btnCategorias.Text = "    Categorias";
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnUnidades
            // 
            this.btnUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnUnidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnidades.FlatAppearance.BorderSize = 0;
            this.btnUnidades.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUnidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnidades.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnidades.ForeColor = System.Drawing.Color.White;
            this.btnUnidades.Image = ((System.Drawing.Image)(resources.GetObject("btnUnidades.Image")));
            this.btnUnidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnidades.Location = new System.Drawing.Point(655, 38);
            this.btnUnidades.Name = "btnUnidades";
            this.btnUnidades.Size = new System.Drawing.Size(158, 45);
            this.btnUnidades.TabIndex = 8;
            this.btnUnidades.Text = "    Unidades";
            this.btnUnidades.UseVisualStyleBackColor = false;
            this.btnUnidades.Click += new System.EventHandler(this.btnUnidades_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(452, 39);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(46, 45);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(386, 39);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(46, 45);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(321, 39);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(46, 45);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // ProductosVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1050, 800);
            this.Controls.Add(this.btnProductosActivos);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnAguas);
            this.Controls.Add(this.btnJugos);
            this.Controls.Add(this.btnDesechable);
            this.Controls.Add(this.btnCigarros);
            this.Controls.Add(this.btnPapas);
            this.Controls.Add(this.btnRefrescos);
            this.Controls.Add(this.btnCerveza);
            this.Controls.Add(this.btnInactivos);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnUnidades);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductosVista";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.PictureBox btnBuscar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnUnidades;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnInactivos;
        private System.Windows.Forms.Button btnCerveza;
        private System.Windows.Forms.Button btnRefrescos;
        private System.Windows.Forms.Button btnPapas;
        private System.Windows.Forms.Button btnCigarros;
        private System.Windows.Forms.Button btnDesechable;
        private System.Windows.Forms.Button btnJugos;
        private System.Windows.Forms.Button btnAguas;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnProductosActivos;
    }
}