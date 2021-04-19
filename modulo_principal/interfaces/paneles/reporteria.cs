using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.paneles
{
    public partial class reporteria : Form
    {
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        public reporteria()
        {
            InitializeComponent();
        }

        private void reporteria_Load(object sender, EventArgs e)
        {
            control_permisos.controlador_de_permisos per = new control_permisos.controlador_de_permisos(this.panelOpciones, conexiones_BD.clases.usuarios.permisosAsigandosReporte(sesion.Datos[5]));
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Reportes.Interfaz.reporte_productos repo = new Reportes.Interfaz.reporte_productos();
            repo.ShowDialog();
        }
    }
}
