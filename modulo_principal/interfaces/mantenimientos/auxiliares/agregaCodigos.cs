using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.mantenimientos.auxiliares
{
    public partial class agregaCodigos : Form
    {
        string idproducto = null, idcodigo=null;
        bool modificar = false;
        utilitarios.cargar_tablas tabla;
        bool listo = false;
        private bool conexion_remota = false;

        public string Idproducto
        {
            get
            {
                return idproducto;
            }

            set
            {
                idproducto = value;
            }
        }

        public bool Listo
        {
            get
            {
                return listo;
            }

            set
            {
                listo = value;
            }
        }

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }

        public agregaCodigos()
        {
            InitializeComponent();
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void agregaCodigos_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            cargartabla();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargartabla()
        {
            using (espera_datos.splash_espera es=new espera_datos.splash_espera())
            {
                es.Funcion_recargar = carga_datos;
                es.Tipo_operacion = 1;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    tabla = new utilitarios.cargar_tablas(tablaCodigos, new TextBox(), es.Datos , "codigo");
                    tabla.cargarSinContadorRegistros();
                    chkActi.Checked = true;
                }
            }
                
        }

        private DataTable carga_datos()
        {
            return conexiones_BD.clases.codigos.cargarCodigosTodos(idproducto, conexion_remota);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                if (!validar())
                {
                    if (!codigoRepetido())
                    {
                        this.agregarCodigo();
                    }

                } 
        }

        private void agregarCodigo()
        {
            using(espera_datos.splash_espera es=new espera_datos.splash_espera())
            {
                es.Funcion_sentencia = agregando_codigo;
                es.Tipo_operacion = 2;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    if (es.Resultado > 0)
                    {
                        cargartabla();
                        txtCodigo.Text = "";
                        chkActi.Checked = true;
                        Listo = true;

                    }
                    else
                    {
                        MessageBox.Show("No se pudo ingresar el codigo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }  
            }            
        }

        private int agregando_codigo()
        {
            string estado = "";
            if (chkActi.Checked && !chkDesac.Checked)
            {
                estado = "1";
            }
            else if (!chkActi.Checked && chkDesac.Checked)
            {
                estado = "2";
            }

            conexiones_BD.clases.codigos c = new conexiones_BD.clases.codigos(txtCodigo.Text, estado);
            conexiones_BD.clases.productos_codigos pc = new conexiones_BD.clases.productos_codigos(idproducto, "");
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;

            return op.EjecutartransaccionCodigosProduc(c, pc);
        }

        private void desactivarCodigos()
        {
            using(espera_datos.splash_espera es= new espera_datos.splash_espera())
            {
                es.Funcion_sentencia = modifica_codigo;
                es.Tipo_operacion = 2;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    if ( es.Resultado > 0)
                    {
                        this.cargartabla();
                        modificar = false;
                        txtCodigo.Text = "";
                        chkActi.Checked = true;
                        listo = true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private int modifica_codigo()
        {
            string estado = "";
            if (chkActi.Checked && !chkDesac.Checked)
            {
                estado = "1";
            }
            else if (!chkActi.Checked && chkDesac.Checked)
            {
                estado = "2";
            }
            conexiones_BD.clases.codigos c = new conexiones_BD.clases.codigos(idcodigo, txtCodigo.Text, estado);
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;

            return op.actualizar(c.sentenciaModi().ToString());
        }

        private bool codigoRepetido()
        {
            bool valido = false;
            conexiones_BD.clases.codigos c = new conexiones_BD.clases.codigos(txtCodigo.Text, "1");
            
            if (c.validarCodigo())
            {
                MessageBox.Show("Hemos detectado que el codigo esta repetido", "Codigo Repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valido = true;
            }else
            {
                valido = false;
            }

            return valido;
        }

        private bool codigoRepetidoActua()
        {
            bool valido = false;
            conexiones_BD.clases.codigos c = new conexiones_BD.clases.codigos(txtCodigo.Text, "1");

            if (c.validarCodigoActualizar())
            {
                MessageBox.Show("Hemos detectado que el codigo esta repetido", "Codigo Repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valido = true;
            }
            else
            {
                valido = false;
            }

            return valido;
        }

        private bool validar()
        {
            bool valido = false;
            error.Clear();
            if (txtCodigo.TextLength == 0)
            {
                valido = true;
                error.SetError(txtCodigo, "Tienes que especificar un codigo");
            }
            return valido;
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (modificar)
            {
                if (!validar())
                {
                    if (!codigoRepetidoActua())
                    {
                        this.desactivarCodigos();
                    }
                }
            }

            
        }

        private void tablaCodigos_Click(object sender, EventArgs e)
        {
            modificar = true;
            txtCodigo.Text = tablaCodigos.CurrentRow.Cells[1].Value.ToString();
            idcodigo = tablaCodigos.CurrentRow.Cells[0].Value.ToString();
            if (tablaCodigos.CurrentRow.Cells[2].Value.Equals("Activo"))
            {
                chkActi.Checked = true;
            }
            else
            {
                chkDesac.Checked = true;
            }
        }

        
    }
}
