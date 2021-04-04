namespace interfaces.compras
{
    partial class busqueda_compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(busqueda_compras));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.cerrar = new System.Windows.Forms.PictureBox();
            this.lblEncanezado = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBusquedaNumero = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBusquedaP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fecha_actual = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabla_compras = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_i = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anulacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_compras)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(102)))), ((int)(((byte)(149)))));
            this.panelTitulo.Controls.Add(this.cerrar);
            this.panelTitulo.Controls.Add(this.lblEncanezado);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(841, 46);
            this.panelTitulo.TabIndex = 7;
            this.panelTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitulo_MouseDown);
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrar.Image = ((System.Drawing.Image)(resources.GetObject("cerrar.Image")));
            this.cerrar.Location = new System.Drawing.Point(794, 6);
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
            this.lblEncanezado.Location = new System.Drawing.Point(266, 15);
            this.lblEncanezado.Name = "lblEncanezado";
            this.lblEncanezado.Size = new System.Drawing.Size(172, 23);
            this.lblEncanezado.TabIndex = 0;
            this.lblEncanezado.Text = "Compras realizadas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 299);
            this.panel1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBusquedaNumero);
            this.groupBox3.Location = new System.Drawing.Point(12, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Busqueda por número de documento";
            // 
            // txtBusquedaNumero
            // 
            this.txtBusquedaNumero.Location = new System.Drawing.Point(7, 25);
            this.txtBusquedaNumero.Name = "txtBusquedaNumero";
            this.txtBusquedaNumero.Size = new System.Drawing.Size(278, 26);
            this.txtBusquedaNumero.TabIndex = 1;
            this.txtBusquedaNumero.TextChanged += new System.EventHandler(this.txtBusquedaNumero_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBusquedaP);
            this.groupBox2.Location = new System.Drawing.Point(12, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 66);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda por proveedor";
            // 
            // txtBusquedaP
            // 
            this.txtBusquedaP.Location = new System.Drawing.Point(7, 26);
            this.txtBusquedaP.Name = "txtBusquedaP";
            this.txtBusquedaP.Size = new System.Drawing.Size(278, 26);
            this.txtBusquedaP.TabIndex = 0;
            this.txtBusquedaP.TextChanged += new System.EventHandler(this.txtBusquedaP_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fecha_actual);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda por fecha";
            // 
            // fecha_actual
            // 
            this.fecha_actual.Location = new System.Drawing.Point(6, 25);
            this.fecha_actual.Name = "fecha_actual";
            this.fecha_actual.Size = new System.Drawing.Size(279, 26);
            this.fecha_actual.TabIndex = 0;
            this.fecha_actual.ValueChanged += new System.EventHandler(this.fecha_actual_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabla_compras);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(316, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 299);
            this.panel2.TabIndex = 9;
            // 
            // tabla_compras
            // 
            this.tabla_compras.AllowUserToAddRows = false;
            this.tabla_compras.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabla_compras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tabla_compras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabla_compras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tabla_compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_compras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.numero_factura,
            this.nomb,
            this.fecha_i,
            this.anulacion,
            this.idcaja,
            this.tipo_factura,
            this.nombre,
            this.monto,
            this.iva,
            this.toa,
            this.fecha,
            this.idpro});
            this.tabla_compras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabla_compras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabla_compras.Location = new System.Drawing.Point(0, 0);
            this.tabla_compras.MultiSelect = false;
            this.tabla_compras.Name = "tabla_compras";
            this.tabla_compras.ReadOnly = true;
            this.tabla_compras.RowHeadersVisible = false;
            this.tabla_compras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_compras.Size = new System.Drawing.Size(525, 299);
            this.tabla_compras.TabIndex = 0;
            this.tabla_compras.DoubleClick += new System.EventHandler(this.tabla_compras_DoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // numero_factura
            // 
            this.numero_factura.DataPropertyName = "numero_factura";
            this.numero_factura.HeaderText = "Número de factura";
            this.numero_factura.Name = "numero_factura";
            this.numero_factura.ReadOnly = true;
            // 
            // nomb
            // 
            this.nomb.DataPropertyName = "nombre_proveedor";
            this.nomb.HeaderText = "Nombre del proveedor";
            this.nomb.Name = "nomb";
            this.nomb.ReadOnly = true;
            this.nomb.Width = 200;
            // 
            // fecha_i
            // 
            this.fecha_i.DataPropertyName = "fecha_ingreso";
            this.fecha_i.HeaderText = "Fecha ingreso";
            this.fecha_i.Name = "fecha_i";
            this.fecha_i.ReadOnly = true;
            this.fecha_i.Visible = false;
            // 
            // anulacion
            // 
            this.anulacion.DataPropertyName = "anulacion";
            this.anulacion.HeaderText = "Anulación";
            this.anulacion.Name = "anulacion";
            this.anulacion.ReadOnly = true;
            this.anulacion.Visible = false;
            // 
            // idcaja
            // 
            this.idcaja.DataPropertyName = "idcaja";
            this.idcaja.HeaderText = "Idcaja";
            this.idcaja.Name = "idcaja";
            this.idcaja.ReadOnly = true;
            this.idcaja.Visible = false;
            // 
            // tipo_factura
            // 
            this.tipo_factura.DataPropertyName = "idtipofactura";
            this.tipo_factura.HeaderText = "tipo_factura";
            this.tipo_factura.Name = "tipo_factura";
            this.tipo_factura.ReadOnly = true;
            this.tipo_factura.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Tipo de factura";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 150;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "subtotal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.monto.DefaultCellStyle = dataGridViewCellStyle3;
            this.monto.HeaderText = "Subtotal";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Width = 80;
            // 
            // iva
            // 
            this.iva.DataPropertyName = "iva";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.iva.DefaultCellStyle = dataGridViewCellStyle4;
            this.iva.HeaderText = "IVA";
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            this.iva.Width = 80;
            // 
            // toa
            // 
            this.toa.DataPropertyName = "total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.toa.DefaultCellStyle = dataGridViewCellStyle5;
            this.toa.HeaderText = "Total Neto";
            this.toa.Name = "toa";
            this.toa.ReadOnly = true;
            this.toa.Width = 80;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha_factura";
            this.fecha.HeaderText = "Fecha de factura";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 150;
            // 
            // idpro
            // 
            this.idpro.DataPropertyName = "idproveedor";
            this.idpro.HeaderText = "Idproveedor";
            this.idpro.Name = "idpro";
            this.idpro.ReadOnly = true;
            this.idpro.Visible = false;
            // 
            // busqueda_compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 345);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitulo);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "busqueda_compras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "busqueda_compras";
            this.Load += new System.EventHandler(this.busqueda_compras_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_compras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.PictureBox cerrar;
        private System.Windows.Forms.Label lblEncanezado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBusquedaNumero;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBusquedaP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker fecha_actual;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tabla_compras;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomb;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_i;
        private System.Windows.Forms.DataGridViewTextBoxColumn anulacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn toa;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpro;
    }
}