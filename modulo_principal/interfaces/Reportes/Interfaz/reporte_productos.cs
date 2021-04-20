using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.Reportes.Interfaz
{
    public partial class reporte_productos : Form
    {
        DataSet datos = new DataSet();
        DataTable dato1, dato2, dato3;
        public reporte_productos()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void reporte_productos_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            cargar_reporte();   
        }


        private void cargar_reporte()
        {
            dato1 = conexiones_BD.clases.productos.PRODUCTOS_REPORTE_INVENTARIO(false);
            dato2 = conexiones_BD.clases.codigos.CODIGOS_REPORTE_INVENTARIO(false);
            dato3 = conexiones_BD.clases.presentaciones_productos.PRESENTACIONES_INVENTARIO(false);

            datos.Tables.Add(dato1);
            datos.Tables.Add(dato2);
            datos.Tables.Add(dato3);

            Diseño.productos_inventario repo = new Diseño.productos_inventario();
            repo.SetDataSource(datos);

            repo.Database.Tables["reporte_inventario_productos"].SetDataSource(datos.Tables[0]);
            repo.Subreports[0].Database.Tables["codigos_producto"].SetDataSource(datos.Tables[1]);
            repo.Subreports[1].Database.Tables["reporte_presentaciones"].SetDataSource(datos.Tables[2]);
            
   
            reporte.ReportSource = repo;
        }
       
    }
}
