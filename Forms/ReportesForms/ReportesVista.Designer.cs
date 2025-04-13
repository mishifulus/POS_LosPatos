namespace LosPatosSystem.Forms.ReportesForms
{
    partial class ReportesVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesVista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReporteVentas = new System.Windows.Forms.Button();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProductosMasVendidos = new System.Windows.Forms.Button();
            this.btnReporteCompras = new System.Windows.Forms.Button();
            this.btnVentasPromociones = new System.Windows.Forms.Button();
            this.btnDevoluciones = new System.Windows.Forms.Button();
            this.btnBalanceDiario = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReporteVentas
            // 
            this.btnReporteVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnReporteVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteVentas.FlatAppearance.BorderSize = 0;
            this.btnReporteVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReporteVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteVentas.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteVentas.ForeColor = System.Drawing.Color.White;
            this.btnReporteVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteVentas.Image")));
            this.btnReporteVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporteVentas.Location = new System.Drawing.Point(28, 210);
            this.btnReporteVentas.Name = "btnReporteVentas";
            this.btnReporteVentas.Size = new System.Drawing.Size(271, 45);
            this.btnReporteVentas.TabIndex = 9;
            this.btnReporteVentas.Text = " Ventas";
            this.btnReporteVentas.UseVisualStyleBackColor = false;
            this.btnReporteVentas.Click += new System.EventHandler(this.btnReporteVentas_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CalendarFont = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Location = new System.Drawing.Point(543, 113);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(351, 27);
            this.dtpFechaFin.TabIndex = 74;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarFont = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Location = new System.Drawing.Point(84, 113);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(351, 27);
            this.dtpFechaInicio.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(527, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 23);
            this.label3.TabIndex = 72;
            this.label3.Text = "Al:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 71;
            this.label2.Text = "Del:";
            // 
            // btnProductosMasVendidos
            // 
            this.btnProductosMasVendidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnProductosMasVendidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductosMasVendidos.FlatAppearance.BorderSize = 0;
            this.btnProductosMasVendidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnProductosMasVendidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductosMasVendidos.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductosMasVendidos.ForeColor = System.Drawing.Color.White;
            this.btnProductosMasVendidos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductosMasVendidos.Image")));
            this.btnProductosMasVendidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductosMasVendidos.Location = new System.Drawing.Point(28, 283);
            this.btnProductosMasVendidos.Name = "btnProductosMasVendidos";
            this.btnProductosMasVendidos.Size = new System.Drawing.Size(271, 45);
            this.btnProductosMasVendidos.TabIndex = 75;
            this.btnProductosMasVendidos.Text = "Más Vendidos";
            this.btnProductosMasVendidos.UseVisualStyleBackColor = false;
            this.btnProductosMasVendidos.Click += new System.EventHandler(this.btnProductosMasVendidos_Click);
            // 
            // btnReporteCompras
            // 
            this.btnReporteCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnReporteCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteCompras.FlatAppearance.BorderSize = 0;
            this.btnReporteCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReporteCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteCompras.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteCompras.ForeColor = System.Drawing.Color.White;
            this.btnReporteCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteCompras.Image")));
            this.btnReporteCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporteCompras.Location = new System.Drawing.Point(28, 442);
            this.btnReporteCompras.Name = "btnReporteCompras";
            this.btnReporteCompras.Size = new System.Drawing.Size(271, 45);
            this.btnReporteCompras.TabIndex = 77;
            this.btnReporteCompras.Text = " Compras";
            this.btnReporteCompras.UseVisualStyleBackColor = false;
            this.btnReporteCompras.Click += new System.EventHandler(this.btnReporteCompras_Click);
            // 
            // btnVentasPromociones
            // 
            this.btnVentasPromociones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnVentasPromociones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentasPromociones.FlatAppearance.BorderSize = 0;
            this.btnVentasPromociones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVentasPromociones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasPromociones.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasPromociones.ForeColor = System.Drawing.Color.White;
            this.btnVentasPromociones.Image = ((System.Drawing.Image)(resources.GetObject("btnVentasPromociones.Image")));
            this.btnVentasPromociones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentasPromociones.Location = new System.Drawing.Point(28, 362);
            this.btnVentasPromociones.Name = "btnVentasPromociones";
            this.btnVentasPromociones.Size = new System.Drawing.Size(271, 45);
            this.btnVentasPromociones.TabIndex = 76;
            this.btnVentasPromociones.Text = " Ventas Con Promo";
            this.btnVentasPromociones.UseVisualStyleBackColor = false;
            this.btnVentasPromociones.Click += new System.EventHandler(this.btnVentasPromociones_Click);
            // 
            // btnDevoluciones
            // 
            this.btnDevoluciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnDevoluciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevoluciones.FlatAppearance.BorderSize = 0;
            this.btnDevoluciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDevoluciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevoluciones.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevoluciones.ForeColor = System.Drawing.Color.White;
            this.btnDevoluciones.Image = ((System.Drawing.Image)(resources.GetObject("btnDevoluciones.Image")));
            this.btnDevoluciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevoluciones.Location = new System.Drawing.Point(28, 590);
            this.btnDevoluciones.Name = "btnDevoluciones";
            this.btnDevoluciones.Size = new System.Drawing.Size(271, 45);
            this.btnDevoluciones.TabIndex = 79;
            this.btnDevoluciones.Text = "Devoluciones";
            this.btnDevoluciones.UseVisualStyleBackColor = false;
            this.btnDevoluciones.Click += new System.EventHandler(this.btnDevoluciones_Click);
            // 
            // btnBalanceDiario
            // 
            this.btnBalanceDiario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnBalanceDiario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBalanceDiario.FlatAppearance.BorderSize = 0;
            this.btnBalanceDiario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnBalanceDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceDiario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalanceDiario.ForeColor = System.Drawing.Color.White;
            this.btnBalanceDiario.Image = ((System.Drawing.Image)(resources.GetObject("btnBalanceDiario.Image")));
            this.btnBalanceDiario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceDiario.Location = new System.Drawing.Point(28, 520);
            this.btnBalanceDiario.Name = "btnBalanceDiario";
            this.btnBalanceDiario.Size = new System.Drawing.Size(271, 45);
            this.btnBalanceDiario.TabIndex = 78;
            this.btnBalanceDiario.Text = "Balance Diario";
            this.btnBalanceDiario.UseVisualStyleBackColor = false;
            this.btnBalanceDiario.Click += new System.EventHandler(this.btnBalanceDiario_Click);
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvReporte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvReporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReporte.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporte.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReporte.Location = new System.Drawing.Point(338, 166);
            this.dgvReporte.MultiSelect = false;
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.RowHeadersWidth = 62;
            this.dgvReporte.RowTemplate.Height = 28;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(666, 545);
            this.dgvReporte.TabIndex = 80;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(72, 666);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(163, 45);
            this.btnExcel.TabIndex = 81;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // ReportesVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1050, 800);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.btnDevoluciones);
            this.Controls.Add(this.btnBalanceDiario);
            this.Controls.Add(this.btnReporteCompras);
            this.Controls.Add(this.btnVentasPromociones);
            this.Controls.Add(this.btnProductosMasVendidos);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReporteVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportesVista";
            this.Text = "ReportesVista";
            this.Load += new System.EventHandler(this.ReportesVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReporteVentas;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnProductosMasVendidos;
        private System.Windows.Forms.Button btnReporteCompras;
        private System.Windows.Forms.Button btnVentasPromociones;
        private System.Windows.Forms.Button btnDevoluciones;
        private System.Windows.Forms.Button btnBalanceDiario;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnExcel;
    }
}