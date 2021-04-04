namespace interfaces.productos
{
    partial class proveedores_por_producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(proveedores_por_producto));
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.PictureBox();
            this.btnAgrega = new System.Windows.Forms.PictureBox();
            this.cerrar = new System.Windows.Forms.PictureBox();
            this.lblEncanezado = new System.Windows.Forms.Label();
            this.tabla_proveedores = new System.Windows.Forms.DataGridView();
            this.idpro_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idprovee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prove = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.idpro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_proveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTitulo.Controls.Add(this.btnEliminar);
            this.panelTitulo.Controls.Add(this.btnAgregar);
            this.panelTitulo.Controls.Add(this.btnAgrega);
            this.panelTitulo.Controls.Add(this.cerrar);
            this.panelTitulo.Controls.Add(this.lblEncanezado);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(712, 46);
            this.panelTitulo.TabIndex = 5;
            this.panelTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitulo_MouseDown);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Image = global::interfaces.Properties.Resources.cancel;
            this.btnEliminar.Location = new System.Drawing.Point(50, 8);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(32, 32);
            this.btnEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Image = global::interfaces.Properties.Resources.plus_2;
            this.btnAgregar.Location = new System.Drawing.Point(-69, 8);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(32, 32);
            this.btnAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.TabStop = false;
            // 
            // btnAgrega
            // 
            this.btnAgrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgrega.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgrega.Image = global::interfaces.Properties.Resources.plus_2;
            this.btnAgrega.Location = new System.Drawing.Point(12, 8);
            this.btnAgrega.Name = "btnAgrega";
            this.btnAgrega.Size = new System.Drawing.Size(32, 32);
            this.btnAgrega.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnAgrega.TabIndex = 7;
            this.btnAgrega.TabStop = false;
            this.btnAgrega.Click += new System.EventHandler(this.btnAgrega_Click);
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrar.Image = ((System.Drawing.Image)(resources.GetObject("cerrar.Image")));
            this.cerrar.Location = new System.Drawing.Point(673, 8);
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
            this.lblEncanezado.Location = new System.Drawing.Point(232, 9);
            this.lblEncanezado.Name = "lblEncanezado";
            this.lblEncanezado.Size = new System.Drawing.Size(226, 23);
            this.lblEncanezado.TabIndex = 0;
            this.lblEncanezado.Text = "Proveedores por producto";
            // 
            // tabla_proveedores
            // 
            this.tabla_proveedores.AllowUserToAddRows = false;
            this.tabla_proveedores.AllowUserToDeleteRows = false;
            this.tabla_proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_proveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpro_pro,
            this.idprovee,
            this.prove,
            this.idpro});
            this.tabla_proveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabla_proveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabla_proveedores.Location = new System.Drawing.Point(0, 46);
            this.tabla_proveedores.MultiSelect = false;
            this.tabla_proveedores.Name = "tabla_proveedores";
            this.tabla_proveedores.RowHeadersVisible = false;
            this.tabla_proveedores.Size = new System.Drawing.Size(712, 277);
            this.tabla_proveedores.TabIndex = 6;
            this.tabla_proveedores.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.tabla_proveedores_CellBeginEdit);
            this.tabla_proveedores.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_proveedores_CellEndEdit);
            this.tabla_proveedores.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tabla_proveedores_ColumnHeaderMouseClick);
            // 
            // idpro_pro
            // 
            this.idpro_pro.DataPropertyName = "idproveedor_producto";
            this.idpro_pro.HeaderText = "id_proveedor_producto";
            this.idpro_pro.Name = "idpro_pro";
            this.idpro_pro.Visible = false;
            // 
            // idprovee
            // 
            this.idprovee.DataPropertyName = "idproveedor";
            this.idprovee.HeaderText = "idprov";
            this.idprovee.Name = "idprovee";
            this.idprovee.Visible = false;
            // 
            // prove
            // 
            this.prove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.prove.HeaderText = "Proveedor";
            this.prove.Name = "prove";
            // 
            // idpro
            // 
            this.idpro.DataPropertyName = "idproducto";
            this.idpro.HeaderText = "idpro";
            this.idpro.Name = "idpro";
            this.idpro.Visible = false;
            // 
            // proveedores_por_producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 323);
            this.Controls.Add(this.tabla_proveedores);
            this.Controls.Add(this.panelTitulo);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "proveedores_por_producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "proveedores_por_producto";
            this.Load += new System.EventHandler(this.proveedores_por_producto_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_proveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.PictureBox btnAgregar;
        private System.Windows.Forms.PictureBox cerrar;
        public System.Windows.Forms.Label lblEncanezado;
        private System.Windows.Forms.DataGridView tabla_proveedores;
        private System.Windows.Forms.PictureBox btnEliminar;
        private System.Windows.Forms.PictureBox btnAgrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpro_pro;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprovee;
        private System.Windows.Forms.DataGridViewComboBoxColumn prove;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpro;
    }
}