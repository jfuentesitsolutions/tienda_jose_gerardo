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
    public partial class agregar_presentacion : Form
    {
        private bool conexion_remota = false;
        private DataTable datos_presentaciones;
        private string nombre_productos;
        private string idsuc_producto;
        conexiones_BD.clases.presentaciones_productos pp;

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }
        public DataTable Datos_presentaciones { get => datos_presentaciones; set => datos_presentaciones = value; }
        public string Nombre_productos { get => nombre_productos; set => nombre_productos = value; }
        public string Idsuc_producto { get => idsuc_producto; set => idsuc_producto = value; }

        public agregar_presentacion()
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

        private void agregar_presentacion_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            utilitarios.cargandoListas.cargarLista(datos_presentaciones, lista_presentaciones, "nombre_presentacion", "idpresentacion");
            lista_presentaciones.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                if (MessageBox.Show("¿Desea agregar la presentación de \"" + lista_presentaciones.Text + "\" al producto?", nombre_productos + " " + idsuc_producto, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    guardar_presentacion();
                }
            }
            
        }

        private bool validar()
        {
            bool valido = false;
            error.Clear();
            string mensaje = "No se puede dejar la cantidad a cero";

            if (txtPrecio.Value == 0)
            {
                valido = true;
                error.SetError(txtPrecio, mensaje);
            }

            if (txtCantidad.Value == 0)
            {
                valido = true;
                error.SetError(txtCantidad, mensaje);
            }

            return valido;
        }
  

        private void guardar_presentacion()
        {
            string prio = "2", esta = "2", tipoP="2";
            if (chkPriori.Checked)
            {
                prio = "1";
            }
            if (chkEstado.Checked)
            {
                esta = "1";
            }
            if (chkTPrecio.Checked)
            {
                tipoP = "1";
            }
            pp = new conexiones_BD.clases.presentaciones_productos(idsuc_producto,
                lista_presentaciones.SelectedValue.ToString(),
                txtCantidad.Value.ToString(),
                txtPrecio.Value.ToString(),
                tipoPrese(),
                prio,
                esta,
                tipoP
                );
            using (espera_datos.splash_espera es=new espera_datos.splash_espera())
            {
                es.Funcion_sentencia = guardando;
                es.Tipo_operacion = 2;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private string tipoPrese()
        {
            if (chkMayoreo.Checked)
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }

        private int guardando()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return (int)op.insertar(pp.sentenciaIngresar());
        }
    }
}
