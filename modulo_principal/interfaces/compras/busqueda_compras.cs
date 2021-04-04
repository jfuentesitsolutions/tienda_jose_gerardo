using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.compras
{
    public partial class busqueda_compras : Form
    {
        utilitarios.cargar_tablas tabla;
        public busqueda_compras()
        {
            InitializeComponent();
        }

        private void busqueda_compras_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            cargarTabla();
        }

        private void cargarTabla()
        {
            tabla = new utilitarios.cargar_tablas(tabla_compras, txtBusquedaP, conexiones_BD.clases.compras.compras.factura_ingresadas(fecha_actual.Value.ToString("yyyy-MM-dd")), "nombre_proveedor");
            tabla.cargarSinContadorRegistros();
        }

        private void txtBusquedaP_TextChanged(object sender, EventArgs e)
        {
            tabla.Busqueda = txtBusquedaP;
            tabla.CampoAfiltrar = "nombre_proveedor";
            tabla.FiltrarLocalmenteSinContadorRegistros();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusquedaNumero_TextChanged(object sender, EventArgs e)
        {
            tabla.Busqueda = txtBusquedaNumero;
            tabla.CampoAfiltrar = "numero_factura";
            tabla.FiltrarLocalmenteSinContadorRegistros();
        }

        private void fecha_actual_ValueChanged(object sender, EventArgs e)
        {
            tabla.TablaDatos = conexiones_BD.clases.compras.compras.factura_ingresadas(fecha_actual.Value.ToString("yyyy-MM-dd"));
            tabla.cargarSinContadorRegistros();
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void tabla_compras_DoubleClick(object sender, EventArgs e)
        {
            if (tabla_compras.Rows.Count != 0)
            {

            }
        }
    }
}
