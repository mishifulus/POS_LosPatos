namespace LosPatosSystem.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MenuLateral = new System.Windows.Forms.Panel();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.Label();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnSlide = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnFReportes = new System.Windows.Forms.Button();
            this.btnFAjustes = new System.Windows.Forms.Button();
            this.btnFUsuarios = new System.Windows.Forms.Button();
            this.btnFCaja = new System.Windows.Forms.Button();
            this.btnDevoluciones = new System.Windows.Forms.Button();
            this.btnFPromociones = new System.Windows.Forms.Button();
            this.btnFCompras = new System.Windows.Forms.Button();
            this.btnFProductos = new System.Windows.Forms.Button();
            this.btnFVentas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MenuLateral.SuspendLayout();
            this.BarraTitulo.SuspendLayout();
            this.panelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuLateral
            // 
            this.MenuLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.MenuLateral.Controls.Add(this.panelUsuario);
            this.MenuLateral.Controls.Add(this.btnFReportes);
            this.MenuLateral.Controls.Add(this.btnFAjustes);
            this.MenuLateral.Controls.Add(this.btnFUsuarios);
            this.MenuLateral.Controls.Add(this.btnFCaja);
            this.MenuLateral.Controls.Add(this.btnDevoluciones);
            this.MenuLateral.Controls.Add(this.btnFPromociones);
            this.MenuLateral.Controls.Add(this.btnFCompras);
            this.MenuLateral.Controls.Add(this.btnFProductos);
            this.MenuLateral.Controls.Add(this.btnFVentas);
            this.MenuLateral.Controls.Add(this.pictureBox1);
            this.MenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuLateral.Location = new System.Drawing.Point(0, 0);
            this.MenuLateral.Name = "MenuLateral";
            this.MenuLateral.Size = new System.Drawing.Size(250, 850);
            this.MenuLateral.TabIndex = 0;
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.Gainsboro;
            this.BarraTitulo.Controls.Add(this.btnMaximizar);
            this.BarraTitulo.Controls.Add(this.btnMinimizar);
            this.BarraTitulo.Controls.Add(this.btnRestaurar);
            this.BarraTitulo.Controls.Add(this.btnClose);
            this.BarraTitulo.Controls.Add(this.btnSlide);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(250, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1050, 50);
            this.BarraTitulo.TabIndex = 1;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(250, 50);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(1050, 800);
            this.PanelContenedor.TabIndex = 2;
            // 
            // panelUsuario
            // 
            this.panelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelUsuario.Controls.Add(this.txtUsuario);
            this.panelUsuario.Controls.Add(this.pictureBox2);
            this.panelUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelUsuario.Location = new System.Drawing.Point(69, 723);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(170, 100);
            this.panelUsuario.TabIndex = 10;
            this.panelUsuario.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelUsuario_MouseClick);
            // 
            // txtUsuario
            // 
            this.txtUsuario.AutoSize = true;
            this.txtUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.White;
            this.txtUsuario.Location = new System.Drawing.Point(82, 54);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(79, 23);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Text = "Usuario";
            this.txtUsuario.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtUsuario_MouseClick);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(975, 9);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(33, 24);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 4;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(942, 10);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(27, 23);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(984, 8);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(24, 25);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 2;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1014, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 25);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSlide
            // 
            this.btnSlide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlide.Image = ((System.Drawing.Image)(resources.GetObject("btnSlide.Image")));
            this.btnSlide.Location = new System.Drawing.Point(4, 8);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(36, 36);
            this.btnSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSlide.TabIndex = 0;
            this.btnSlide.TabStop = false;
            this.btnSlide.Click += new System.EventHandler(this.btnSlide_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 70);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // btnFReportes
            // 
            this.btnFReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFReportes.FlatAppearance.BorderSize = 0;
            this.btnFReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFReportes.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFReportes.ForeColor = System.Drawing.Color.White;
            this.btnFReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnFReportes.Image")));
            this.btnFReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFReportes.Location = new System.Drawing.Point(12, 632);
            this.btnFReportes.Name = "btnFReportes";
            this.btnFReportes.Size = new System.Drawing.Size(215, 45);
            this.btnFReportes.TabIndex = 9;
            this.btnFReportes.Text = "Reportes";
            this.btnFReportes.UseVisualStyleBackColor = true;
            // 
            // btnFAjustes
            // 
            this.btnFAjustes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFAjustes.FlatAppearance.BorderSize = 0;
            this.btnFAjustes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFAjustes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFAjustes.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFAjustes.ForeColor = System.Drawing.Color.White;
            this.btnFAjustes.Image = ((System.Drawing.Image)(resources.GetObject("btnFAjustes.Image")));
            this.btnFAjustes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFAjustes.Location = new System.Drawing.Point(12, 581);
            this.btnFAjustes.Name = "btnFAjustes";
            this.btnFAjustes.Size = new System.Drawing.Size(215, 45);
            this.btnFAjustes.TabIndex = 8;
            this.btnFAjustes.Text = "Ajustes";
            this.btnFAjustes.UseVisualStyleBackColor = true;
            // 
            // btnFUsuarios
            // 
            this.btnFUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFUsuarios.FlatAppearance.BorderSize = 0;
            this.btnFUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFUsuarios.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnFUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnFUsuarios.Image")));
            this.btnFUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFUsuarios.Location = new System.Drawing.Point(12, 520);
            this.btnFUsuarios.Name = "btnFUsuarios";
            this.btnFUsuarios.Size = new System.Drawing.Size(215, 45);
            this.btnFUsuarios.TabIndex = 7;
            this.btnFUsuarios.Text = "Usuarios";
            this.btnFUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnFCaja
            // 
            this.btnFCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFCaja.FlatAppearance.BorderSize = 0;
            this.btnFCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFCaja.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCaja.ForeColor = System.Drawing.Color.White;
            this.btnFCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnFCaja.Image")));
            this.btnFCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFCaja.Location = new System.Drawing.Point(12, 455);
            this.btnFCaja.Name = "btnFCaja";
            this.btnFCaja.Size = new System.Drawing.Size(215, 45);
            this.btnFCaja.TabIndex = 6;
            this.btnFCaja.Text = "Caja";
            this.btnFCaja.UseVisualStyleBackColor = true;
            // 
            // btnDevoluciones
            // 
            this.btnDevoluciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevoluciones.FlatAppearance.BorderSize = 0;
            this.btnDevoluciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDevoluciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevoluciones.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevoluciones.ForeColor = System.Drawing.Color.White;
            this.btnDevoluciones.Image = ((System.Drawing.Image)(resources.GetObject("btnDevoluciones.Image")));
            this.btnDevoluciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevoluciones.Location = new System.Drawing.Point(12, 393);
            this.btnDevoluciones.Name = "btnDevoluciones";
            this.btnDevoluciones.Size = new System.Drawing.Size(215, 45);
            this.btnDevoluciones.TabIndex = 5;
            this.btnDevoluciones.Text = "    Devoluciones";
            this.btnDevoluciones.UseVisualStyleBackColor = true;
            // 
            // btnFPromociones
            // 
            this.btnFPromociones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFPromociones.FlatAppearance.BorderSize = 0;
            this.btnFPromociones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFPromociones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFPromociones.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFPromociones.ForeColor = System.Drawing.Color.White;
            this.btnFPromociones.Image = ((System.Drawing.Image)(resources.GetObject("btnFPromociones.Image")));
            this.btnFPromociones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFPromociones.Location = new System.Drawing.Point(12, 327);
            this.btnFPromociones.Name = "btnFPromociones";
            this.btnFPromociones.Size = new System.Drawing.Size(215, 45);
            this.btnFPromociones.TabIndex = 4;
            this.btnFPromociones.Text = "   Promociones";
            this.btnFPromociones.UseVisualStyleBackColor = true;
            // 
            // btnFCompras
            // 
            this.btnFCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFCompras.FlatAppearance.BorderSize = 0;
            this.btnFCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFCompras.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCompras.ForeColor = System.Drawing.Color.White;
            this.btnFCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnFCompras.Image")));
            this.btnFCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFCompras.Location = new System.Drawing.Point(12, 267);
            this.btnFCompras.Name = "btnFCompras";
            this.btnFCompras.Size = new System.Drawing.Size(215, 45);
            this.btnFCompras.TabIndex = 3;
            this.btnFCompras.Text = "Compras";
            this.btnFCompras.UseVisualStyleBackColor = true;
            // 
            // btnFProductos
            // 
            this.btnFProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFProductos.FlatAppearance.BorderSize = 0;
            this.btnFProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFProductos.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFProductos.ForeColor = System.Drawing.Color.White;
            this.btnFProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnFProductos.Image")));
            this.btnFProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFProductos.Location = new System.Drawing.Point(12, 203);
            this.btnFProductos.Name = "btnFProductos";
            this.btnFProductos.Size = new System.Drawing.Size(215, 45);
            this.btnFProductos.TabIndex = 2;
            this.btnFProductos.Text = "Productos";
            this.btnFProductos.UseVisualStyleBackColor = true;
            this.btnFProductos.Click += new System.EventHandler(this.btnFProductos_Click);
            // 
            // btnFVentas
            // 
            this.btnFVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFVentas.FlatAppearance.BorderSize = 0;
            this.btnFVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFVentas.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFVentas.ForeColor = System.Drawing.Color.White;
            this.btnFVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnFVentas.Image")));
            this.btnFVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFVentas.Location = new System.Drawing.Point(12, 138);
            this.btnFVentas.Name = "btnFVentas";
            this.btnFVentas.Size = new System.Drawing.Size(215, 45);
            this.btnFVentas.TabIndex = 1;
            this.btnFVentas.Text = "Ventas";
            this.btnFVentas.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1300, 850);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.MenuLateral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MenuLateral.ResumeLayout(false);
            this.BarraTitulo.ResumeLayout(false);
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuLateral;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.PictureBox btnSlide;
        private System.Windows.Forms.Panel PanelContenedor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.Button btnFVentas;
        private System.Windows.Forms.Button btnFAjustes;
        private System.Windows.Forms.Button btnFUsuarios;
        private System.Windows.Forms.Button btnFCaja;
        private System.Windows.Forms.Button btnDevoluciones;
        private System.Windows.Forms.Button btnFPromociones;
        private System.Windows.Forms.Button btnFCompras;
        private System.Windows.Forms.Button btnFProductos;
        private System.Windows.Forms.Button btnFReportes;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Label txtUsuario;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}