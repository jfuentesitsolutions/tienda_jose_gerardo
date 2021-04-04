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
    public partial class precios_productos : Form
    {
        utilitarios.cargar_tablas tabla;
        DataTable productos;
        private bool conexion_remota = false;
        string nombre_anterior;
        conexiones_BD.clases.productos pro;
        conexiones_BD.clases.sucursales_productos sp;

        public DataTable Productos
        {
            get
            {
                return productos;
            }

            set
            {
                productos = value;
            }
        }

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }

        public precios_productos()
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

        private void precios_productos_Load(object sender, EventArgs e)
        {
            if (conexion_remota)
            {
                lblEncanezado.Text = "Modificar productos conectado a servidor remoto...";
                lblEncanezado.ForeColor = Color.GreenYellow;
                imgServidor.Visible = true;
                btnAgregar.Visible = true;
            }
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            cargarTablas();
        }

        private void cargarTablas()
        {
            tabla = new utilitarios.cargar_tablas(tablad, txtBusqueda, productos, "productoCod");
            tabla.cargarSinContadorRegistros();
            lblTotal.Text = productos.Rows.Count.ToString();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            tabla.FiltrarLocalmenteSinContadorRegistros();
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {         
                    tablad.Focus();
                
            } else if (e.KeyCode== Keys.Enter)
            {
                //this.cargarDatos();
            }
        }

        private void tablad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBusqueda.Focus();
            }else if(e.KeyCode == Keys.Enter){
                //this.cargarDatos();
            }
        }

        private void tablad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private List<DataTable> procesarDatos()
        {
            List<DataTable> datos = new List<DataTable>();
            datos.Add(conexiones_BD.clases.marcas.datosTabla(conexion_remota));
            datos.Add(conexiones_BD.clases.categorias.datosTabla(conexion_remota));
            datos.Add(conexiones_BD.clases.estantes.datosTabla(conexion_remota));
            datos.Add(conexiones_BD.clases.utilidades.datosTablaMayoreo(conexion_remota));
            datos.Add(conexiones_BD.clases.utilidades.datosTablaDetalle(conexion_remota));
            return datos;
        }

        private void cargarDatos()
        {
            if (tablad.Rows.Count != 0)
            {
                using (espera_datos.splash_espera fe = new espera_datos.splash_espera()) {

                    fe.Funcion = procesarDatos;

                    if (fe.ShowDialog() == DialogResult.OK)
                    {
                        List<DataTable> listas = fe.Datos_varios;
                        producto pr = new producto();

                        pr.Conexion_remota = this.conexion_remota;
                        pr.txtCodigo.Text = tablad.CurrentRow.Cells[1].Value.ToString();
                        pr.txtNombre.Text = tablad.CurrentRow.Cells[2].Value.ToString();
                        pr.existencia.Value = Convert.ToDecimal(tablad.CurrentRow.Cells[6].Value.ToString());
                        pr.Estado = tablad.CurrentRow.Cells[28].Value.ToString();

                        pr.Idmarca = tablad.CurrentRow.Cells[15].Value.ToString();
                        pr.Idcategoria = tablad.CurrentRow.Cells[16].Value.ToString();
                        pr.Idestante = tablad.CurrentRow.Cells[17].Value.ToString();
                        pr.Kardex = tablad.CurrentRow.Cells[18].Value.ToString();
                        
                        
                        if (!tablad.CurrentRow.Cells[19].Value.ToString().Equals(""))
                        {
                            pr.fecha.Value = Convert.ToDateTime(tablad.CurrentRow.Cells[19].Value.ToString());
                        }
                        
                        pr.Marcas = listas[0];
                        pr.Categorias = listas[1];
                        pr.Estantes = listas[2];
                        pr.Mayoreo = listas[3];
                        pr.Detalle = listas[4];


                        pr.Idsuc_produ = tablad.CurrentRow.Cells[0].Value.ToString();
                        pr.Idproducto = tablad.CurrentRow.Cells[14].Value.ToString();

                        pr.Utili_m = tablad.CurrentRow.Cells[20].Value.ToString();
                        pr.Utili_d = tablad.CurrentRow.Cells[21].Value.ToString();
                        pr.Pv = tablad.CurrentRow.Cells[22].Value.ToString();
                        pr.Pc = tablad.CurrentRow.Cells[23].Value.ToString();
                        pr.Pvm = tablad.CurrentRow.Cells[24].Value.ToString();
                        pr.Pcm = tablad.CurrentRow.Cells[25].Value.ToString();

                        this.Hide();
                        pr.ShowDialog();
                        this.Show();

                        if (tablad.Rows.Count != 0)
                        {
                            tablad.CurrentCell = tablad.Rows[0].Cells[1];
                        }

                        if (pr.Actualiza)
                        {
                            using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                            {
                                es.Funcion_recargar = cargarDatosP;
                                es.Tipo_operacion = 1;
                                if (es.ShowDialog() == DialogResult.OK)
                                {
                                    productos = es.Datos;
                                    cargarTablas();
                                    txtBusqueda.Focus();
                                }                               
                              }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La carga de productos a sido cancelada...");
                    }
                }
                    
            }
            else
            {
                txtBusqueda.Text = "";
                txtBusqueda.Focus();
                
            }     
        }

        private DataTable cargarDatosP()
        {
            DataTable datos = conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_VENT(conexion_remota); 
            return datos;
        }

        private void tablad_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (tablad.Columns[e.ColumnIndex].Name == "nombre")
            {
                nombre_anterior = tablad.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void tablad_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (tablad.Columns[e.ColumnIndex].Name == "nombre")
            {
                if (!nombre_anterior.Equals(tablad.Rows[e.RowIndex].Cells[2].Value))
                {
                    if (MessageBox.Show("¿Deseas cambiar el nombre del producto: " + nombre_anterior + " por: \n" + tablad.Rows[e.RowIndex].Cells[2].Value.ToString() + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pro = new conexiones_BD.clases.productos(tablad.CurrentRow.Cells[14].Value.ToString(), tablad.Rows[e.RowIndex].Cells[2].Value.ToString());
                        using (espera_datos.splash_espera es= new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_nombre;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    MessageBox.Show("Nombre cambiado", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tablad.Rows[e.RowIndex].Cells[2].Value = nombre_anterior;
                                }
                            }
                        }
                    }
                    else
                    {
                        tablad.Rows[e.RowIndex].Cells[2].Value = nombre_anterior;
                    }
                }
            }
        }

        private int modificando_nombre()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(pro.modificando_nombre());
        }

        private void tablad_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==26 || e.ColumnIndex==27)
            {
                tablad.Cursor = Cursors.Hand;
            }
            else
            {
                tablad.Cursor = Cursors.Default;
            }
        }

        private void tablad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 26)
            {
                this.cargarDatos();
            }
            if (e.ColumnIndex == 27)
            {

                if (tablad.CurrentRow.Cells[28].Value.ToString()=="Activo")
                {
                    if (MessageBox.Show("¿Deseas desactivar este producto?", "Desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sp = new conexiones_BD.clases.sucursales_productos(tablad.CurrentRow.Cells[0].Value.ToString(),
                    tablad.CurrentRow.Cells[6].Value.ToString(),
                    "2");

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificar_estado;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    DataGridViewRow fila = tablad.CurrentRow;
                                    fila.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Strikeout);
                                    fila.Cells[28].Value = "Desactivo";
                                    fila.Cells[27].Value = Properties.Resources.apagado;

                                }
                                else
                                {
                                    MessageBox.Show("No se puede cambiar el estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Deseas activar este producto?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sp = new conexiones_BD.clases.sucursales_productos(tablad.CurrentRow.Cells[0].Value.ToString(),
                    tablad.CurrentRow.Cells[6].Value.ToString(),
                    "1");

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificar_estado;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    DataGridViewRow fila = tablad.CurrentRow;
                                    fila.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                                    fila.Cells[28].Value = "Activo";
                                    fila.Cells[27].Value = Properties.Resources.encendido;
                                }
                                else
                                {
                                    MessageBox.Show("No se puede cambiar el estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        private int modificar_estado()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(sp.modificar_estado());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            interfaces.mantenimientos.productos producto = new mantenimientos.productos();
            producto.Conexion_remota = conexion_remota;
            producto.Ingreso_nuevo = true;
            producto.ShowDialog();
            if (producto.DialogResult == DialogResult.OK)
            {
                using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                {
                    es.Funcion_recargar = cargarDatosP;
                    es.Tipo_operacion = 1;
                    if (es.ShowDialog() == DialogResult.OK)
                    {
                        productos = es.Datos;
                        cargarTablas();
                        txtBusqueda.Focus();
                    }
                }
            }
        }

        private void tablad_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow fila in tablad.Rows)
            {
                if (fila.Cells[28].Value.ToString() != "Activo")
                {
                    fila.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Strikeout);
                    fila.Cells[27].Value = Properties.Resources.apagado;
                }
            }
        }
    }
}
