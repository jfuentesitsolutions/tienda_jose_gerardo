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

    public partial class producto : Form
    {
        string idsuc_produ, idproducto, idpresentacion_producto, utili_m, utili_d, pv, pc, pvm, pcm, 
            idmarca, idcategoria, idestante, kardex, estado;
        DataTable presentaciones, presentacion, marcas, categorias, estantes, mayoreo, detalle;
        conexiones_BD.clases.presentaciones_productos prpr;
        conexiones_BD.clases.proveedores_productos pr;
        conexiones_BD.clases.sucursales_productos sp;
        conexiones_BD.clases.productos pro;
        conexiones_BD.operaciones op;
        utilitarios.cargar_tablas tablas_presentaciones, tabla_proveedores;
        bool actualizarTablas = true, actualiza=false;
        private bool conexion_remota = false;
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        bool cargado = false;

        

        public string Idsuc_produ
        {
            get
            {
                return idsuc_produ;
            }

            set
            {
                idsuc_produ = value;
            }
        }

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

        public string Utili_m
        {
            get
            {
                return utili_m;
            }

            set
            {
                utili_m = value;
            }
        }

        public string Utili_d
        {
            get
            {
                return utili_d;
            }

            set
            {
                utili_d = value;
            }
        }

        public string Pv
        {
            get
            {
                return pv;
            }

            set
            {
                pv = value;
            }
        }

        public string Pc
        {
            get
            {
                return pc;
            }

            set
            {
                pc = value;
            }
        }

        public string Pvm
        {
            get
            {
                return pvm;
            }

            set
            {
                pvm = value;
            }
        }

        public string Pcm
        {
            get
            {
                return pcm;
            }

            set
            {
                pcm = value;
            }
        }

        public bool Actualiza
        {
            get
            {
                return actualiza;
            }

            set
            {
                actualiza = value;
            }
        }

        public DataTable Marcas
        {
            get
            {
                return marcas;
            }

            set
            {
                marcas = value;
            }
        }

        public DataTable Categorias
        {
            get
            {
                return categorias;
            }

            set
            {
                categorias = value;
            }
        }

        public DataTable Estantes
        {
            get
            {
                return estantes;
            }

            set
            {
                estantes = value;
            }
        }

        public DataTable Mayoreo
        {
            get
            {
                return mayoreo;
            }

            set
            {
                mayoreo = value;
            }
        }

        public DataTable Detalle
        {
            get
            {
                return detalle;
            }

            set
            {
                detalle = value;
            }
        }

        public string Idmarca
        {
            get
            {
                return idmarca;
            }

            set
            {
                idmarca = value;
            }
        }

        public string Idcategoria
        {
            get
            {
                return idcategoria;
            }

            set
            {
                idcategoria = value;
            }
        }

        public string Idestante
        {
            get
            {
                return idestante;
            }

            set
            {
                idestante = value;
            }
        }

        public string Kardex
        {
            get
            {
                return kardex;
            }

            set
            {
                kardex = value;
            }
        }

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }
        public string Estado { get => estado; set => estado = value; }

        public producto()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarCodigo_Click(object sender, EventArgs e)
        {
            mantenimientos.auxiliares.agregaCodigos codi = new mantenimientos.auxiliares.agregaCodigos();
            codi.Conexion_remota = conexion_remota;
            codi.Idproducto = this.idproducto;
            Console.WriteLine(idproducto);
            codi.ShowDialog();

            if (codi.Listo)
            {
                cargarCodigos();
            }
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void tabla_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabla.SelectedIndex == 1)
            {
                if (actualizarTablas || tabla_presentacion_producto.RowCount == 0)
                {
                    if (!conexion_remota)
                    {
                        MessageBox.Show("Esta opción esta deshabilitada para la conexión local", "No habilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);         
                    }
                    this.cargarTablaPresentaciones();                    
                }
                
            } else if (tabla.SelectedIndex == 2)
            {
                if (!conexion_remota)
                {
                    MessageBox.Show("Esta opción esta deshabilitada para la conexión local", "No habilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (actualizarTablas || tablaProveedores.RowCount == 0)
                {
                    this.cargarTablasProveedores();
                }
                
                

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            agregar_presentacion frm = new agregar_presentacion();
            frm.Nombre_productos = txtNombre.Text;
            frm.Idsuc_producto = idsuc_produ;
            frm.Conexion_remota = conexion_remota;
            this.Hide();
            using (espera_datos.splash_espera es=new espera_datos.splash_espera())
            {
                es.Funcion_recargar = carga_lista_presentaciones;
                es.Tipo_operacion = 1;

                if (es.ShowDialog() == DialogResult.OK)
                {
                    frm.Datos_presentaciones = es.Datos;
                    frm.ShowDialog();
                    this.Show();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        cargarTablaPresentaciones();
                    }
                }
            }
            
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (precio.Value!=0)
            {
                if (MessageBox.Show("¿Deseas modificar esta presentación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    modificar();
                }
            }
            
        }

        private bool verificarRepetido()
        {
            bool repetido = false;
            if (tablaProveedores.Rows.Count != 0)
            {
                foreach (DataGridViewRow fila in tablaProveedores.Rows)
                {
                    if (fila.Cells[1].Value.ToString().Equals(listaProveedores.SelectedValue.ToString()))
                    {
                        repetido = true;
                    }
                }
            }

            return repetido;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas modificar la información del producto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                modifica();
            }
        }

        private void btnAgr_Click(object sender, EventArgs e)
        {
            if (listaProveedores.SelectedIndex != -1)
            {
                if (!verificarRepetido())
                {
                    pr = new conexiones_BD.clases.proveedores_productos(
                    listaProveedores.SelectedValue.ToString(),
                    idproducto
                    );

                    using(espera_datos.splash_espera es=new espera_datos.splash_espera())
                    {
                        es.Funcion_sentencia = guardando_proveedor;
                        es.Tipo_operacion = 2;
                        if (es.ShowDialog() == DialogResult.OK)
                        {
                            if (es.Resultado > 0)
                            {
                                cargarTablasProveedores();
                            }
                        }
                    }                    
                }
            }
        }

        private int guardando_proveedor()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return (int)op.insertar(pr.sentenciaIngresar());
        }

        private void btnEli_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea quitar este proveedor?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    if (tablaProveedores.RowCount != 0)
                    {
                        pr = new conexiones_BD.clases.proveedores_productos(
                        tablaProveedores.CurrentRow.Cells[0].Value.ToString()
                        );

                        using(espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = eliminar_proveedor;
                            es.Tipo_operacion = 2;

                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                cargarTablasProveedores();
                            }
                        }
                    }
                }    
            }
            catch
            {

            }
        }

        private int eliminar_proveedor()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;

            return (int)op.insertar(pr.sentenciaEliminar());
        }

        private void btnModificaUtilidades_Click(object sender, EventArgs e)
        {
            if (!valida_utilidades())
            {
                sp = new conexiones_BD.clases.sucursales_productos(idsuc_produ, listaMayoreo.SelectedValue.ToString(), listaUtilidadDetalle.SelectedValue.ToString(),
                precioVD.Value.ToString(), precioCD.Value.ToString(), precioVM.Value.ToString(), precioCM.Value.ToString(), estado);

                using(espera_datos.splash_espera es=new espera_datos.splash_espera())
                {
                    es.Funcion_sentencia = modificando_utilizades;
                    es.Tipo_operacion = 2;
                    if (es.ShowDialog() == DialogResult.OK)
                    {
                        if (es.Resultado > 0)
                        {
                            MessageBox.Show("Utilidades actualizadas", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            actualiza = true;
                        }
                        else
                        {
                            MessageBox.Show("No se puedo actualizar las utilidades", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private int modificando_utilizades()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            Console.WriteLine(sp.modificarUtilidadesProducto());
            return op.actualizar(sp.modificarUtilidadesProducto());
        }

        private bool valida_utilidades()
        {
            bool valido = false;
            error4.Clear();
            string mensaje = "La cantidad no puede quedar a cero";

            if (precioCM.Value == 0)
            {
                valido = true;
                error4.SetError(precioCM, mensaje);
            }
            if (precioVM.Value == 0)
            {
                valido = true;
                error4.SetError(precioVM, mensaje);
            }
            if (precioCD.Value == 0)
            {
                valido = true;
                error4.SetError(precioCD, mensaje);
            }
            if (precioVD.Value == 0)
            {
                valido = true;
                error4.SetError(precioVD, mensaje);
            }

            return valido;
        }

        private void listaMayoreo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                DataRowView fila = (DataRowView)listaMayoreo.SelectedItem;
                Decimal UtilidadM = Convert.ToDecimal(fila[3].ToString());

                Decimal precio = (precioCM.Value + (precioCM.Value * UtilidadM));
                precioVM.Value = precio;
            }
            
        }

        private void listaUtilidadDetalle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                DataRowView fila = (DataRowView)listaUtilidadDetalle.SelectedItem;
                Decimal UtilidadD = Convert.ToDecimal(fila[3].ToString());

                Decimal precio = (precioCD.Value + (precioCD.Value * UtilidadD));
                precioVD.Value = precio;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (chkD.Checked || chkM.Checked)
            {
                if (MessageBox.Show("¿Desea quitar esta presentación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        prpr = new conexiones_BD.clases.presentaciones_productos(tabla_presentacion_producto.CurrentRow.Cells[0].Value.ToString());
                        using (espera_datos.splash_espera es=new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = eliminar_presentacion;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                cargarTablaPresentaciones();
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private int eliminar_presentacion()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;

            return (int)op.insertar(prpr.sentenciaEliminar());
        }

        private void producto_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            cargarListas();
            cargandoUtilidades();
            cargado = true;
            if (!conexion_remota)
            {
                grpTablaPresenta.Enabled = false;
                grpDatos.Enabled = false;
                grpProvee.Enabled = false;
                grpProveasig.Enabled = false;
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void cargarListas()
        {
            utilitarios.cargandoListas.cargarLista(marcas, listaMarca, "nombre", "idmarca");
            //utilitarios.cargandoListas.establecerValor(pr.listaMarca, tablad.CurrentRow.Cells[15].Value.ToString());
            utilitarios.cargandoListas.cargarLista(categorias, listaCategoria, "nombre_categoria", "idcategoria");
            //utilitarios.cargandoListas.establecerValor(pr.listaCategoria, tablad.CurrentRow.Cells[16].Value.ToString());
            utilitarios.cargandoListas.cargarLista(estantes, listaEstante, "nombre", "idestante");


            utilitarios.cargandoListas.cargarLista(mayoreo, listaMayoreo, "nombre", "idutilidad_compra");
            utilitarios.cargandoListas.cargarLista(detalle, listaUtilidadDetalle, "nombre", "idutilidad_compra");
            cargarCodigos();
            cargarValores();
        }

        private void cargarCodigos()
        {
            
            using(espera_datos.splash_espera es= new espera_datos.splash_espera())
            {
                es.Funcion_recargar = carga_codigos;
                es.Tipo_operacion = 1;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    if (es.Datos.Rows.Count > 0)
                    {
                        utilitarios.cargandoListas.cargarLista(es.Datos,
                        listaCodigos, "codigo", "idcodigo");
                        listaCodigos.SelectedIndex = 0;
                    }
                    else
                    {
                        listaCodigos.DataSource = null;
                        listaCodigos.Items.Add("No existen codigos activos");
                    }
                }
            }
        }

        private DataTable carga_codigos()
        {
            return conexiones_BD.clases.codigos.cargarCodigos(this.idproducto, conexion_remota);
        }

        private void cargarValores()
        {
            listaMarca.SelectedValue = idmarca;
            listaCategoria.SelectedValue = idcategoria;

            if (!idestante.Equals(""))
            {
                listaEstante.SelectedValue = idestante;
            }
            if (kardex.Equals("SI"))
            {
                chkKardex.Checked = true;
            }
            

        }

        private void tabla_presentacion_producto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla_presentacion_producto.RowCount != 0)
            {
                idpresentacion_producto = tabla_presentacion_producto.CurrentRow.Cells[0].Value.ToString();
                listaPresentacion.SelectedValue = tabla_presentacion_producto.CurrentRow.Cells[1].Value.ToString();
                precio.Text = tabla_presentacion_producto.CurrentRow.Cells[3].Value.ToString();
                canti.Text = tabla_presentacion_producto.CurrentRow.Cells[5].Value.ToString();
                if (tabla_presentacion_producto.CurrentRow.Cells[4].Value.ToString().Equals("Detalle"))
                {
                    chkD.Checked = true;
                    chkD.Focus();
                    chkM.Checked = false;
                }
                else
                {
                    chkD.Checked = false;
                    chkM.Checked = true;
                    chkM.Focus();
                }

                if (tabla_presentacion_producto.CurrentRow.Cells[7].Value.ToString().Equals("1"))
                {
                    chkPriori.Checked = true;
                }
                else
                {
                    chkPriori.Checked = false;
                }

                if (tabla_presentacion_producto.CurrentRow.Cells[8].Value.ToString().Equals("Activo"))
                {
                    chkEstado.Checked = true;
                }else
                {
                    chkEstado.Checked = false;
                }
            }
        }

        private void cargarTablaPresentaciones()
        {
            using(espera_datos.splash_espera es= new espera_datos.splash_espera())
            {
                es.Funcion = cargas_tablas;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    presentaciones = es.Datos_varios[0];
                    presentacion = es.Datos_varios[1] ;

                    utilitarios.cargandoListas.cargarLista(presentacion, listaPresentacion, "nombre_presentacion", "idpresentacion");
                    tablas_presentaciones = new utilitarios.cargar_tablas(tabla_presentacion_producto, new TextBox(), presentaciones, "nombre_presentacion");
                    tablas_presentaciones.cargarSinContadorRegistros();
                    actualizarTablas = false;
                }
            }   
        }

        private List<DataTable> cargas_tablas()
        {
            List<DataTable> datos = new List<DataTable>();
            datos.Add(conexiones_BD.clases.presentaciones_productos.presentacionesXproducto(Idsuc_produ, conexion_remota));
            datos.Add(conexiones_BD.clases.presentaciones.datosTabla(conexion_remota));

            return datos;
        }

        private DataTable carga_lista_presentaciones()
        {
            return conexiones_BD.clases.presentaciones.datosTabla(conexion_remota);
        }


        private void cargarTablasProveedores()
        {
            using(espera_datos.splash_espera es= new espera_datos.splash_espera())
            {
                es.Funcion = cargandoProveedores;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    utilitarios.cargandoListas.cargarLista(es.Datos_varios[0], listaProveedores, "nombre_proveedor", "idproveedor");
                    tabla_proveedores = new utilitarios.cargar_tablas(tablaProveedores, new TextBox(), es.Datos_varios[1], "nombre_proveedor");
                    tabla_proveedores.cargarSinContadorRegistros();
                    actualizarTablas = false;
                }
            }
        }

        private List<DataTable> cargandoProveedores()
        {
            List<DataTable> datos = new List<DataTable>();
            datos.Add(conexiones_BD.clases.proveedores.datosTabla(conexion_remota));
            datos.Add(conexiones_BD.clases.proveedores_productos.datosTabla(idproducto, conexion_remota));
            return datos;
        }

        private void cargandoUtilidades()
        {
            precioCM.Value = Convert.ToDecimal(pcm);
            precioVM.Value = Convert.ToDecimal(pvm);
            precioCD.Value = Convert.ToDecimal(pc);
            precioVD.Value = Convert.ToDecimal(pv);

            if (utili_m.Equals(""))
            {
                listaMayoreo.SelectedValue = 2;
            }else
            {
                listaMayoreo.SelectedValue = utili_m;
            }

            if (utili_d.Equals(""))
            {
                listaUtilidadDetalle.SelectedValue = 4;
            }else
            {
                listaUtilidadDetalle.SelectedValue = utili_d;
            }

            actualizarTablas = false;
        }



        private void modificar()
        {
            string prio = "2", esta="2";
            if (chkPriori.Checked)
            {
                prio = "1";
            }
            if (chkEstado.Checked)
            {
                esta = "1";
            }
            prpr = new conexiones_BD.clases.presentaciones_productos(
                idpresentacion_producto,
                idsuc_produ,
                listaPresentacion.SelectedValue.ToString(),
                canti.Value.ToString(),
                precio.Value.ToString(),
                tipoPrese(),
                prio,
                esta);

            using(espera_datos.splash_espera es=new espera_datos.splash_espera())
            {
                es.Funcion_sentencia = modificar_presentacion;
                es.Tipo_operacion = 2;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    limpiar();
                }
            }
        }

        private int modificar_presentacion()
        {
            return prpr.consulta_modificar(conexion_remota);
        }

        private void limpiar()
        {
            precio.Value = 0;
            canti.Value = 0;
            tabla_presentacion_producto.DataSource = null;
            chkPriori.Checked = false;
            chkM.Checked = false;
            chkD.Checked = false;
            cargarTablaPresentaciones();
        }

        private string tipoPrese()
        {
            if (chkM.Checked)
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }

        private bool validar()
        {
            bool valido = false;
            error4.Clear();
            string mensaje = "Tienes que elegir una opción";
            string mensaje1 = "No puedes dejar este campo a cero";

            if (txtCodigo.TextLength == 0)
            {
                valido = true;
                error4.SetError(txtCodigo, mensaje);
            }
            if (txtNombre.TextLength == 0)
            {
                valido = true;
                error4.SetError(txtNombre, mensaje);
            }
            if (listaMarca.SelectedIndex == -1)
            {
                valido = true;
                error4.SetError(listaMarca, mensaje);
            }
            if (listaCategoria.SelectedIndex == -1)
            {
                valido = true;
                error4.SetError(listaCategoria, mensaje);
            }
            if (listaEstante.SelectedIndex == -1)
            {
                valido = true;
                error4.SetError(listaEstante, mensaje);
            }
            
            
            if (existencia.Value.ToString().Equals("0"))
            {
                valido = true;
                error4.SetError(existencia, mensaje1);
            }

            return valido;
        }

        private void modifica()
        {  
            if (!validar())
            {
                utilitarios.maneja_fechas fec = new utilitarios.maneja_fechas();
                string kar = "2";
                if (chkKardex.Checked)
                {
                    kar = "1";
                }

                pro = new conexiones_BD.clases.productos(
                    txtNombre.Text.ToUpper(),
                    fec.fechaMysql(fecha),
                    listaCategoria.SelectedValue.ToString(),
                    listaMarca.SelectedValue.ToString(),
                    this.idproducto);

                sp = new conexiones_BD.clases.sucursales_productos(
                       this.idsuc_produ,
                       sesion.DatosRegistro[1],
                       this.idproducto,
                       listaMayoreo.SelectedValue.ToString(),
                       listaUtilidadDetalle.SelectedValue.ToString(),
                       listaEstante.SelectedValue.ToString(),
                       existencia.Value.ToString(),
                       precioVD.Value.ToString(),
                       precioCD.Value.ToString(),
                       precioVM.Value.ToString(),
                       precioCM.Value.ToString(),
                       kar, estado);

                using (espera_datos.splash_espera fe = new espera_datos.splash_espera())
                {
                    fe.Funcion_sentencia = actualizando_datos_en_base;
                    fe.Tipo_operacion = 2;
                    if (fe.ShowDialog() == DialogResult.OK)
                    {
                        if ( fe.Resultado > 0)
                        {
                            MessageBox.Show("Se actualizo con exíto", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Actualiza = true;
                        }
                    }
     
                }
            }
        }

        private int actualizando_datos_en_base()
        {
            op = new conexiones_BD.operaciones();
            op.Conexion_remota = this.conexion_remota;
            int resul= op.EjecutartransaccionModificarProducto(sp, pro);
            return resul;
        }
    }
}
