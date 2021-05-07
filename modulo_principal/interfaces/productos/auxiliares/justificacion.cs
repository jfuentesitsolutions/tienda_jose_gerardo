using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.productos.auxiliares
{
    public partial class justificacion : Form
    {
        public justificacion()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
                DialogResult = DialogResult.No;
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtJustificacion.TextLength != 0)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }
    }
}
