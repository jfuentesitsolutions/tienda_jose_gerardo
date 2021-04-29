using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.ventas.auxiliares
{
    public partial class validacion_autorizacion : Form
    {
        bool valido = false;
        public validacion_autorizacion()
        {
            InitializeComponent();
        }

        public bool Valido { get => valido; set => valido = value; }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (conexiones_BD.clases.usuarios.validacion_precios(txtContra.Text))
                {
                    this.valido = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContra.Text = "";
                    txtContra.Focus();
                }
            }     
        }
    }
}
