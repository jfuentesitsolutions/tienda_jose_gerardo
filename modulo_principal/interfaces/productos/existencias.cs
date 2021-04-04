using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.productos
{
    public partial class existencias : Form
    {
        private bool conexion_remota = false;
        private string idsuc;
        private string cantidad;
        conexiones_BD.clases.presentaciones_productos pp;
        public existencias()
        {
            InitializeComponent();
        }

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }
        public string Idsuc { get => idsuc; set => idsuc = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void existencias_Load(object sender, EventArgs e)
        {
            pp = new conexiones_BD.clases.presentaciones_productos();
            pp.Idsucursal_producto = idsuc;
            colocandoDatos();
        }

        private DataTable datos()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;

            return op.Consultar(pp.presentaciones_productos_asce());
        }

        private void colocandoDatos()
        {
            DataTable dato = datos();
            Int32 cant = Convert.ToInt32(cantidad);
            int modu = 0;
            int aux = 0;
            int total = 0;

            if (dato.Rows.Count != 0)
            {
                foreach(DataRow fila in dato.Rows)
                {
                    if (aux == 0)
                    {
                        int canti = (int)fila[1];
                        total = ((int)cant / canti);
                        modu = ((int)cant % canti);
                        aux++;
                        tabla_existencias.Rows.Add(fila[0] + "x" + fila[1], total);
                    }
                    else
                    {
                        int canti = (int)fila[1];
                        total = ((int)modu / canti);
                        modu = ((int)modu % canti);

                        tabla_existencias.Rows.Add(fila[0] + "x" + fila[1], total);
                    }        
                }
            }
        }
    }
}
