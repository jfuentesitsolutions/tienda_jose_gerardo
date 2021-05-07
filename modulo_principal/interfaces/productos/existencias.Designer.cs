namespace interfaces.productos
{
    partial class existencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(existencias));
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.cerrar = new System.Windows.Forms.PictureBox();
            this.lblEncanezado = new System.Windows.Forms.Label();
            this.tabla_existencias = new System.Windows.Forms.DataGridView();
            this.prese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_existencias)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTitulo.Controls.Add(this.cerrar);
            this.panelTitulo.Controls.Add(this.lblEncanezado);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(246, 51);
            this.panelTitulo.TabIndex = 6;
            this.panelTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitulo_MouseDown);
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrar.Image = ((System.Drawing.Image)(resources.GetObject("cerrar.Image")));
            this.cerrar.Location = new System.Drawing.Point(208, 8);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(32, 32);
            this.cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cerrar.TabIndex = 2;
            this.cerrar.TabStop = false;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // lblEncanezado
            // 
            this.lblEncanezado.AutoSize = true;
            this.lblEncanezado.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncanezado.ForeColor = System.Drawing.Color.White;
            this.lblEncanezado.Location = new System.Drawing.Point(68, 17);
            this.lblEncanezado.Name = "lblEncanezado";
            this.lblEncanezado.Size = new System.Drawing.Size(104, 23);
            this.lblEncanezado.TabIndex = 0;
            this.lblEncanezado.Text = "Existencias";
            // 
            // tabla_existencias
            // 
            this.tabla_existencias.AllowUserToAddRows = false;
            this.tabla_existencias.AllowUserToDeleteRows = false;
            this.tabla_existencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_existencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prese,
            this.canti,
            this.idpre,
            this.cai});
            this.tabla_existencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabla_existencias.Location = new System.Drawing.Point(0, 51);
            this.tabla_existencias.MultiSelect = false;
            this.tabla_existencias.Name = "tabla_existencias";
            this.tabla_existencias.RowHeadersVisible = false;
            this.tabla_existencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tabla_existencias.Size = new System.Drawing.Size(246, 189);
            this.tabla_existencias.TabIndex = 7;
            this.tabla_existencias.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.tabla_existencias_CellBeginEdit);
            this.tabla_existencias.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_existencias_CellEndEdit);
            // 
            // prese
            // 
            this.prese.HeaderText = "Presentaciones";
            this.prese.Name = "prese";
            this.prese.ReadOnly = true;
            this.prese.Width = 150;
            // 
            // canti
            // 
            this.canti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.canti.HeaderText = "Cantidad";
            this.canti.Name = "canti";
            // 
            // idpre
            // 
            this.idpre.HeaderText = "idprese";
            this.idpre.Name = "idpre";
            this.idpre.Visible = false;
            // 
            // cai
            // 
            this.cai.HeaderText = "cantii";
            this.cai.Name = "cai";
            this.cai.Visible = false;
            // 
            // existencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 240);
            this.Controls.Add(this.tabla_existencias);
            this.Controls.Add(this.panelTitulo);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "existencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "existencias";
            this.Load += new System.EventHandler(this.existencias_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_existencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.PictureBox cerrar;
        public System.Windows.Forms.Label lblEncanezado;
        private System.Windows.Forms.DataGridView tabla_existencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn prese;
        private System.Windows.Forms.DataGridViewTextBoxColumn canti;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cai;
    }
}