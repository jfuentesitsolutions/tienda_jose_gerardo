namespace interfaces.paneles
{
    partial class reporteria
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
            this.panelOpciones = new System.Windows.Forms.FlowLayoutPanel();
            this.repoProductos = new System.Windows.Forms.Panel();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panelOpciones.SuspendLayout();
            this.repoProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOpciones
            // 
            this.panelOpciones.Controls.Add(this.repoProductos);
            this.panelOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOpciones.Location = new System.Drawing.Point(0, 0);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(770, 658);
            this.panelOpciones.TabIndex = 1;
            // 
            // repoProductos
            // 
            this.repoProductos.Controls.Add(this.btnProductos);
            this.repoProductos.Location = new System.Drawing.Point(10, 10);
            this.repoProductos.Margin = new System.Windows.Forms.Padding(10);
            this.repoProductos.Name = "repoProductos";
            this.repoProductos.Size = new System.Drawing.Size(159, 170);
            this.repoProductos.TabIndex = 0;
            this.repoProductos.Visible = false;
            // 
            // btnProductos
            // 
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Image = global::interfaces.Properties.Resources.health_check__1_;
            this.btnProductos.Location = new System.Drawing.Point(0, 0);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(20);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(159, 170);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Reporte de productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // reporteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 658);
            this.Controls.Add(this.panelOpciones);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "reporteria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reporteria";
            this.Load += new System.EventHandler(this.reporteria_Load);
            this.panelOpciones.ResumeLayout(false);
            this.repoProductos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelOpciones;
        private System.Windows.Forms.Panel repoProductos;
        private System.Windows.Forms.Button btnProductos;
    }
}