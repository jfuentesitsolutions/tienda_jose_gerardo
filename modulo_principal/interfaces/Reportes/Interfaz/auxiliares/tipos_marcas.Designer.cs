namespace interfaces.Reportes.Interfaz.auxiliares
{
    partial class tipos_marcas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tipos_marcas));
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.tabla_marcas = new System.Windows.Forms.DataGridView();
            this.tb_cate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.cerrar = new System.Windows.Forms.PictureBox();
            this.lblEncanezado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_marcas)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBusqueda.Location = new System.Drawing.Point(0, 46);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(278, 26);
            this.txtBusqueda.TabIndex = 16;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // tabla_marcas
            // 
            this.tabla_marcas.AllowUserToAddRows = false;
            this.tabla_marcas.AllowUserToDeleteRows = false;
            this.tabla_marcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_marcas.ColumnHeadersVisible = false;
            this.tabla_marcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tb_cate});
            this.tabla_marcas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabla_marcas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabla_marcas.Location = new System.Drawing.Point(0, 71);
            this.tabla_marcas.MultiSelect = false;
            this.tabla_marcas.Name = "tabla_marcas";
            this.tabla_marcas.ReadOnly = true;
            this.tabla_marcas.RowHeadersVisible = false;
            this.tabla_marcas.Size = new System.Drawing.Size(278, 246);
            this.tabla_marcas.TabIndex = 15;
            this.tabla_marcas.Click += new System.EventHandler(this.tabla_marcas_Click);
            // 
            // tb_cate
            // 
            this.tb_cate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tb_cate.DataPropertyName = "nombre";
            this.tb_cate.HeaderText = "MARCAS";
            this.tb_cate.Name = "tb_cate";
            this.tb_cate.ReadOnly = true;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.DimGray;
            this.panelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitulo.Controls.Add(this.cerrar);
            this.panelTitulo.Controls.Add(this.lblEncanezado);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(278, 46);
            this.panelTitulo.TabIndex = 14;
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrar.Image = ((System.Drawing.Image)(resources.GetObject("cerrar.Image")));
            this.cerrar.Location = new System.Drawing.Point(237, 6);
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
            this.lblEncanezado.Location = new System.Drawing.Point(39, 14);
            this.lblEncanezado.Name = "lblEncanezado";
            this.lblEncanezado.Size = new System.Drawing.Size(189, 23);
            this.lblEncanezado.TabIndex = 0;
            this.lblEncanezado.Text = "Selecciona una marca";
            // 
            // tipos_marcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 317);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.tabla_marcas);
            this.Controls.Add(this.panelTitulo);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "tipos_marcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tipos_marcas";
            this.Load += new System.EventHandler(this.tipos_marcas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_marcas)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridView tabla_marcas;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.PictureBox cerrar;
        public System.Windows.Forms.Label lblEncanezado;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_cate;
    }
}