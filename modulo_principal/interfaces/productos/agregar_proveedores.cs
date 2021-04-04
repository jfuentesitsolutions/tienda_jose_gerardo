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
    public partial class agregar_proveedores : Form
    {
        private bool conexion_remota = false;
        utilitarios.cargar_tablas tabla;
        private string idproducto;
        public agregar_proveedores()
        {
            InitializeComponent();
        }

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }
        public string Idproducto { get => idproducto; set => idproducto = value; }

        private void agregar_proveedores_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);

            using(espera_datos.splash_espera es= new espera_datos.splash_espera())
            {
                es.Funcion_recargar = cargandoDatos;
                es.Tipo_operacion = 1;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    tabla = new utilitarios.cargar_tablas(tabla_proveedores, txtBusqueda, es.Datos, "nombre_proveedor");
                    tabla.cargarSinContadorRegistros();
                }
            }
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

        private DataTable cargandoDatos()
        {
            DataTable datos= conexiones_BD.clases.proveedores.datosTabla(conexion_remota);
            return datos;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            tabla.FiltrarLocalmenteSinContadorRegistros();
        }

        private void tabla_proveedores_DoubleClick(object sender, EventArgs e)
        {
            if (tabla_proveedores.Rows.Count != 0)
            {
                if (MessageBox.Show("¿Desea agregar otro proveedor al producto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using(espera_datos.splash_espera es=new espera_datos.splash_espera())
                    {
                        es.Funcion_sentencia = guardandoProveedor;
                        es.Tipo_operacion = 2;
                        if (es.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo ingresar el nuevo proveedor\n revise la conexión al base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private int guardandoProveedor()
        {
            conexiones_BD.clases.proveedores_productos pp = new conexiones_BD.clases.proveedores_productos(
                tabla_proveedores.CurrentRow.Cells[0].Value.ToString(),
                idproducto);
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return (int)op.insertar(pp.sentenciaIngresar());
        }
        
    }
}
