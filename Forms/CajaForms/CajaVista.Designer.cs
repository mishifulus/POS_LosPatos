namespace LosPatosSystem.Forms.CajaForms
{
    partial class CajaVista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CajaVista));
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIngresos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEgresos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBalance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnEgresos = new System.Windows.Forms.Button();
            this.btnIngresos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvMovimientos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMovimientos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMovimientos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMovimientos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMovimientos.Location = new System.Drawing.Point(29, 123);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.RowHeadersWidth = 62;
            this.dgvMovimientos.RowTemplate.Height = 28;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(932, 623);
            this.dgvMovimientos.TabIndex = 58;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.txtIngresos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(311, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 91);
            this.panel1.TabIndex = 61;
            // 
            // txtIngresos
            // 
            this.txtIngresos.AutoSize = true;
            this.txtIngresos.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngresos.Location = new System.Drawing.Point(73, 42);
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.Size = new System.Drawing.Size(53, 38);
            this.txtIngresos.TabIndex = 1;
            this.txtIngresos.Text = "$0";
            this.txtIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresos";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.txtEgresos);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(533, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 91);
            this.panel2.TabIndex = 62;
            // 
            // txtEgresos
            // 
            this.txtEgresos.AutoSize = true;
            this.txtEgresos.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEgresos.Location = new System.Drawing.Point(75, 42);
            this.txtEgresos.Name = "txtEgresos";
            this.txtEgresos.Size = new System.Drawing.Size(53, 38);
            this.txtEgresos.TabIndex = 2;
            this.txtEgresos.Text = "$0";
            this.txtEgresos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Egresos";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.txtBalance);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(761, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 91);
            this.panel3.TabIndex = 63;
            // 
            // txtBalance
            // 
            this.txtBalance.AutoSize = true;
            this.txtBalance.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(72, 42);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(53, 38);
            this.txtBalance.TabIndex = 3;
            this.txtBalance.Text = "$0";
            this.txtBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Balance del Día";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.Location = new System.Drawing.Point(121, 47);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(46, 45);
            this.btnFiltrar.TabIndex = 60;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnEgresos
            // 
            this.btnEgresos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEgresos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnEgresos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEgresos.FlatAppearance.BorderSize = 0;
            this.btnEgresos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnEgresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEgresos.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEgresos.ForeColor = System.Drawing.Color.White;
            this.btnEgresos.Image = ((System.Drawing.Image)(resources.GetObject("btnEgresos.Image")));
            this.btnEgresos.Location = new System.Drawing.Point(979, 188);
            this.btnEgresos.Name = "btnEgresos";
            this.btnEgresos.Size = new System.Drawing.Size(46, 45);
            this.btnEgresos.TabIndex = 52;
            this.btnEgresos.UseVisualStyleBackColor = false;
            this.btnEgresos.Click += new System.EventHandler(this.btnEgresos_Click);
            // 
            // btnIngresos
            // 
            this.btnIngresos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnIngresos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.btnIngresos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresos.FlatAppearance.BorderSize = 0;
            this.btnIngresos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresos.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresos.ForeColor = System.Drawing.Color.White;
            this.btnIngresos.Image = ((System.Drawing.Image)(resources.GetObject("btnIngresos.Image")));
            this.btnIngresos.Location = new System.Drawing.Point(979, 123);
            this.btnIngresos.Name = "btnIngresos";
            this.btnIngresos.Size = new System.Drawing.Size(46, 45);
            this.btnIngresos.TabIndex = 51;
            this.btnIngresos.UseVisualStyleBackColor = false;
            this.btnIngresos.Click += new System.EventHandler(this.btnIngresos_Click);
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
            this.btnAgregar.Location = new System.Drawing.Point(52, 47);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(46, 45);
            this.btnAgregar.TabIndex = 44;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // CajaVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1050, 800);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.btnEgresos);
            this.Controls.Add(this.btnIngresos);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CajaVista";
            this.Text = "CajaVista";
            this.Load += new System.EventHandler(this.CajaVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Button btnEgresos;
        private System.Windows.Forms.Button btnIngresos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtIngresos;
        private System.Windows.Forms.Label txtEgresos;
        private System.Windows.Forms.Label txtBalance;
    }
}