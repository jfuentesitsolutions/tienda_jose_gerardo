namespace interfaces.productos
{
    partial class presentaciones_por_producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(presentaciones_por_producto));
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.PictureBox();
            this.cerrar = new System.Windows.Forms.PictureBox();
            this.lblEncanezado = new System.Windows.Forms.Label();
            this.tabla_presentaciones = new System.Windows.Forms.DataGridView();
            this.idpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.canti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tip = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.prio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.esta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.es = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_presentaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTitulo.Controls.Add(this.btnEliminar);
            this.panelTitulo.Controls.Add(this.btnAgregar);
            this.panelTitulo.Controls.Add(this.cerrar);
            this.panelTitulo.Controls.Add(this.lblEncanezado);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(793, 46);
            this.panelTitulo.TabIndex = 4;
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
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Image = global::interfaces.Properties.Resources.plus_2;
            this.btnAgregar.Location = new System.Drawing.Point(12, 8);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(32, 32);
            this.btnAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrar.Image = ((System.Drawing.Image)(resources.GetObject("cerrar.Image")));
            this.cerrar.Location = new System.Drawing.Point(758, 8);
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
            this.lblEncanezado.Location = new System.Drawing.Point(272, 15);
            this.lblEncanezado.Name = "lblEncanezado";
            this.lblEncanezado.Size = new System.Drawing.Size(237, 23);
            this.lblEncanezado.TabIndex = 0;
            this.lblEncanezado.Text = "Presentaciones de producto";
            // 
            // tabla_presentaciones
            // 
            this.tabla_presentaciones.AllowUserToAddRows = false;
            this.tabla_presentaciones.AllowUserToDeleteRows = false;
            this.tabla_presentaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_presentaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpp,
            this.idpr,
            this.nom,
            this.canti,
            this.pre,
            this.tip,
            this.prio,
            this.esta,
            this.tipo,
            this.prioe,
            this.es});
            this.tabla_presentaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabla_presentaciones.Location = new System.Drawing.Point(0, 46);
            this.tabla_presentaciones.Name = "tabla_presentaciones";
            this.tabla_presentaciones.RowHeadersVisible = false;
            this.tabla_presentaciones.Size = new System.Drawing.Size(793, 310);
            this.tabla_presentaciones.TabIndex = 5;
            this.tabla_presentaciones.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.tabla_presentaciones_CellBeginEdit);
            this.tabla_presentaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_presentaciones_CellContentClick);
            this.tabla_presentaciones.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_presentaciones_CellEndEdit);
            this.tabla_presentaciones.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tabla_presentaciones_ColumnHeaderMouseClick);
            this.tabla_presentaciones.CurrentCellDirtyStateChanged += new System.EventHandler(this.tabla_presentaciones_CurrentCellDirtyStateChanged);
            this.tabla_presentaciones.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tabla_presentaciones_DataError);
            // 
            // idpp
            // 
            this.idpp.DataPropertyName = "idpresentacion_producto";
            this.idpp.HeaderText = "idpre_pro";
            this.idpp.Name = "idpp";
            this.idpp.Visible = false;
            // 
            // idpr
            // 
            this.idpr.DataPropertyName = "idpresentacion";
            this.idpr.HeaderText = "idpre";
            this.idpr.Name = "idpr";
            this.idpr.Visible = false;
            // 
            // nom
            // 
            this.nom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nom.HeaderText = "Presentación";
            this.nom.Name = "nom";
            this.nom.Width = 230;
            // 
            // canti
            // 
            this.canti.DataPropertyName = "cantidad_unidades";
            this.canti.HeaderText = "Cantidad interna";
            this.canti.Name = "canti";
            this.canti.Width = 80;
            // 
            // pre
            // 
            this.pre.DataPropertyName = "precio";
            this.pre.HeaderText = "Precio";
            this.pre.Name = "pre";
            // 
            // tip
            // 
            this.tip.DataPropertyName = "tip";
            this.tip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tip.HeaderText = "Tipo";
            this.tip.Name = "tip";
            this.tip.Width = 150;
            // 
            // prio
            // 
            this.prio.HeaderText = "Prioridad";
            this.prio.Name = "prio";
            // 
            // esta
            // 
            this.esta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.esta.HeaderText = "Estado";
            this.esta.Name = "esta";
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "Tipo_a";
            this.tipo.Name = "tipo";
            this.tipo.Visible = false;
            // 
            // prioe
            // 
            this.prioe.DataPropertyName = "prioridad";
            this.prioe.HeaderText = "p";
            this.prioe.Name = "prioe";
            this.prioe.Visible = false;
            // 
            // es
            // 
            this.es.DataPropertyName = "estado";
            this.es.HeaderText = "esta";
            this.es.Name = "es";
            this.es.Visible = false;
            // 
            // presentaciones_por_producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 356);
            this.Controls.Add(this.tabla_presentaciones);
            this.Controls.Add(this.panelTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "presentaciones_por_producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "presentaciones_por_producto";
            this.Load += new System.EventHandler(this.presentaciones_por_producto_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_presentaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.PictureBox cerrar;
        public System.Windows.Forms.Label lblEncanezado;
        private System.Windows.Forms.DataGridView tabla_presentaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpr;
        private System.Windows.Forms.DataGridViewComboBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn canti;
        private System.Windows.Forms.DataGridViewTextBoxColumn pre;
        private System.Windows.Forms.DataGridViewComboBoxColumn tip;
        private System.Windows.Forms.DataGridViewCheckBoxColumn prio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn esta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioe;
        private System.Windows.Forms.DataGridViewTextBoxColumn es;
        private System.Windows.Forms.PictureBox btnAgregar;
        private System.Windows.Forms.PictureBox btnEliminar;
    }
}