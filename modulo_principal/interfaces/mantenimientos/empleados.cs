using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.mantenimientos
{
    public partial class empleados : Form
    {
        bool modificar = false;
        conexiones_BD.clases.empleados emple;
        conexiones_BD.clases.empleados_sucursales emp_suc;
        conexiones_BD.operaciones op;
        utilitarios.cargar_tablas tabla;
        string idempleado=null;
        string idempleados_sucursal=null;
        string nombre = null;
        string apellidos = null;
        bool conexion_remota = false;

        public bool Modificar
        {
            get
            {
                return modificar;
            }

            set
            {
                modificar = value;
            }
        }

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }

        public empleados()
        {
            InitializeComponent();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Modificar)
            {
                eliminarEmpleados();
            }else
            {
                this.Close();
            }
            
        }

        private void empleados_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            if (Modificar)
            {
                recargandoDatos();
                btnGuardar.Text = "Modificar";
                btnCancelar.Text = "Eliminar";
                habilitar(false);
            }else
            {
                recargandoDatos();
            }
        }

        private List<DataTable> cargando_datos()
        {
            List<DataTable> datos = new List<DataTable>();
            datos.Add(conexiones_BD.clases.empleados.datosTabla(conexion_remota));
            datos.Add(conexiones_BD.clases.cargos.datosTabla(Conexion_remota));
            datos.Add(conexiones_BD.clases.sucursales.datosTabla(conexion_remota));

            return datos;
        }

        private void recargandoDatos()
        {
            using (espera_datos.splash_espera es = new espera_datos.splash_espera())
            {
                es.Funcion = cargando_datos;
                if(conexion_remota)
                    es.Conec_server = true;

                if (es.ShowDialog() == DialogResult.OK)
                {
                    tabla = new utilitarios.cargar_tablas(tablaEmpleados, txtBuscar, es.Datos_varios[0], "nombres", lblRegistro);
                    tabla.cargar();
                    utilitarios.cargandoListas.cargarLista(es.Datos_varios[1], listaCargo, "nombre_cargo", "idcargo");
                    utilitarios.cargandoListas.cargarLista(es.Datos_varios[2], listaSucursales, "numero_de_sucursal", "idsucursal");
                    utilitarios.cargandoListas.generarListasGenero(listaGenero);
                }
            }
        }


        private void habilitar(bool con)
        {
            List<Control> control = new List<Control>();
            control.Add(txtNombre);
            control.Add(txtApellidos);
            control.Add(listaGenero);
            control.Add(txtDui);
            control.Add(txtNit);
            control.Add(listaCargo);
            control.Add(listaSucursales);
            control.Add(txtTelefono);
            control.Add(txtCorreo);
            control.Add(btnGuardar);
            control.Add(btnCancelar);
            utilitarios.vaciando_formularios.habilitandoTexbox(control, con);
        }

        private bool validar()
        {
            bool valido = false;

            List<TextBox> control = new List<TextBox>();
            control.Add(txtNombre);
            control.Add(txtApellidos);
            control.Add(txtDui);
            control.Add(txtNit);
            control.Add(txtTelefono);
            control.Add(txtCorreo);

            valido=utilitarios.vaciando_formularios.validando(control, error);
            if (listaCargo.SelectedIndex==-1)
            {
                valido = true;
                error.SetError(listaCargo, "Tienes que seleccionar un cargo");
            }

            if (listaSucursales.SelectedIndex == -1)
            {
                valido = true;
                error.SetError(listaSucursales, "Tienes que seleccionar una sucursal");
            }

            if (listaGenero.SelectedIndex == -1 || listaGenero.SelectedIndex==0)
            {
                valido = true;
                error.SetError(listaGenero, "Tienes que seleccionar un genero");
            }
            return valido;

        }

        private void vaciarDatos()
        {
            List<Control> control = new List<Control>();
            control.Add(txtNombre);
            control.Add(txtApellidos);
            control.Add(txtDui);
            control.Add(txtNit);
            control.Add(txtTelefono);
            control.Add(txtCorreo);
            utilitarios.cargandoListas.establecerValor(listaCargo, "0");
            utilitarios.cargandoListas.establecerValor(listaSucursales, "0");
            listaGenero.SelectedIndex = 0;
            

            utilitarios.vaciando_formularios.vaciarTexbox(control);
        }

        private bool validandoExistencias()
        {
            List<string> campos = new List<string>();
            List<string> valores = new List<string>();
            bool valido = false;
            campos.Add("nombres");
            campos.Add("apellidos");
            valores.Add(txtNombre.Text);
            valores.Add(txtApellidos.Text);

            emple = new conexiones_BD.clases.empleados(campos, valores);

            if (Modificar)
            {
                if(txtNombre.Text.Equals(nombre) && txtApellidos.Text.Equals(apellidos))
                {
                    if (emple.validarCamposcondicorANDActu(true, 1, conexion_remota) > 1)
                    {
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                }
                else
                {
                    if (emple.validarCamposcondicorAND(true, conexion_remota) > 0)
                    {
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                }

               
            }
            else
            {
                if (emple.validarCamposcondicorAND(true, conexion_remota) > 0)
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                }
            }

            return valido;
        }

        private void guardarEmpleados()
        {
            if (!validar())
            {
                if (!validandoExistencias())
                {
                    emple = new conexiones_BD.clases.empleados(
                        txtNombre.Text,
                        txtApellidos.Text,
                        txtDui.Text,
                        txtNit.Text,
                        listaGenero.SelectedIndex.ToString(),
                        listaCargo.SelectedValue.ToString(),
                        txtTelefono.Text,
                        txtCorreo.Text);

                    emp_suc = new conexiones_BD.clases.empleados_sucursales(listaSucursales.SelectedValue.ToString(), "0");

                    using(espera_datos.splash_espera es =new espera_datos.splash_espera())
                    {
                        es.Funcion_sentencia = guardando_datos;
                        es.Tipo_operacion = 2;
                        if (es.ShowDialog() == DialogResult.OK)
                        {
                            if (es.Resultado > 0)
                            {
                                MessageBox.Show("El empleado se guardo con exito", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                vaciarDatos();
                                recargandoDatos();
                                txtNombre.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El empleado no se guardo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    
                    
                }
            }
        }

        private int guardando_datos()
        {
            op = new conexiones_BD.operaciones();
            op.Conexion_remota = true;
            return op.transaccionEmpleados_sucursales(emple, emp_suc);
        }

        private void modificarEmpleados()
        {
            if (!validar())
            {
                if (validandoExistencias())
                {
                    
                }else
                {
                    emple = new conexiones_BD.clases.empleados(
                        idempleado, txtNombre.Text, txtApellidos.Text, txtDui.Text, txtNit.Text,
                        listaGenero.SelectedIndex.ToString(), listaCargo.SelectedValue.ToString(),
                        txtTelefono.Text, txtCorreo.Text
                        );

                    emp_suc = new conexiones_BD.clases.empleados_sucursales(idempleados_sucursal, listaSucursales.SelectedValue.ToString(), idempleado);

                    using(espera_datos.splash_espera es = new espera_datos.splash_espera())
                    {
                        es.Funcion_sentencia = modificando_datos;
                        es.Tipo_operacion = 2;

                        if (es.ShowDialog() == DialogResult.OK)
                        {
                            if (es.Resultado > 0)
                            {
                                MessageBox.Show("El empleado se modifico con exíto", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                recargandoDatos();
                                vaciarDatos();
                                habilitar(false);
                            }
                            else
                            {
                                MessageBox.Show("El empleado no se pudo modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private int modificando_datos()
        {
            if (emple.modificar(false, conexion_remota) > 0)
            {
                return emp_suc.modificar(false, conexion_remota);
            }
            return 0;
        }

        private void eliminarEmpleados()
        {
            if (idempleado!=null)
            {
                if (idempleados_sucursal!=null)
                {
                      emp_suc = new conexiones_BD.clases.empleados_sucursales(idempleados_sucursal);
                    if (emp_suc.eliminar(false, false) > 0)
                    {
                        emple = new conexiones_BD.clases.empleados(idempleado);
                        if (emple.eliminar(false, false) > 0)
                        {
                            MessageBox.Show("El empleado se elimino con exito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vaciarDatos();
                            habilitar(false);
                            recargandoDatos();
                        } else
                        {
                            MessageBox.Show("El empleado no se pudo eliminar", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnAgregaCargo_Click(object sender, EventArgs e)
        {
            mantenimientos.cargos cr = new cargos();
            cr.Conexion_remota = conexion_remota;
            cr.ShowDialog();
            utilitarios.cargandoListas.cargarLista(conexiones_BD.clases.cargos.datosTabla(conexion_remota), listaCargo, "nombre_cargo", "idcargo");
        }

        private void btnAgregarSucursal_Click(object sender, EventArgs e)
        {
            mantenimientos.sucursales suc = new sucursales();
            suc.ShowDialog();
            utilitarios.cargandoListas.cargarLista(conexiones_BD.clases.sucursales.datosTabla(conexion_remota), listaSucursales, "numero_de_sucursal", "idsucursal");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Modificar)
            {
                modificarEmpleados();
            }else
            {
                guardarEmpleados();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            tabla.FiltrarLocalmente();
        }

        private void tablaEmpleados_Click(object sender, EventArgs e)
        {
            if (modificar)
            {
                idempleado = tablaEmpleados.CurrentRow.Cells[0].Value.ToString();
                idempleados_sucursal = tablaEmpleados.CurrentRow.Cells[11].Value.ToString();
                txtNombre.Text = tablaEmpleados.CurrentRow.Cells[1].Value.ToString();
                nombre = tablaEmpleados.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = tablaEmpleados.CurrentRow.Cells[2].Value.ToString();
                apellidos = tablaEmpleados.CurrentRow.Cells[2].Value.ToString();
                listaGenero.SelectedItem = tablaEmpleados.CurrentRow.Cells[4].Value.ToString();
                txtDui.Text = tablaEmpleados.CurrentRow.Cells[5].Value.ToString();
                txtNit.Text = tablaEmpleados.CurrentRow.Cells[6].Value.ToString();
                listaCargo.SelectedValue = tablaEmpleados.CurrentRow.Cells[7].Value.ToString();
                txtTelefono.Text = tablaEmpleados.CurrentRow.Cells[9].Value.ToString();
                txtCorreo.Text = tablaEmpleados.CurrentRow.Cells[10].Value.ToString();
                listaSucursales.SelectedValue = tablaEmpleados.CurrentRow.Cells[12].Value.ToString();
                habilitar(true);

            }
        }
    }
}
