namespace interfaces.productos
{
    partial class modificacion_de_productos_en_tabla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modificacion_de_productos_en_tabla));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.imgServidor = new System.Windows.Forms.PictureBox();
            this.cerrar = new System.Windows.Forms.PictureBox();
            this.lblEncanezado = new System.Windows.Forms.Label();
            this.grpBuscar = new System.Windows.Forms.GroupBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.tabla_productos = new System.Windows.Forms.DataGridView();
            this.idpro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idsuc_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porceM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.preciVM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porceD = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.preciD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cprese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.estante = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.kardex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nproveedores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idestante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kardes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitulo.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgServidor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).BeginInit();
            this.grpBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_productos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTitulo.Controls.Add(this.toolStrip1);
            this.panelTitulo.Controls.Add(this.imgServidor);
            this.panelTitulo.Controls.Add(this.cerrar);
            this.panelTitulo.Controls.Add(this.lblEncanezado);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1604, 69);
            this.panelTitulo.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 44);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1604, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::interfaces.Properties.Resources.add;
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(177, 23);
            this.btnAgregar.Text = "Agregar nuevo producto";
            this.btnAgregar.Visible = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // imgServidor
            // 
            this.imgServidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgServidor.Image = global::interfaces.Properties.Resources.servidor;
            this.imgServidor.Location = new System.Drawing.Point(12, 9);
            this.imgServidor.Name = "imgServidor";
            this.imgServidor.Size = new System.Drawing.Size(32, 32);
            this.imgServidor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgServidor.TabIndex = 3;
            this.imgServidor.TabStop = false;
            this.imgServidor.Visible = false;
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrar.Image = ((System.Drawing.Image)(resources.GetObject("cerrar.Image")));
            this.cerrar.Location = new System.Drawing.Point(1560, 9);
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
            this.lblEncanezado.Location = new System.Drawing.Point(596, 9);
            this.lblEncanezado.Name = "lblEncanezado";
            this.lblEncanezado.Size = new System.Drawing.Size(181, 23);
            this.lblEncanezado.TabIndex = 0;
            this.lblEncanezado.Text = "Modificar productos";
            // 
            // grpBuscar
            // 
            this.grpBuscar.Controls.Add(this.txtBusqueda);
            this.grpBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBuscar.Location = new System.Drawing.Point(0, 69);
            this.grpBuscar.Name = "grpBuscar";
            this.grpBuscar.Size = new System.Drawing.Size(1604, 70);
            this.grpBuscar.TabIndex = 3;
            this.grpBuscar.TabStop = false;
            this.grpBuscar.Text = "Busquedas";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBusqueda.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(3, 22);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(1598, 35);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // tabla_productos
            // 
            this.tabla_productos.AllowUserToAddRows = false;
            this.tabla_productos.AllowUserToDeleteRows = false;
            this.tabla_productos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabla_productos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabla_productos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tabla_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpro,
            this.idsuc_pro,
            this.codi,
            this.nombre,
            this.conUM,
            this.porceM,
            this.preciVM,
            this.costoUD,
            this.porceD,
            this.preciD,
            this.cprese,
            this.exist,
            this.marca,
            this.categoria,
            this.estante,
            this.kardex,
            this.fecha,
            this.estado,
            this.nproveedores,
            this.idum,
            this.idud,
            this.idmarca,
            this.idcategoria,
            this.idestante,
            this.kardes,
            this.esta});
            this.tabla_productos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabla_productos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.tabla_productos.Location = new System.Drawing.Point(0, 139);
            this.tabla_productos.MultiSelect = false;
            this.tabla_productos.Name = "tabla_productos";
            this.tabla_productos.RowHeadersVisible = false;
            this.tabla_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_productos.Size = new System.Drawing.Size(1604, 308);
            this.tabla_productos.TabIndex = 4;
            this.tabla_productos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.tabla_productos_CellBeginEdit);
            this.tabla_productos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_productos_CellClick);
            this.tabla_productos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_productos_CellContentClick);
            this.tabla_productos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_productos_CellDoubleClick);
            this.tabla_productos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_productos_CellEndEdit);
            this.tabla_productos.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_productos_CellMouseEnter);
            this.tabla_productos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_productos_CellValueChanged);
            this.tabla_productos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tabla_productos_ColumnHeaderMouseClick);
            this.tabla_productos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // idpro
            // 
            this.idpro.DataPropertyName = "idproducto";
            this.idpro.HeaderText = "idpro";
            this.idpro.Name = "idpro";
            this.idpro.Visible = false;
            // 
            // idsuc_pro
            // 
            this.idsuc_pro.DataPropertyName = "idsp";
            this.idsuc_pro.HeaderText = "idsuc_pro";
            this.idsuc_pro.Name = "idsuc_pro";
            this.idsuc_pro.Visible = false;
            // 
            // codi
            // 
            this.codi.DataPropertyName = "codigo";
            this.codi.HeaderText = "Codigo";
            this.codi.Name = "codi";
            this.codi.ReadOnly = true;
            this.codi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codi.Width = 150;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre del producto";
            this.nombre.Name = "nombre";
            this.nombre.Width = 550;
            // 
            // conUM
            // 
            this.conUM.DataPropertyName = "precio_compraM";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.conUM.DefaultCellStyle = dataGridViewCellStyle3;
            this.conUM.HeaderText = "Costo unitario M";
            this.conUM.Name = "conUM";
            this.conUM.Width = 75;
            // 
            // porceM
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porceM.DefaultCellStyle = dataGridViewCellStyle4;
            this.porceM.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.porceM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.porceM.HeaderText = "Utilidad mayoreo";
            this.porceM.Name = "porceM";
            this.porceM.Width = 60;
            // 
            // preciVM
            // 
            this.preciVM.DataPropertyName = "precio_ventaM";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.preciVM.DefaultCellStyle = dataGridViewCellStyle5;
            this.preciVM.HeaderText = "Precio venta mayoreo";
            this.preciVM.Name = "preciVM";
            this.preciVM.Width = 80;
            // 
            // costoUD
            // 
            this.costoUD.DataPropertyName = "precio_compra";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.costoUD.DefaultCellStyle = dataGridViewCellStyle6;
            this.costoUD.HeaderText = "Costo unitario D";
            this.costoUD.Name = "costoUD";
            this.costoUD.Width = 75;
            // 
            // porceD
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.porceD.DefaultCellStyle = dataGridViewCellStyle7;
            this.porceD.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.porceD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.porceD.HeaderText = "Utilidad detalle";
            this.porceD.Name = "porceD";
            this.porceD.Width = 60;
            // 
            // preciD
            // 
            this.preciD.DataPropertyName = "precio_venta";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.preciD.DefaultCellStyle = dataGridViewCellStyle8;
            this.preciD.HeaderText = "Precio venta detalle";
            this.preciD.Name = "preciD";
            this.preciD.Width = 80;
            // 
            // cprese
            // 
            this.cprese.DataPropertyName = "cantipre";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cprese.DefaultCellStyle = dataGridViewCellStyle9;
            this.cprese.HeaderText = "N° presentaciones";
            this.cprese.Name = "cprese";
            this.cprese.ReadOnly = true;
            // 
            // exist
            // 
            this.exist.DataPropertyName = "existencias";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.exist.DefaultCellStyle = dataGridViewCellStyle10;
            this.exist.HeaderText = "Existencias";
            this.exist.Name = "exist";
            this.exist.ReadOnly = true;
            // 
            // marca
            // 
            this.marca.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.marca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.Width = 150;
            // 
            // categoria
            // 
            this.categoria.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.categoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.categoria.HeaderText = "Categoria";
            this.categoria.Name = "categoria";
            this.categoria.Width = 200;
            // 
            // estante
            // 
            this.estante.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.estante.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.estante.HeaderText = "Estante";
            this.estante.Name = "estante";
            this.estante.Width = 150;
            // 
            // kardex
            // 
            this.kardex.HeaderText = "Kardex";
            this.kardex.Name = "kardex";
            this.kardex.Width = 60;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha_ingreso";
            this.fecha.HeaderText = "Fecha de ingreso";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.Width = 60;
            // 
            // nproveedores
            // 
            this.nproveedores.DataPropertyName = "num_provedores";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nproveedores.DefaultCellStyle = dataGridViewCellStyle11;
            this.nproveedores.HeaderText = "N° de proveedores";
            this.nproveedores.Name = "nproveedores";
            this.nproveedores.ReadOnly = true;
            this.nproveedores.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // idum
            // 
            this.idum.DataPropertyName = "idum";
            this.idum.HeaderText = "idutilidadmayoreo";
            this.idum.Name = "idum";
            this.idum.Visible = false;
            // 
            // idud
            // 
            this.idud.DataPropertyName = "idud";
            this.idud.HeaderText = "idutilidaddetalle";
            this.idud.Name = "idud";
            this.idud.Visible = false;
            // 
            // idmarca
            // 
            this.idmarca.DataPropertyName = "idmarca";
            this.idmarca.HeaderText = "Idmarca";
            this.idmarca.Name = "idmarca";
            this.idmarca.Visible = false;
            // 
            // idcategoria
            // 
            this.idcategoria.DataPropertyName = "idcategoria";
            this.idcategoria.HeaderText = "Idcategoria";
            this.idcategoria.Name = "idcategoria";
            this.idcategoria.Visible = false;
            // 
            // idestante
            // 
            this.idestante.DataPropertyName = "idestante";
            this.idestante.HeaderText = "Idestante";
            this.idestante.Name = "idestante";
            this.idestante.Visible = false;
            // 
            // kardes
            // 
            this.kardes.DataPropertyName = "kardex";
            this.kardes.HeaderText = "kardes";
            this.kardes.Name = "kardes";
            this.kardes.Visible = false;
            // 
            // esta
            // 
            this.esta.DataPropertyName = "estado";
            this.esta.HeaderText = "esta";
            this.esta.Name = "esta";
            this.esta.Visible = false;
            // 
            // modificacion_de_productos_en_tabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 447);
            this.Controls.Add(this.tabla_productos);
            this.Controls.Add(this.grpBuscar);
            this.Controls.Add(this.panelTitulo);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "modificacion_de_productos_en_tabla";
            this.Text = "modificacion_de_productos_en_tabla";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.modificacion_de_productos_en_tabla_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgServidor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).EndInit();
            this.grpBuscar.ResumeLayout(false);
            this.grpBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_productos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.PictureBox imgServidor;
        private System.Windows.Forms.PictureBox cerrar;
        public System.Windows.Forms.Label lblEncanezado;
        private System.Windows.Forms.GroupBox grpBuscar;
        private System.Windows.Forms.DataGridView tabla_productos;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpro;
        private System.Windows.Forms.DataGridViewTextBoxColumn idsuc_pro;
        private System.Windows.Forms.DataGridViewTextBoxColumn codi;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn conUM;
        private System.Windows.Forms.DataGridViewComboBoxColumn porceM;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciVM;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUD;
        private System.Windows.Forms.DataGridViewComboBoxColumn porceD;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciD;
        private System.Windows.Forms.DataGridViewTextBoxColumn cprese;
        private System.Windows.Forms.DataGridViewTextBoxColumn exist;
        private System.Windows.Forms.DataGridViewComboBoxColumn marca;
        private System.Windows.Forms.DataGridViewComboBoxColumn categoria;
        private System.Windows.Forms.DataGridViewComboBoxColumn estante;
        private System.Windows.Forms.DataGridViewCheckBoxColumn kardex;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nproveedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn idum;
        private System.Windows.Forms.DataGridViewTextBoxColumn idud;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestante;
        private System.Windows.Forms.DataGridViewTextBoxColumn kardes;
        private System.Windows.Forms.DataGridViewTextBoxColumn esta;
    }
}