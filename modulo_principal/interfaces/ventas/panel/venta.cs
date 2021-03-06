using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace interfaces.ventas.panel
{
    public partial class venta : Form

    {
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        //DataTable formas_pagos = conexiones_BD.clases.formas_pago.datosTabla();
        //DataTable tipo_factura = conexiones_BD.clases.tipos_factura.datosTabla();
        //DataTable cliente = conexiones_BD.clases.clientes.datosTabla();
        //DataTable vendedor = conexiones_BD.clases.usuarios.datosTabla();
        utilitarios.cargar_tablas tabla, tablaC;
        string cantiAn, precioAn;
        bool busqueda = false, busquedaC=false, valido=false;
        string idticket_Buscado = null;
        Action accion;
        string correlativoAA, idcorrel;
        DataRowView cliente = null;
        List<string> lista = new List<string>();
        List<string> lista_p = new List<string>();

        //DataTable producto_venta = null;
        DataTable pre_producto = null;
        string total = "0.0";


        public venta()
        {
            InitializeComponent();
        }

        private void venta_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > 800)
            {
                lblDi.Visible = true;
                txtDireccion.Visible = true;
                lblncr.Visible = true;
                lblven.Visible = true;
                txtncr.Visible = true;
                listaVendedor.Visible = true;

            }
            else
            {
                lblDi.Visible = false;
                txtDireccion.Visible = false;
                lblncr.Visible = false;
                lblven.Visible = false;
                txtncr.Visible = false;
                listaVendedor.Visible = false;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ocultarDetalles();
        }

        private void ocultarDetalles()
        {
            //if (Gcliente.Height == 137)
            //{
            //    lblDi.Visible = false;
            //    lblncr.Visible = false;
            //    lblven.Visible = false;
            //    txtDireccion.Visible = false;
            //    txtncr.Visible = false;
            //    listaVendedor.Visible = false;
            //    Gcliente.Height = 75;
            //    panelInferio.Height = 135;
            //}
            //else
            //{
            //    lblDi.Visible = true;
            //    lblncr.Visible = true;
            //    lblven.Visible = true;
            //    txtDireccion.Visible = true;
            //    txtncr.Visible = true;
            //    listaVendedor.Visible = true;
            //    Gcliente.Height = 137;
            //    panelInferio.Height = 198;
            //}
        }

        private void cargaListas()
        {
            utilitarios.cargandoListas.cargarLista(conexiones_BD.clases.formas_pago.datosTabla(), listaFormaPago, "nombre_pago", "idforma_pago");
            listaFormaPago.SelectedValue = "1";
            utilitarios.cargandoListas.cargarLista(conexiones_BD.clases.tipos_factura.datosTabla(), listaTipoFactura, "nombre", "idtipo_factura");
            listaTipoFactura.SelectedValue = "1";
            //utilitarios.cargandoListas.cargarLista(conexiones_BD.clases.clientes.datosTabla(), listaClientes, "nom", "idcliente");
            //listaClientes.SelectedValue = "1";

            utilitarios.cargandoListas.cargarLista(conexiones_BD.clases.usuarios.datosTabla(), listaVendedor, "usuario", "idusuario");
            listaVendedor.Text = sesion.Datos[0];
            if (!sesion.Datos[3].Equals("Administradores"))
            {
                listaVendedor.Enabled = false;
            }
            //nuevoCliente();
            
        }

        private void cargarTablas()
        {
            tabla = new utilitarios.cargar_tablas(tablad, txtBusqueda, conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_X_SUCURSAL_VENTA(), "productoCod");
            tabla.cargarSinContadorRegistros();

            tablaC = new utilitarios.cargar_tablas(tabla_clientes, txtBuscarCliente, conexiones_BD.clases.clientes.datosClientes(), "nombre");
            tablaC.cargarSinContadorRegistros();
        }

        //private void cargarListaProductos()
        //{
            
        //    if (chkCod.Checked)
        //    {
        //        if (sesion.Datos[3].Equals("Administradores"))
        //        {
        //            utilitarios.cargandoListas.cargarLista(pre_producto, listaControl, "codigo", "idsp");
        //        }
        //        else
        //        {
        //            utilitarios.cargandoListas.cargarLista(pre_producto, listaControl, "codigo", "idsp");
        //        }
        //        listaControl.Focus();
        //        //lbltipoBusqueda.Text="Codigo:";
        //    }
        //    else if (chkNom.Checked)
        //    {
        //        if (sesion.Datos[3].Equals("Administradores"))
        //        {
        //            utilitarios.cargandoListas.cargarLista(pre_producto, listaControl, "nombre", "idsp");
        //        }
        //        else
        //        {
        //            utilitarios.cargandoListas.cargarLista(pre_producto, listaControl, "nombre", "idsp");
        //        }
        //        listaControl.Focus();
        //        //lbltipoBusqueda.Text = "Nombre:";
        //    }
        //    else if (chkPres.Checked)
        //    {
        //        if (sesion.Datos[3].Equals("Administradores"))
        //        {
        //            utilitarios.cargandoListas.cargarLista(pre_producto, listaControl, "prepro", "idsp");
        //        }
        //        else
        //        {
        //            utilitarios.cargandoListas.cargarLista(pre_producto, listaControl, "prepro", "idsp");
        //        }
        //        listaControl.Focus();
        //        //lbltipoBusqueda.Text = "Presentación:";
        //    }

 
            
        //}

        private void venta_Load(object sender, EventArgs e)
        {
            relog.Start();
            
            //  producto_venta = conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_X_SUCURSAL_VENTA(sesion.DatosRegistro[1]);
            Thread t = new Thread(creandoaccion);
            t.Start();
            
        }

        private void creandoaccion()
        {
            accion = cargarTodo;
            if (InvokeRequired)
            {
                Invoke(accion);
            }

            
        }

        private void cargarTodo()
        {
            pre_producto = conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_X_PRESENTACION_X_SUCURSAL_VENTA(sesion.DatosRegistro[1]);


            btnReimprimir.Enabled = false;
            //cargarListaProductos();
            cargaListas();
            cargarTablas();
            txtBuscarCliente.Text = tabla_clientes.Rows[0].Cells[0].Value.ToString();
            txtDireccion.Text = tabla_clientes.Rows[0].Cells[5].Value.ToString();

            lista.Add(tabla_clientes.Rows[0].Cells[3].Value.ToString());
            lista.Add(tabla_clientes.Rows[0].Cells[1].Value.ToString());
            lista.Add(tabla_clientes.Rows[0].Cells[2].Value.ToString());
            lista.Add(tabla_clientes.Rows[0].Cells[5].Value.ToString());
            lista.Add(tabla_clientes.Rows[0].Cells[6].Value.ToString());

            lista_p.Clear();
            lista.ForEach(c => lista_p.Add(c));



        }

        private void chkCod_CheckedChanged(object sender, EventArgs e)
        {
            //cargarListaProductos();
        }

        private void chkPres_CheckedChanged(object sender, EventArgs e)
        {
            //cargarListaProductos();
        }

        private void chkNom_CheckedChanged(object sender, EventArgs e)
        {
            //cargarListaProductos();
        }

        private void venta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtBuscarCliente.Focus();
            }
            else if (e.KeyCode == Keys.F2)
            {
                chkPres.Checked = true;
            }
            else if (e.KeyCode == Keys.F3)
            {
                chkNom.Checked = true;
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnGuardar.PerformClick();
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnBuscar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnReimprimir.PerformClick();
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnCancelar.PerformClick();
            }else if (e.KeyCode == Keys.F5)
            {
                cargarTablas();
                barraDeprogreso(10);
            }else if (e.KeyCode == Keys.F11)
            {
                cobrosinTicket();
            }
        }

        private void listaControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (chkCod.Checked || chkNom.Checked)
                    {
                        //cantidadProductos();
                    }else if(chkPres.Checked)
                    {
                        //cantidadProductoPrese();
                    } 
                }
                catch
                {

                }

            }
        }

        //private void cantidadProductos()
        //{
        //    auxiliares.producto_unica_presentacion pu = new auxiliares.producto_unica_presentacion();
        //    DataRowView seleccion = (DataRowView)listaControl.SelectedItem;
        //    auxiliares.productos_mas_presentaciones puu = new auxiliares.productos_mas_presentaciones();

        //    //si el articulos solo tiene una presentacion
        //    if (seleccion.Row[3].ToString().Equals("1"))
        //    {
        //        pu.Idpresentacion_poroducto = seleccion.Row[8].ToString();
        //        if (seleccion.Row[11].ToString().Equals("Detalle"))
        //        {
        //            pu.TipoUtilidad = seleccion.Row[9].ToString();
        //        }
        //        else
        //        {
        //            pu.TipoUtilidad = seleccion.Row[10].ToString();
        //        }
        //            pu.Sucursal_producto = seleccion.Row[0].ToString();
        //            pu.Codigo = seleccion.Row[1].ToString();
        //            pu.lblExis.Text = seleccion.Row[6].ToString();
        //            pu.lblNombre.Text = seleccion.Row[2].ToString();
        //            pu.lblPres.Text = seleccion.Row[7].ToString();
        //            pu.lblPrecio.Text = "$" + seleccion.Row[5].ToString();
        //            pu.Precio = seleccion.Row[5].ToString();
        //            pu.txtCantidad.Value = 1;
        //            pu.CantidadInter = "1";

        //        pu.ShowDialog();
        //        if (pu.Llenado)
        //        {
        //            //si la tabla esta vacia
        //            if (tabla_articulos.Rows.Count == 0)
        //            {
        //                barraDeprogreso(10);
        //                tabla_articulos.Rows.Add(
        //                "",
        //                pu.Codigo,
        //                pu.lblNombre.Text,
        //                pu.lblPres.Text,
        //                pu.txtCantidad.Value.ToString(),
        //                pu.Precio,
        //                pu.Total,
        //                pu.Idpresentacion_poroducto,
        //                pu.Utilidad,
        //                "",
        //                "1",
        //                pu.lblExis.Text,
        //                pu.Sucursal_producto
        //                );
                        
        //            }else
        //            {
        //                //si el articulo no esta repetido
        //                if(!productoRepetido(pu.Idpresentacion_poroducto, pu.txtCantidad.Value.ToString()))
        //                {
        //                    barraDeprogreso(10);
        //                    tabla_articulos.Rows.Add(
        //                "",
        //                pu.Codigo,
        //                pu.lblNombre.Text,
        //                pu.lblPres.Text,
        //                pu.txtCantidad.Value.ToString(),
        //                pu.Precio,
        //                pu.Total,
        //                pu.Idpresentacion_poroducto,
        //                pu.Utilidad,
        //                "",
        //                "1",
        //                pu.lblExis.Text,
        //                pu.Sucursal_producto
        //                );
        //                }
                        
        //            }
                    
        //            utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
        //            cargarListaProductos();
        //            calcularTotales();
        //        }
        //        //cuando hay mas de dos presentaciones
        //    }else
        //    {
        //        puu.Sucursal_producto = seleccion.Row[0].ToString();
        //        puu.IdsucursalProducto = seleccion.Row[0].ToString();
        //        puu.Codigo = seleccion.Row[1].ToString();
        //        puu.UtilidadD = seleccion.Row[9].ToString();
        //        puu.UtiliadM = seleccion.Row[10].ToString();
        //        puu.lblExis.Text = seleccion.Row[6].ToString();
        //        puu.lblNombre.Text = seleccion.Row[2].ToString();

        //        puu.ShowDialog();

        //        if (puu.Llenado)
        //        {
        //            if (tabla_articulos.Rows.Count == 0)
        //            {
        //                barraDeprogreso(10);
        //                tabla_articulos.Rows.Add(
        //                "",
        //                puu.Codigo,
        //                puu.lblNombre.Text,
        //                puu.Presentacion,
        //                puu.txtCantidad.Value.ToString(),
        //                puu.Precio,
        //                puu.Total,
        //                puu.Idpresentacion_poroducto,
        //                puu.Utilidad,
        //                "",
        //                puu.Cantidad_interna,
        //                puu.lblExis.Text,
        //                puu.Sucursal_producto
        //                );
        //            }
        //            else
        //            {

        //                if (!revisarExistencias(puu.IdsucursalProducto, puu.txtCantidad.Value.ToString(), puu.Cantidad_interna))
        //                {
        //                    if (!productoRepetido(puu.Idpresentacion_poroducto, puu.txtCantidad.Value.ToString()))
        //                    {
        //                        barraDeprogreso(10);
        //                        tabla_articulos.Rows.Add(
        //                    "",
        //                    puu.Codigo,
        //                    puu.lblNombre.Text,
        //                    puu.Presentacion,
        //                    puu.txtCantidad.Value.ToString(),
        //                    puu.Precio,
        //                    puu.Total,
        //                    puu.Idpresentacion_poroducto,
        //                    puu.Utilidad,
        //                    "",
        //                    puu.Cantidad_interna,
        //                    puu.lblExis.Text,
        //                    puu.Sucursal_producto
        //                    );
        //                    }
        //                }

                        
                          
        //            }
        //        }
        //        utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
        //        cargarListaProductos();
        //        calcularTotales();
                
        //    }
        //}

        //private void cantidadProductoPrese()
        //{
        //    auxiliares.producto_unica_presentacion pu = new auxiliares.producto_unica_presentacion();
        //    DataRowView seleccion = (DataRowView)listaControl.SelectedItem;

        //    pu.Idpresentacion_poroducto = seleccion.Row[6].ToString();
        //    if (seleccion.Row[9].ToString().Equals("Detalle"))
        //    {
        //        pu.TipoUtilidad = seleccion.Row[7].ToString();
        //    }
        //    else
        //    {
        //        pu.TipoUtilidad = seleccion.Row[8].ToString();
        //    }
        //    pu.Sucursal_producto = seleccion.Row[0].ToString();
        //    pu.Codigo = seleccion.Row[1].ToString();
        //    pu.lblExis.Text = seleccion.Row[4].ToString();
        //    pu.lblNombre.Text = seleccion.Row[2].ToString();
        //    pu.lblPres.Text = seleccion.Row[5].ToString();
        //    pu.lblPrecio.Text = "$" + seleccion.Row[3].ToString();
        //    pu.Precio = seleccion.Row[3].ToString();
        //    pu.txtCantidad.Value = 1;
        //    pu.CantidadInter= seleccion.Row[10].ToString();

        //    pu.ShowDialog();
        //    if (pu.Llenado)
        //    {
        //        if (tabla_articulos.Rows.Count == 0)
        //        {
        //            barraDeprogreso(10);
        //            tabla_articulos.Rows.Add(
        //            "",
        //            pu.Codigo,
        //            pu.lblNombre.Text,
        //            pu.lblPres.Text,
        //            pu.txtCantidad.Value.ToString(),
        //            pu.Precio,
        //            pu.Total,
        //            pu.Idpresentacion_poroducto,
        //            pu.Utilidad,
        //            "",
        //            pu.CantidadInter,
        //            pu.lblExis.Text,
        //            pu.Sucursal_producto
        //            );

        //        }
        //        else
        //        {
        //            if (!productoRepetido(pu.Idpresentacion_poroducto, pu.txtCantidad.Value.ToString()))
        //            {
        //                barraDeprogreso(10);
        //                tabla_articulos.Rows.Add(
        //            "",
        //            pu.Codigo,
        //            pu.lblNombre.Text,
        //            pu.lblPres.Text,
        //            pu.txtCantidad.Value.ToString(),
        //            pu.Precio,
        //            pu.Total,
        //            pu.Idpresentacion_poroducto,
        //            pu.Utilidad,
        //            "",
        //            pu.CantidadInter,
        //            pu.lblExis.Text,
        //            pu.Sucursal_producto
        //            );
        //            }

        //        }

        //        utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
        //        cargarListaProductos();
        //        calcularTotales();
        //    }

        //}

        private bool productoRepetido(string idpr_pro, string cant)
        {
            bool encontrado = false;
            
                foreach (DataGridViewRow fila in tabla_articulos.Rows)
                {
                    if (fila.Cells[7].Value.Equals(idpr_pro))
                    {
                        Int32 canA = Convert.ToInt32(fila.Cells[4].Value);
                        Int32 canN = Convert.ToInt32(cant);

                        Int32 canInt = Convert.ToInt32(fila.Cells[10].Value);
                        Int32 exis = Convert.ToInt32(fila.Cells[11].Value);

                        Int32 canTN = canA + canN;
                        Int32 tN = (canA * canInt) + (canN * canInt);

                        if (tN > exis)
                        {
                            MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            encontrado = true;
                        }
                        else
                        {
                            fila.Cells[4].Value = canTN.ToString();
                            fila.Cells[6].Value = recalcularTotalProducto(fila.Cells[4].Value.ToString(), fila.Cells[5].Value.ToString());
                            encontrado = true;
                        }
                    }
                }


            

            return encontrado;
        }


        private string recalcularTotalProducto(string canti, string pre)
        {
            string total = "";
            double ca = Convert.ToDouble(canti);
            double prec = Convert.ToDouble(pre);
            double tota = Math.Round(ca * prec, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine(ca);
            Console.WriteLine(pre);

            total = tota.ToString();
            
            return total;
        }
        private void calcularTotales()
        {
            double precio = 0;
            foreach(DataGridViewRow fila in tabla_articulos.Rows)
            {
                precio += Convert.ToDouble(fila.Cells[6].Value);
            }

            lblCantidad_de_articulos.Text = "Cantidad de articulos " + tabla_articulos.Rows.Count;
            lblSubt.Text = precio.ToString();
            lblIva.Text = "0.0";
            lblDescuento.Text = "0.0";
            lblTotal.Text = "$ "+ precio.ToString();
            total = precio.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (tabla_articulos.RowCount!=0)
            {
                if (MessageBox.Show("Tienes articulos agregados ¿Deseas quitarlos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)==DialogResult.Yes)
                {
                    tabla_articulos.Rows.Clear();
                    tabla_articulos.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnReimprimir.Enabled = false;
                    txtBusqueda.Enabled = true;
                    calcularTotales();
                    colocarFoco();
                }
                
            }
            
        }
        private void quitarPestaña()
        {
            Panel pan = (Panel)this.Parent;
            TabPage pagi = (TabPage)pan.Parent;
            TabControl con = (TabControl)pagi.Parent;

            try
            {
                if (con.TabPages.Count > 1)
                {
                    con.TabPages.Remove(con.SelectedTab);
                }
                
            }
            catch
            {

            }
            
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            fecha_actual.Value = DateTime.Now;

            if (!validar())
            {
                string correlativo = generaciondecorrelativo(); //se genera el correlativo
                string id = IDCorrelativoTicket(); // se coloca el id del correlativo
                if (correlativo != null) // si el correlativo se genera correctamente
                {
                    interfaces.ventas.auxiliares.cobrar cobro = new auxiliares.cobrar();
                    cobro.lblTotala.Text = total;
                    cobro.efec.Text = total;
                    cobro.ShowDialog();
                    if (cobro.Cobrado)
                    {
                        ingresandoVentaTicket(correlativo, cobro.txtefe.Text, cobro.lblCambio.Text, id); // metodo para ingresar la venta del ticket
                    }
                }
            }
 
        }

        private void cobrosinTicket()
        {
            fecha_actual.Value = DateTime.Now;

            if (!validar())
            {
                string correlativo = generaciondecorrelativo(); //se genera el correlativo
                string id = IDCorrelativoTicket(); // se coloca el id del correlativo
                if (correlativo != null) // si el correlativo se genera correctamente
                {
                    auxiliares.cobrar cobro = new auxiliares.cobrar();
                    cobro.lblTotala.Text = total;
                    cobro.lblEncanezado.Text = "Sin comprobante";
                    cobro.panelTitulo.BackColor = Color.Red;
                    cobro.efec.Text = total;
                    cobro.ShowDialog();
                    if (cobro.Cobrado)
                    {
                        ingresandoVentaTicket_sincomprobante(correlativo, cobro.txtefe.Text, cobro.lblCambio.Text, id); // metodo para ingresar la venta del ticket
                    }
                }
            }
        }
        private void ingresandoVentaTicket(string correl, string efec, string cam, string idcorre)
        {
            
            utilitarios.maneja_fechas fecha = new utilitarios.maneja_fechas();
            Console.WriteLine(fecha_actual.ToString());

            conexiones_BD.clases.ventas.tickets ticke = new conexiones_BD.clases.ventas.tickets(
                "0", "0", fecha.fechaMy(lblrelog.ToString()), sesion.DatosRegistro[1], "1", listaFormaPago.SelectedValue.ToString(),
                correl, listaVendedor.SelectedValue.ToString(), lblSubt.Text, lblDescuento.Text,
                this.total, "1", efec, cam, lista[0], idcorre, sesion.Idcaja);

            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            conexiones_BD.clases.ctrl_errores.errores err= op.transaccionVentasTickets(retornoProductos(), ticke);

            Int32 res = err.Res;

            if ( res > 0)
            {
               
                    PrintDocument printDoc = new PrintDocument();
                    string impresora = printDoc.PrinterSettings.PrinterName;
                    
                        conexiones_BD.clases.ventas.impresion_prueba imp = new conexiones_BD.clases.ventas.impresion_prueba();
                        if (imp.impresionTicket(impresora, conexiones_BD.clases.ventas.detalles_productos_venta_ticket.detalle_proTic(correl)))
                        {
                        tabla_articulos.Rows.Clear();
                        calcularTotales();
                        busqueda = false;
                        txtBusqueda.Text = "";
                        txtBusqueda.Focus();
                        tablad.Visible = false;
                        tablad.DataSource = null;
                        tabla_clientes.DataSource = null;
                        cargaListas();

                        cargarTablas();

                        lista.Clear();
                        lista_p.ForEach(c => lista.Add(c));
                       
                        txtDireccion.Text = lista_p[3];
                        txtBuscarCliente.Text = lista_p[1]+" "+lista_p[2];

                        tabla_clientes.Visible = false;
                        System.Console.Write(lista[1]);


                    //if (Gcliente.Height==137)
                    //{
                    //    ocultarDetalles();
                    //}
                    valido = false;
                        
                    }
                    else
                    {

                    MessageBox.Show("Se produjo un error al guardar el ticket, pero la venta se guardo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabla_articulos.Rows.Clear();
                        calcularTotales();
                        busqueda = false;
                        txtBusqueda.Text = "";
                        txtBusqueda.Focus();
                        tablad.Visible = false;
                        tablad.DataSource = null;
                        valido = false;
                    }
       
            }
            else
            {
                conexiones_BD.clases.ventas.correlativos_tickets.actualizaCorrelativos(correlativoAA, idcorrel);
                Console.WriteLine(correlativoAA);
                MessageBox.Show(err.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ingresandoVentaTicket_sincomprobante(string correl, string efec, string cam, string idcorre)
        {

            utilitarios.maneja_fechas fecha = new utilitarios.maneja_fechas();
            Console.WriteLine(fecha_actual.ToString());

            conexiones_BD.clases.ventas.tickets ticke = new conexiones_BD.clases.ventas.tickets(
            "0", "0", fecha.fechaMy(lblrelog.ToString()), sesion.DatosRegistro[1], "1", listaFormaPago.SelectedValue.ToString(),
            correl, listaVendedor.SelectedValue.ToString(), lblSubt.Text, lblDescuento.Text,
            this.total, "1", efec, cam, lista[0], idcorre, sesion.Idcaja);

            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            conexiones_BD.clases.ctrl_errores.errores err = op.transaccionVentasTickets(retornoProductos(), ticke);

            Int32 res = err.Res;

            if (res > 0)
            {

                    MessageBox.Show("Venta realizada", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabla_articulos.Rows.Clear();
                    calcularTotales();
                    busqueda = false;
                    txtBusqueda.Text = "";
                    txtBusqueda.Focus();
                    tablad.Visible = false;
                    tablad.DataSource = null;
                    tabla_clientes.DataSource = null;
                    cargaListas();

                    cargarTablas();

                    lista.Clear();
                    lista_p.ForEach(c => lista.Add(c));

                    txtDireccion.Text = lista_p[3];
                    txtBuscarCliente.Text = lista_p[1] + " " + lista_p[2];

                    tabla_clientes.Visible = false;
                    System.Console.Write(lista[1]);

            }
            else
            {
                conexiones_BD.clases.ventas.correlativos_tickets.actualizaCorrelativos(correlativoAA, idcorrel);
                Console.WriteLine(correlativoAA);
                MessageBox.Show(err.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validar()
        {
            bool valido = false;
            error.Clear();

            if (listaTipoFactura.SelectedIndex!=0)
            {
                if (txtncr.TextLength == 0)
                {
                    valido = true;
                    error.SetError(txtncr, "Tienes que digitar un numero de documento");
                    //if (Gcliente.Height != 137)
                    //{
                    //    ocultarDetalles();
                    //}
                }
            }

            if (tabla_articulos.Rows.Count == 0)
            {
                valido = true;
                error.SetError(tabla_articulos, "Tienes que gregar articulos al detalle");
            }

            if (lista.Count == 0)
            {
                valido = true;
                error.SetError(txtBuscarCliente, "Tienes que insertar un cliente");
            }

            return valido;
        }

        private List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket> retornoProductos()
        {
            List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket> dp = new List<conexiones_BD.clases.ventas.detalles_productos_venta_ticket>();
            
            foreach (DataGridViewRow fila in tabla_articulos.Rows)
            {
                    double cantidad = Convert.ToDouble(fila.Cells[10].Value.ToString());
                    double can = Convert.ToDouble(fila.Cells[4].Value.ToString());
                    dp.Add(new conexiones_BD.clases.ventas.detalles_productos_venta_ticket(
                        "0", 
                        fila.Cells[7].Value.ToString(), 
                        can.ToString(),
                        fila.Cells[5].Value.ToString(), 
                        fila.Cells[6].Value.ToString(),
                        fila.Cells[8].Value.ToString(), 
                        "0", 
                        fila.Cells[12].Value.ToString(),
                        cantidad.ToString(), 
                        fila.Cells[1].Value.ToString()));
            }


            return dp;
        }

        private void tabla_articulos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (tabla_articulos.Columns[e.ColumnIndex].Name == "canti")
            {
                double canN = 0;
                double canNU = 0;
                int canNuu = 0;

                if (tabla_articulos.Rows[e.RowIndex].Cells[13].Value.ToString().Equals("0"))
                {
                    
                    try
                    {
                        canN = Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString()) * Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[10].Value.ToString());
                        canNuu = Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString());

                        if (!revisarExistencias2(tabla_articulos.Rows[e.RowIndex].Cells[12].Value.ToString(), canN.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[10].Value.ToString()))
                        {
                            Int32 exist = Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[11].Value.ToString());

                            if (canN == exist || canN < exist)
                            {
                                tabla_articulos.Rows[e.RowIndex].Cells[6].Value = recalcularTotalProducto(canNuu.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString());
                                calcularTotales();
                                colocarFoco();
                            }
                            else
                            {
                                MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                            }
                        }
                        else
                        {
                            tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                        }
                    } catch{
                        MessageBox.Show("No puedes agregar esa cantidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        canN = Convert.ToInt32(cantiAn);
                        tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                        tabla_articulos.Rows[e.RowIndex].Cells[6].Value = recalcularTotalProducto(cantiAn.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString());
                        
                    }

                }
                else
                { 
                    try
                    {
                        canN = Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString()) 
                            * Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[10].Value.ToString());
                        canNU = Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString());
                        Console.WriteLine(canN);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Debes ingresar una cantidad valida", "No es numero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        canN = Convert.ToInt32(cantiAn);
                        tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                    }

                    if (!revisarExistencias2(tabla_articulos.Rows[e.RowIndex].Cells[12].Value.ToString(), canN.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[10].Value.ToString()))
                    {
                        Int32 exist = Convert.ToInt32(tabla_articulos.Rows[e.RowIndex].Cells[11].Value.ToString());


                        if (canN == exist || canN < exist)
                        {
                            tabla_articulos.Rows[e.RowIndex].Cells[6].Value = recalcularTotalProducto(canNU.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString());
                            //calculando la nueva utilidad

                            
                            if (tabla_articulos.Rows[e.RowIndex].Cells[15].Value.ToString().Equals("1"))
                            {
                                double uti = 1-Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[13].Value.ToString());
                                tabla_articulos.Rows[e.RowIndex].Cells[8].Value = Math.Round((Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[6].Value.ToString()) * uti),2);
                            }
                            else
                            {
                                double uti = 1-Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[14].Value.ToString());
                                tabla_articulos.Rows[e.RowIndex].Cells[8].Value = Math.Round((Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[6].Value.ToString()) * uti), 2);
                            }

                            calcularTotales();
                            colocarFoco();
                        }
                        else
                        {
                            MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                        }
                    }
                    else
                    {
                        tabla_articulos.Rows[e.RowIndex].Cells[4].Value = cantiAn;
                    }
                }
            }else if (tabla_articulos.Columns[e.ColumnIndex].Name == "preci")
            {

                if (MessageBox.Show("¿Deseas cambiar el precio de la presentación?","Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    barraDeprogreso(10);
                    string precioN = tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (!conexiones_BD.clases.presentaciones_productos.cambio_precio(tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[7].Value.ToString()))
                    {     
                        tabla_articulos.Rows[e.RowIndex].Cells[5].Value = precioN;
                        calcularTotales();     
                    }
                    tabla_articulos.Rows[e.RowIndex].Cells[6].Value = recalcularTotalProducto(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString());

                    //calculando la nueva utilidad
                    if (tabla_articulos.Rows[e.RowIndex].Cells[15].Value.ToString().Equals("1"))
                    {
                        double uti = 1 - Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[13].Value.ToString());
                        tabla_articulos.Rows[e.RowIndex].Cells[8].Value = Math.Round((Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[6].Value.ToString()) * uti), 2);
                    }
                    else
                    {
                        double uti = 1 - Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[14].Value.ToString());
                        tabla_articulos.Rows[e.RowIndex].Cells[8].Value = Math.Round((Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[6].Value.ToString()) * uti), 2);
                    }

                    cargarTablas();
                    txtBusqueda.Text = "";
                    txtBusqueda.Focus();
                    busqueda = false;
                    tablad.Visible = false;
                    calcularTotales();
                }
                else
                {
                    string precioN = tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    tabla_articulos.Rows[e.RowIndex].Cells[5].Value = precioN;
                    tabla_articulos.Rows[e.RowIndex].Cells[6].Value = recalcularTotalProducto(tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString(), tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString());

                    //calculando la nueva utilidad
                    if (tabla_articulos.Rows[e.RowIndex].Cells[15].Value.ToString().Equals("1"))
                    {
                        double uti = 1 - Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[13].Value.ToString());
                        tabla_articulos.Rows[e.RowIndex].Cells[8].Value = Math.Round((Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[6].Value.ToString()) * uti), 2);
                    }
                    else
                    {
                        double uti = 1 - Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[14].Value.ToString());
                        tabla_articulos.Rows[e.RowIndex].Cells[8].Value = Math.Round((Convert.ToDouble(tabla_articulos.Rows[e.RowIndex].Cells[6].Value.ToString()) * uti), 2);
                    }

                    cargarTablas();
                    txtBusqueda.Text = "";
                    txtBusqueda.Focus();
                    busqueda = false;
                    tablad.Visible = false;
                    calcularTotales();
                }
            }
        }

        private void tabla_articulos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (tabla_articulos.Rows.Count != 0)
                {
                    if (MessageBox.Show("¿Desea quitar este producto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        barraDeprogreso(10);
                        tabla_articulos.Rows.RemoveAt(tabla_articulos.CurrentRow.Index);
                        calcularTotales();
                    }
                }
            }
            catch
            {

            }
        }

        private void listaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Enter)
            {
                this.nuevoCliente();
            }*/
        }

        private void tabla_articulos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (tabla_articulos.Columns[e.ColumnIndex].Name == "canti")
            {
                cantiAn = tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            else if (tabla_articulos.Columns[e.ColumnIndex].Name == "preci")
            {
                precioAn= tabla_articulos.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void nuevoCliente()
        {
            if (txtBuscarCliente.TextLength != 0)
            {
                ingresandoNuevoCliente();
            }
                
        }

        private void ingresandoNuevoCliente()
        {
            if (MessageBox.Show("¿Deseas ingresar un nuevo cliente?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                auxiliares.nuevo_cliente_simple cli = new auxiliares.nuevo_cliente_simple();
                cli.Cli = conexiones_BD.clases.clientes.datosTabla();
                cli.txtNombres.Text = txtBuscarCliente.Text;
                cli.txtApellidos.Text = "-";
                cli.txtDire.Text = "-";
                cli.ShowDialog();
                if (cli.Ingresado)
                {
                    cargarTablas();

                    lista.Clear();
                    lista.Add(cli.Idcliente);
                    lista.Add(cli.txtNombres.Text);
                    lista.Add(cli.txtApellidos.Text);
                    lista.Add(cli.txtDire.Text);
                    lista.Add(cli.listaGenero.SelectedValue.ToString());

                    txtBuscarCliente.Text = lista[1]+" "+lista[2];
                    txtDireccion.Text = lista[3];
                    txtBuscarCliente.Focus();
                    tabla_clientes.Visible = false;        
                 }
            }
            else
            {
                cargarTablas();
            }
        }

        private void activacionCampoDocumento()
        {
            if (listaTipoFactura.SelectedIndex==0)
            {
                txtncr.Enabled = false;
                txtncr.Text = "";
                //if (Gcliente.Height == 137)
                //{
                //    ocultarDetalles();
                //}
            }
            else
            {
                txtncr.Enabled = true;
                txtncr.Text = "";
                txtncr.Focus();
                //if(Gcliente.Height != 137)
                //{
                //    ocultarDetalles();
                //}
            }

        }

        private string IDCorrelativoTicket()
        {
            string idcorre = "";
            DataTable correlativos = conexiones_BD.clases.ventas.correlativos_tickets.datosTabla(sesion.DatosRegistro[1], sesion.DatosRegistro[6]);
            if (correlativos == null)
            {
                idcorre = "0";
            }else
            {
                idcorre = correlativos.Rows[0][0].ToString();
            }

            return idcorre;
        }

        private void listaTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaTipoFactura.SelectedValue != null)
            {
                activacionCampoDocumento();
                
            }
        }

        private void txtncr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //listaControl.Focus();
                ocultarDetalles();
            }
        }

        private void barraDeprogreso(Int32 valorMaximo)
        {
            progreso.Minimum = 1;
            progreso.Maximum = valorMaximo;

            progreso.Value = 1;
            progreso.Step = 1;

            for (int x = 1; x <= valorMaximo; x++)
            {
                    progreso.PerformStep();  
            }
        }

        private string generaciondecorrelativo()
        {
            string corre = null;
            DataTable correlativos = conexiones_BD.clases.ventas.correlativos_tickets.datosTabla(sesion.DatosRegistro[1], sesion.DatosRegistro[6]);
            Int32 limite = 0;
            Int32 correlativoActual = 0;
            Int32 correlativoSiguiente = 0;

            if (correlativos == null || correlativos.Rows.Count==0)
            {
                MessageBox.Show("No se han establecido correlativos para esta sucursal o no especificado el nombre del equipo", "Error de correlativos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                correlativoActual = Convert.ToInt32(correlativos.Rows[0][4].ToString());
                correlativoAA = correlativos.Rows[0][4].ToString();
                idcorrel = correlativos.Rows[0][0].ToString();

                limite = Convert.ToInt32(correlativos.Rows[0][3].ToString());
                if (correlativoActual+1==limite)
                {
                    MessageBox.Show("Ya se alcanso el limite de tickets emitidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    correlativoSiguiente = correlativoActual+1;
                    Console.WriteLine(correlativoSiguiente);
                    if (conexiones_BD.clases.ventas.correlativos_tickets.actualizaCorrelativos(correlativoSiguiente.ToString(), correlativos.Rows[0][0].ToString()))
                    {
                        corre = generandoCorrelativos(correlativoActual.ToString(), correlativos.Rows[0][0].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Setecto un problema al generar el correlativo","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }   
            }

            return corre;
        }

        private string generandoCorrelativos(string cS, string idCo)
        {
            string corr = null;
            int numeroDigitos = cS.Length;
            string identifica = "T" + sesion.DatosRegistro[0]+idCo;

            switch (numeroDigitos)
            {
                case 1:
                    {
                        corr = identifica + "00000" + cS;
                        break;
                    }
                case 2:
                    {
                        corr = identifica + "0000" + cS;
                        break;
                    }
                case 3:
                    {
                        corr = identifica + "000" + cS;
                        break;
                    }
                case 4:
                    {
                        corr = identifica + "00" + cS;
                        break;
                    }
                case 5:
                    {
                        corr = identifica + "0" + cS;
                        break;
                    }
                case 6:
                    {
                        corr = identifica + cS;
                        break;
                    }

            }

            return corr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            string impresora = printDoc.PrinterSettings.PrinterName;

            if (idticket_Buscado!=null)
            {
                conexiones_BD.clases.ventas.impresion_prueba imp = new conexiones_BD.clases.ventas.impresion_prueba();
                if (imp.impresionTicket(impresora, conexiones_BD.clases.ventas.detalles_productos_venta_ticket.detalle_proTic(idticket_Buscado)))
                {
                    tabla_articulos.Rows.Clear();
                    tabla_articulos.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnReimprimir.Enabled = false;
                    txtBusqueda.Enabled = true;
                    colocarFoco();
                    calcularTotales();
                }
                else
                {

                }
            }
            
        }

        private string cantidadNueva(string exi, string c, string ci)
        {
            Int32 cantiInte = Convert.ToInt32(ci);
            Int32 canti = Convert.ToInt32(c);
            Int32 exis = Convert.ToInt32(exi);

            Int32 cantA = exis - (canti*cantiInte);

            return cantA.ToString();
        }

        private bool revisarExistencias(string idsucur, string canN, string canI)
        {
            bool existen = false;
            int cantidadReg = 0;
            double conte = 0;
            Int32 exis = 0;
            double caN = Convert.ToDouble(canN);
            double caI = Convert.ToDouble(canI);

            foreach (DataGridViewRow fila in tabla_articulos.Rows)
            {
                if (fila.Cells[12].Value.Equals(idsucur))
                {
                    conte += (Convert.ToDouble(fila.Cells[4].Value.ToString())*Convert.ToDouble(fila.Cells[10].Value.ToString()));
                    exis = Convert.ToInt32(fila.Cells[11].Value.ToString());
                    cantidadReg++;
                }
            }

            if (cantidadReg>0)
            {
                conte += (caN * caI);
                Console.WriteLine(conte + "hola");
                Console.WriteLine(exis + "Exist");

                if (conte > exis)
                {
                    MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    existen = true;
                }
                else
                {
                    existen = false;
                }
            }else
            {
                existen = false;
            }
            


            return existen;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (busqueda)
            {
                tablad.Visible = true;
                tabla.FiltrarLocalmenteSinContadorRegistros();
                try
                {
                    if (tablad.Rows.Count != 0)
                    {
                        tablad.CurrentCell = tablad.Rows[0].Cells[1];
                    }
                    
                }
                catch
                {

                }
            }
            
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                tablad.Visible = false;
            }else if (e.KeyCode == Keys.Down)
            {
                if (txtBusqueda.TextLength!=0)
                {
                    tablad.Focus();  
                }         
            }else if (e.KeyCode==Keys.Enter)
            {
                if (txtBusqueda.TextLength!=0)
                {
                    if (busqueda)
                    {
                        try
                        {
                            cantidadProductos2();
                            colocarFoco();
                        }
                        catch
                        {

                        }
                    }
                } 
            }
        }

        private bool revisarExistencias2(string idsucur, string canN, string canI)
        {
            bool existen = false;
            int cantidadReg = 0;
            double conte = 0;
            Int32 exis = 0;
            double caN = Convert.ToDouble(canN);
            double caI = Convert.ToDouble(canI);

            foreach (DataGridViewRow fila in tabla_articulos.Rows)
            {
                if (fila.Cells[12].Value.Equals(idsucur))
                {
                    conte += (Convert.ToDouble(fila.Cells[4].Value.ToString()) * Convert.ToDouble(fila.Cells[10].Value.ToString()));
                    exis = Convert.ToInt32(fila.Cells[11].Value.ToString());
                    cantidadReg++;
                }
            }

            if (cantidadReg > 1)
            {
                conte += (caN * caI);
                conte = conte - caN;
                Console.WriteLine(conte + "hola");
                Console.WriteLine(exis + "Exist");

                if (conte > exis)
                {
                    MessageBox.Show("No hay existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    existen = true;
                }
                else
                {
                    existen = false;
                }
            }
            else
            {
                existen = false;
            }



            return existen;
        }

        private void tablad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            busqueda = true;
            if (e.KeyCode == Keys.Add)
            {
                if (tabla_articulos.Rows.Count!=0)
                {
                    e.SuppressKeyPress = true;
                    tabla_articulos.Focus();
                    colocarEnelutimoRegistro();
                }
                
            }

        }

        private void tablad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                try
                {
                    if (busqueda)
                    {
                        cantidadProductos2();
                        txtBusqueda.Text = "";
                        txtBusqueda.Focus();
                        tablad.Visible = false;
                        busqueda = false;
                    }

                }
                catch
                {

                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                busqueda = false;
                txtBusqueda.Text = "";
                txtBusqueda.Focus();
                tablad.Visible = false;

            }
        }

        private void tabla_articulos_Click(object sender, EventArgs e)
        {
            try
            {
                //lblrelog.Text = tabla_articulos.CurrentRow.Cells[11].Value.ToString();
            }
            catch
            {
                
            }
            
        }

        private void tabla_articulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (tabla_articulos.Columns[e.ColumnIndex].Name == "prese")
            {
                try
                {
                     
                    
                    if (MessageBox.Show("¿Cambiar presentación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        if (tabla_articulos.Rows[e.RowIndex].Cells[13].Value.ToString().Equals("0"))
                        {
                            MessageBox.Show("No hay presentaciones", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        } else
                        {
                            auxiliares.productos_mas_presentaciones puu = new auxiliares.productos_mas_presentaciones();
                            puu.Sucursal_producto = tabla_articulos.Rows[e.RowIndex].Cells[12].Value.ToString();
                            puu.IdsucursalProducto = tabla_articulos.Rows[e.RowIndex].Cells[12].Value.ToString();
                            puu.Codigo = tabla_articulos.Rows[e.RowIndex].Cells[1].Value.ToString();
                            puu.UtilidadD = tabla_articulos.Rows[e.RowIndex].Cells[13].Value.ToString();
                            puu.UtiliadM = tabla_articulos.Rows[e.RowIndex].Cells[14].Value.ToString();
                            puu.lblExis.Text = tabla_articulos.Rows[e.RowIndex].Cells[11].Value.ToString();
                            puu.lblNombre.Text = tabla_articulos.Rows[e.RowIndex].Cells[2].Value.ToString();
                            puu.txtCantidad.Text= tabla_articulos.Rows[e.RowIndex].Cells[4].Value.ToString();

                            puu.ShowDialog();

                            if (puu.Llenado)
                            {
                                if (tabla_articulos.Rows.Count == 0)
                                {
                                    barraDeprogreso(10);
                                    tabla_articulos.Rows.Add(
                                    "",
                                    puu.Codigo,
                                    puu.lblNombre.Text,
                                    puu.Presentacion,
                                    puu.txtCantidad.Value.ToString(),
                                    puu.Precio,
                                    puu.Total,
                                    puu.Idpresentacion_poroducto,
                                    puu.Utilidad,
                                    "",
                                    puu.Cantidad_interna,
                                    puu.lblExis.Text,
                                    puu.Sucursal_producto,
                                    puu.UtilidadD,
                                    puu.UtiliadM
                                    );

                                    tabla_articulos.Rows.RemoveAt(e.RowIndex);
                                    calcularTotales();
                                    utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                                }
                                else
                                {

                                    if (!revisarExistencias(puu.IdsucursalProducto, puu.txtCantidad.Value.ToString(), puu.Cantidad_interna))
                                    {
                                        if (!productoRepetido(puu.Idpresentacion_poroducto, puu.txtCantidad.Value.ToString()))
                                        {
                                            barraDeprogreso(10);
                                            tabla_articulos.Rows.Add(
                                        "",
                                        puu.Codigo,
                                        puu.lblNombre.Text,
                                        puu.Presentacion,
                                        puu.txtCantidad.Value.ToString(),
                                        puu.Precio,
                                        puu.Total,
                                        puu.Idpresentacion_poroducto,
                                        puu.Utilidad,
                                        "",
                                        puu.Cantidad_interna,
                                        puu.lblExis.Text,
                                        puu.Sucursal_producto,
                                        puu.UtilidadD,
                                        puu.UtiliadM
                                        );
                                            tabla_articulos.Rows.RemoveAt(e.RowIndex);
                                            calcularTotales();
                                            utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tabla_articulos.Rows.Count==0)
            {
                auxiliares.busquedaArticulos frm = new auxiliares.busquedaArticulos();
                frm.ShowDialog();
                if (frm.Elegido)
                {
                    idticket_Buscado = frm.Idventa_tic;
                    btnGuardar.Enabled = false;
                    btnReimprimir.Enabled = true;
                    colocar_productos(frm.Docu);
                    tabla_articulos.Enabled = false;
                    txtBusqueda.Enabled = false;
                }
            }else
            {
                tabla_articulos.Rows.Clear();
                auxiliares.busquedaArticulos frm = new auxiliares.busquedaArticulos();
                frm.ShowDialog();
                if (frm.Elegido)
                {
                    idticket_Buscado = frm.Idventa_tic;
                    txtBusqueda.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnReimprimir.Enabled = true;
                    colocar_productos(frm.Docu);
                    tabla_articulos.Enabled = false;
                }
            }
            
        }

        private void colocar_productos(DataTable pr)
        {
            foreach (DataRow fila in pr.Rows)
            {
                tabla_articulos.Rows.Add(
                    "0",
                    fila[16].ToString(),
                    fila[2].ToString(),
                    fila[1].ToString(),
                    fila[0].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString()
                    );
            }
            utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
            calcularTotales();

        }

        private void cantidadProductos2()
        {
            auxiliares.producto_unica_presentacion pu = new auxiliares.producto_unica_presentacion();
            DataGridViewRow seleccion = tablad.CurrentRow;
            auxiliares.productos_mas_presentaciones puu = new auxiliares.productos_mas_presentaciones();

            //si el articulos solo tiene una presentacion
            if (seleccion.Cells[3].Value.ToString().Equals("1"))
            {
                if (seleccion.Cells[14].Value.ToString().Equals("Especial"))
                {
                    if (sesion.Datos[3].Equals("Administradores") || valido)
                    {
                        estableciendo_productos_unicaPre(pu, seleccion, puu);
                    }
                    else
                    {
                        auxiliares.validacion_autorizacion valida = new auxiliares.validacion_autorizacion();
                        valida.ShowDialog();
                        if (valida.Valido)
                        {
                            estableciendo_productos_unicaPre(pu, seleccion, puu);
                            valido = true;
                        }
                        else
                        {
                            this.valido = false;
                        }
                    }
                }
                else
                {
                    estableciendo_productos_unicaPre(pu, seleccion, puu);
                }                  
            }
            else
            {
                //cuando hay mas de dos presentaciones
                puu.Sucursal_producto = seleccion.Cells[0].Value.ToString();
                puu.IdsucursalProducto = seleccion.Cells[0].Value.ToString();
                puu.Codigo = seleccion.Cells[1].Value.ToString();
                puu.UtilidadD = seleccion.Cells[9].Value.ToString();
                puu.UtiliadM = seleccion.Cells[10].Value.ToString();
                puu.lblExis.Text = seleccion.Cells[6].Value.ToString();
                puu.lblNombre.Text = seleccion.Cells[2].Value.ToString();
                puu.Valido = this.valido;

                puu.ShowDialog();
                this.valido = puu.Valido;

                if (puu.Llenado)
                {
                    if (tabla_articulos.Rows.Count == 0)
                    {
                        barraDeprogreso(10);
                        tabla_articulos.Rows.Add(
                        "",
                        puu.Codigo,
                        puu.lblNombre.Text,
                        puu.Presentacion,
                        puu.txtCantidad.Value.ToString(),
                        puu.Precio,
                        puu.Total,
                        puu.Idpresentacion_poroducto,
                        puu.Utilidad,
                        "",
                        puu.Cantidad_interna,
                        puu.lblExis.Text,
                        puu.Sucursal_producto,
                        puu.UtilidadD,
                        puu.UtiliadM,
                        Convert.ToInt16(puu.Uti_detalle).ToString()
                        );
                        colocarEnelutimoRegistro();
                    }
                    else
                    {

                        if (!revisarExistencias(puu.IdsucursalProducto, puu.txtCantidad.Value.ToString(), puu.Cantidad_interna))
                        {
                            if (!productoRepetido(puu.Idpresentacion_poroducto, puu.txtCantidad.Value.ToString()))
                            {
                                barraDeprogreso(10);
                                tabla_articulos.Rows.Add(
                            "",
                            puu.Codigo,
                            puu.lblNombre.Text,
                            puu.Presentacion,
                            puu.txtCantidad.Value.ToString(),
                            puu.Precio,
                            puu.Total,
                            puu.Idpresentacion_poroducto,
                            puu.Utilidad,
                            "",
                            puu.Cantidad_interna,
                            puu.lblExis.Text,
                            puu.Sucursal_producto,
                            puu.UtilidadD,
                            puu.UtiliadM,
                            Convert.ToInt16(puu.Uti_detalle).ToString()
                            );
                                colocarEnelutimoRegistro();
                            }
                        }



                    }
                }
                utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                calcularTotales();

            }
        }

        private void estableciendo_productos_unicaPre(auxiliares.producto_unica_presentacion pu, DataGridViewRow seleccion,
            auxiliares.productos_mas_presentaciones puu)
        {
            puu.Valido = this.valido;
            pu.Idpresentacion_poroducto = seleccion.Cells[8].Value.ToString();
            if (seleccion.Cells[11].Value.ToString().Equals("Detalle"))
            {
                pu.TipoUtilidad = seleccion.Cells[9].Value.ToString();
            }
            else
            {
                pu.TipoUtilidad = seleccion.Cells[10].Value.ToString();
            }

            pu.Sucursal_producto = seleccion.Cells[0].Value.ToString();
            pu.Codigo = seleccion.Cells[1].Value.ToString();
            pu.lblExis.Text = seleccion.Cells[6].Value.ToString();
            pu.lblNombre.Text = seleccion.Cells[2].Value.ToString();
            pu.lblPres.Text = seleccion.Cells[7].Value.ToString();
            pu.lblPrecio.Text = "$" + seleccion.Cells[5].Value.ToString();
            pu.Precio = seleccion.Cells[5].Value.ToString();
            pu.txtCantidad.Value = 1;
            pu.CantidadInter = "1";

            pu.ShowDialog();

            if (pu.Llenado)
            {
                //si la tabla esta vacia
                if (tabla_articulos.Rows.Count == 0)
                {
                    barraDeprogreso(10);
                    tabla_articulos.Rows.Add(
                    "",
                    pu.Codigo,
                    pu.lblNombre.Text,
                    pu.lblPres.Text,
                    pu.txtCantidad.Value.ToString(),
                    pu.Precio,
                    pu.Total,
                    pu.Idpresentacion_poroducto,
                    pu.Utilidad,
                    "",
                    "1",
                    pu.lblExis.Text,
                    pu.Sucursal_producto,
                    pu.TipoUtilidad,
                    pu.TipoUtilidad,
                    Convert.ToInt16(pu.Uti_detalle).ToString()
                    );

                    Console.WriteLine("estes el tipo: " + Convert.ToInt16(pu.Uti_detalle).ToString());
                    colocarEnelutimoRegistro();
                }
                else
                {
                    //si el articulo no esta repetido
                    if (!productoRepetido(pu.Idpresentacion_poroducto, pu.txtCantidad.Value.ToString()))
                    {
                        barraDeprogreso(10);
                        tabla_articulos.Rows.Add(
                    "",
                    pu.Codigo,
                    pu.lblNombre.Text,
                    pu.lblPres.Text,
                    pu.txtCantidad.Value.ToString(),
                    pu.Precio,
                    pu.Total,
                    pu.Idpresentacion_poroducto,
                    pu.Utilidad,
                    "",
                    "1",
                    pu.lblExis.Text,
                    pu.Sucursal_producto,
                    pu.TipoUtilidad,
                    pu.TipoUtilidad,
                    Convert.ToInt16(puu.Uti_detalle).ToString()
                    );
                        colocarEnelutimoRegistro();
                    }
                }

                utilitarios.cargar_tablas.correlativoTabla(tabla_articulos);
                calcularTotales();
            }
        }

        private void colocarEnelutimoRegistro()
        {
            if (tabla_articulos.Rows.Count != 0)
            {
                tabla_articulos.CurrentCell = tabla_articulos.Rows[tabla_articulos.Rows.Count-1].Cells[4];
            }
        }

        private void btnAgr_Click(object sender, EventArgs e)
        {
            auxiliares.nuevo_producto_simplificado np = new auxiliares.nuevo_producto_simplificado();
            np.txtCodigo.Text = txtBusqueda.Text;
            np.Conexion_remota = false;
            np.ShowDialog();

            if (np.Ingresado)
            {
                cargarTablas();
                colocarFoco();
            }
        }

        private void relog_Tick(object sender, EventArgs e)
        {
            lblrelog.Text = DateTime.Now.ToString();
        }

        private void fecha_actual_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void listaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if(listaClientes.SelectedValue != null)
            {
                clienteSeleccionado();
            }*/
        }

        private void clienteSeleccionado()
        {
            cliente = (DataRowView)listaClientes.SelectedItem;
            txtDireccion.Text = cliente.Row[4].ToString();
            colocarFoco();
        }

        private void btnActualizarInformación_Click(object sender, EventArgs e)
        {
            actualizarCliente();
        }

        private void txtBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            busquedaC = true;
        }

        private void txtBuscarCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                tabla_clientes.Visible = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                    tabla_clientes.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {       
                    if (busquedaC)
                    {
                        tabla_clientes.Focus();
                        colocandoCliente();
                    txtBusqueda.Focus();      
                    }
            }
        }

        private void tabla_clientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void tabla_clientes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (busquedaC)
                    {
                        colocandoCliente();
                        busquedaC = false;
                        txtBusqueda.Focus();
                    }

                }
                catch
                {

                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                busquedaC = false;
                txtBuscarCliente.Text = "";
                txtBuscarCliente.Focus();
                tabla_clientes.Visible = false;
            }
        }

        private void actualizarCliente()
        {
            auxiliares.nuevo_cliente_simple clie = new auxiliares.nuevo_cliente_simple();
            clie.Modificar = true;
            clie.Idcliente = lista[0];
            clie.txtNombres.Text = lista[1];
            clie.txtApellidos.Text = lista[2];
            clie.txtDire.Text = lista[3];
            clie.Genero = lista[4];


            clie.ShowDialog();

            if (clie.Ingresado)
            {
                cargarTablas();
                txtDireccion.Text = clie.txtDire.Text;
                lista.Clear();
                lista.Add(clie.Idcliente);
                lista.Add(clie.txtNombres.Text);
                lista.Add(clie.txtApellidos.Text);
                lista.Add(clie.txtDire.Text);
                lista.Add(clie.listaGenero.SelectedValue.ToString());

                System.Console.Write(clie.listaGenero.SelectedValue.ToString());
                

            }
        }

        private void btnActualizar_Pro_Click(object sender, EventArgs e)
        {
            this.cargarTablas();
            barraDeprogreso(10);    
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            if (busquedaC)
            {
                tabla_clientes.Visible = true;
                tablaC.FiltrarLocalmenteSinContadorRegistros();
                try
                {
                    if (tabla_clientes.Rows.Count != 0)
                    {
                        tabla_clientes.CurrentCell = tabla_clientes.Rows[0].Cells[0];
                    }

                }
                catch
                {

                }
            }
        }

        private void btnAsingarNuevocodigo_Click(object sender, EventArgs e)
        {
            mantenimientos.auxiliares.busqueda_productos bp = new mantenimientos.auxiliares.busqueda_productos();
            bp.Codigo = txtBusqueda.Text;
            bp.ShowDialog();
            if (bp.Listo)
            {
                cargarTablas();
                colocarFoco();
            }
        }

        private void colocarFoco()
        {
            txtBusqueda.Text = "";
            txtBusqueda.Focus();
            busqueda = false;
            tablad.Visible = false;
        }

        private void colocandoCliente()
        {
            if (tabla_clientes.Rows.Count != 0)
            {
                DataGridViewRow seleccion = tabla_clientes.CurrentRow;
                tabla_clientes.Visible = false;
                txtBuscarCliente.Focus();

                lista.Clear();

                lista.Add(seleccion.Cells[3].Value.ToString());
                lista.Add(seleccion.Cells[1].Value.ToString());
                lista.Add(seleccion.Cells[2].Value.ToString());
                lista.Add(seleccion.Cells[5].Value.ToString());
                lista.Add(seleccion.Cells[6].Value.ToString());

                txtDireccion.Text = seleccion.Cells[5].Value.ToString();
                txtBuscarCliente.Text = seleccion.Cells[0].Value.ToString();

                tabla_clientes.Visible = false;


                System.Console.WriteLine(lista[0]);
            }
            else
            {
                nuevoCliente();
            }
            



        }
    }
}

