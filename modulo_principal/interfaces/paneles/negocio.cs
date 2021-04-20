using Microsoft.Win32;
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
    public partial class negocio : Form
    {
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        bool conexion_remota = false;
        public negocio()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mantenimientos.procesos_iniciales.agregaPresentaciones ap = new mantenimientos.procesos_iniciales.agregaPresentaciones();
            ap.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        { 

            /*if (MessageBox.Show("¿Deseas conectarte a la base de datos remota?", "Base de datos remota", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con = new conexiones_BD.Conexion();
                if (con.probando_conexion())
                {
                    string ipremoto = (string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "ipremoto", "NE");
                    if (!ipremoto.Equals("NE"))
                    {
                        conexion_remota = true;
                        productos.modificacion_de_productos_en_tabla man = new productos.modificacion_de_productos_en_tabla();
                        man.Conexion_remota = conexion_remota;
                        man.ShowDialog();
                        conexion_remota = false;
                    }
                    else
                    {
                        MessageBox.Show("No se encuentra la dirección del servidor\nen el registro", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No existe conexión al servidor", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexion_remota = false;
                }
            }
            else
            {*/
                productos.modificacion_de_productos_en_tabla man = new productos.modificacion_de_productos_en_tabla();
                man.Conexion_remota = conexion_remota;
                man.ShowDialog();
                conexion_remota = false;
            /*}
            
            using (espera_datos.splash_espera fe = new espera_datos.splash_espera())
            {             
                fe.Funcion_recargar = cargarDatos;
                fe.Tipo_operacion = 1;
               
                if (fe.ShowDialog() == DialogResult.OK)
                {
                    productos.precios_productos cp = new productos.precios_productos();
                    cp.Productos = fe.Datos;
                    cp.Conexion_remota = this.conexion_remota;
                    cp.ShowDialog();
                    conexion_remota = false;
                }
                else
                {
                    MessageBox.Show("La carga de productos a sido cancelada...");
                    conexion_remota = false;
                }
            }  */

            

            
        }

        private DataTable cargarDatos()
        {
            DataTable datos = new DataTable();
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            if (op.probarConexion2())
            {
                datos = conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_VENT(conexion_remota);
            }
            else
            {
                MessageBox.Show("No hay conexión con el servidor", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }

        private void btnAgregaPresentaciones_Click(object sender, EventArgs e)
        {
            if (sesion.Caja_activa)
            {
                ventas.ventas venta = new ventas.ventas();
                venta.ShowDialog();
            }else
            {
                MessageBox.Show("No hay caja abierta", "Caja cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //conexiones_BD.clases.ventas.tickets ticke = new conexiones_BD.clases.ventas.tickets(
            //    "1", "2", "2018-06-15", "5", "1", "1", "12", "3", "12.3", "0", "12", "1");

            //List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket> dep = new List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket>();
            //conexiones_BD.clases.ventas.detalles_productos_venta_ticket dp = new conexiones_BD.clases.ventas.detalles_productos_venta_ticket(
            //    "0", "21", "3", "1.50", "3", "0.15", "0");

            //dep.Add(dp);

            //conexiones_BD.operaciones op = new conexiones_BD.operaciones();

            //if (op.transaccionVentasTickets(dep, ticke) > 0)
            //{
            //    MessageBox.Show("Funciono");
            //}
            //else
            //{
            //    MessageBox.Show("No funciono");
            //}

            compras.compras_de_productos frm = new compras.compras_de_productos();
            frm.ShowDialog();

        }

        private void negocio_Load(object sender, EventArgs e)
        {
           control_permisos.controlador_de_permisos per = new control_permisos.controlador_de_permisos(this.panelOpciones, conexiones_BD.clases.usuarios.permisosAsigandosNegocio(sesion.Datos[5]));
        }

        private void btnAnulaCompra_Click(object sender, EventArgs e)
        {
            /*compras.anular_compra frm = new compras.anular_compra();
            frm.ShowDialog();*/

            conexiones_BD.Conexion con = new conexiones_BD.Conexion();
            if (con.conectar_remota())
            {
                MessageBox.Show("Conexión exitosa");
                con.desconectar();
            }
            else
            {
                MessageBox.Show("No existe conexion al servidor");
            }
        }

        private void btnTraslado_Click(object sender, EventArgs e)
        {
            traslados.traslados_productos frm = new traslados.traslados_productos();
            frm.ShowDialog();
        }

        private void btnGestion_cajas_Click(object sender, EventArgs e)
        {
            cajas_efectivo.Imagenes gestion_caja = new cajas_efectivo.Imagenes();
            gestion_caja.ShowDialog();
        }
    }
}
