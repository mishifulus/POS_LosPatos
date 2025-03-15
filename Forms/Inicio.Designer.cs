namespace LosPatosSystem.Forms
{
    partial class Inicio
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.Label();
            this.dgvBajoStock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBajoStock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(417, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "SUMARIO DEL DÍA";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(59, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 180);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "PRODUCTOS BAJOS DE STOCK";
            // 
            // txtHora
            // 
            this.txtHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHora.AutoSize = true;
            this.txtHora.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.txtHora.Location = new System.Drawing.Point(646, 446);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(290, 112);
            this.txtHora.TabIndex = 4;
            this.txtHora.Text = "09:55";
            // 
            // txtFecha
            // 
            this.txtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFecha.AutoSize = true;
            this.txtFecha.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            this.txtFecha.Location = new System.Drawing.Point(569, 558);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(454, 38);
            this.txtFecha.TabIndex = 5;
            this.txtFecha.Text = "Jueves 13 de marzo de 2023";
            // 
            // dgvBajoStock
            // 
            this.dgvBajoStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBajoStock.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBajoStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(25)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBajoStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBajoStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBajoStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvBajoStock.Location = new System.Drawing.Point(26, 392);
            this.dgvBajoStock.Name = "dgvBajoStock";
            this.dgvBajoStock.ReadOnly = true;
            this.dgvBajoStock.RowHeadersWidth = 62;
            this.dgvBajoStock.RowTemplate.Height = 28;
            this.dgvBajoStock.Size = new System.Drawing.Size(537, 378);
            this.dgvBajoStock.TabIndex = 6;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1050, 800);
            this.Controls.Add(this.dgvBajoStock);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBajoStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtHora;
        private System.Windows.Forms.Label txtFecha;
        private System.Windows.Forms.DataGridView dgvBajoStock;
    }
}