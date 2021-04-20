using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using conexiones_BD.clases;
using utilitarios;

namespace interfaces.compras
{
    public partial class compras_de_productos : Form
    {
        sessionManager.secion sesion = sessionManager.secion.Instancia;
        cargar_tablas tabla;
        //double ivaa = 0.13;
        string total=null, iva=null;
        bool busqueda = false;
        Dictionary<string, List<presentaciones_productos>> registro = new Dictionary<string, List<presentaciones_productos>>();
        DataGridViewComboBoxColumn columna;
        int tipo_factura = 0;
        Dictionary<string, List<presentaciones_productos>> datos_presentaciones = null;
        List<conexiones_BD.clases.presentaciones_productos> prese = null;
        string total_neto, sub_total, iva_;
        public compras_de_productos()
        {
            InitializeComponent();
            creandoColumnasTabla();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs ee)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, ee, this);
        }

        private void compras_de_productos_Load(object sender, EventArgs e)
        {
            relog.Start();
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            this.cargarListas();
            this.cargarTablas();
            
            columna = tabla_articulos.Columns[4] as DataGridViewComboBoxColumn;

        }

        private void creandoColumnasTabla()
        {
            DataGridViewCellStyle stilo = new DataGridViewCellStyle();
            stilo.Alignment = DataGridViewContentAlignment.MiddleCenter;
            stilo.WrapMode = DataGridViewTriState.True;

            DataGridViewCellStyle stilo2 = new DataGridViewCellStyle();
            stilo2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            stilo2.WrapMode = DataGridViewTriState.True;
            stilo2.BackColor = Color.Silver;

            //celda 0
            DataGridViewTextBoxColumn idsuc = new DataGridViewTextBoxColumn();
            idsuc.Visible = false;

            //celda 1
            DataGridViewTextBoxColumn num = new DataGridViewTextBoxColumn();
            num.HeaderText = "N°";
            num.Width = 50;
            num.DefaultCellStyle = stilo;
            num.ReadOnly = true;

            //celda 2
            DataGridViewTextBoxColumn codi = new DataGridViewTextBoxColumn();
            codi.HeaderText = "Código";
            codi.Width = 115;
            codi.ReadOnly = true;

            //celda 3
            DataGridViewTextBoxColumn nom = new DataGridViewTextBoxColumn();
            nom.HeaderText = "Descripción";
            nom.Width = 300;
            nom.ReadOnly = true;

            //celda 4
            DataGridViewComboBoxColumn prese = new DataGridViewComboBoxColumn();
            prese.HeaderText = "Presentación";
            prese.Width = 150;
            prese.FlatStyle = FlatStyle.Popup;

            //celda 5
            DataGridViewTextBoxColumn canti = new DataGridViewTextBoxColumn();
            canti.HeaderText = "Cantidad";
            canti.Width = 75;
            canti.DefaultCellStyle = stilo;

            //celda 6
            DataGridViewTextBoxColumn preci = new DataGridViewTextBoxColumn();
            preci.HeaderText = "Costo Unitario M";
            preci.Width = 75;
            preci.DefaultCellStyle = stilo2;
            
            //celda 7
            DataGridViewComboBoxColumn utili = new DataGridViewComboBoxColumn();
            utili.HeaderText = "Utilidad M";
            utili.Width = 65;
            utili.FlatStyle = FlatStyle.Popup;
            utili.DefaultCellStyle = stilo;

            //celda 8
            DataGridViewTextBoxColumn preciV = new DataGridViewTextBoxColumn();
            preciV.HeaderText = "Precio Venta M";
            preciV.Width = 75;
            preciV.DefaultCellStyle = stilo;
            
            //celda 9
            DataGridViewTextBoxColumn preciD = new DataGridViewTextBoxColumn();
            preciD.HeaderText = "Costo Unitario D";
            preciD.Width = 75;
            preciD.DefaultCellStyle = stilo2;

            //celda 10
            DataGridViewComboBoxColumn utiliD = new DataGridViewComboBoxColumn();
            utiliD.HeaderText = "Utilidad D";
            utiliD.Width = 65;
            utiliD.FlatStyle = FlatStyle.Popup;
            utiliD.DefaultCellStyle = stilo;

            //celda 11
            DataGridViewTextBoxColumn preciVD = new DataGridViewTextBoxColumn();
            preciVD.HeaderText = "Precio Venta D";
            preciVD.Width = 75;
            preciVD.DefaultCellStyle = stilo;

            //celda 12
            DataGridViewTextBoxColumn iva = new DataGridViewTextBoxColumn();
            iva.HeaderText = "Iva";
            iva.Width = 75;
            iva.DefaultCellStyle = stilo;
            iva.ReadOnly = true;

            //celda 13
            DataGridViewTextBoxColumn total = new DataGridViewTextBoxColumn();
            total.HeaderText = "Total";
            total.Width = 75;
            total.DefaultCellStyle = stilo;
            total.ReadOnly = true;

            //celda 14
            DataGridViewTextBoxColumn can_exis = new DataGridViewTextBoxColumn();
            can_exis.Visible = false;

            //celda 15
            DataGridViewImageColumn modi = new DataGridViewImageColumn();
            modi.HeaderText = "Modifica precios";
            modi.Width = 75;
            modi.Image = Properties.Resources.precio_peque;

            tabla_articulos.Columns.Add(idsuc);
            tabla_articulos.Columns.Add(num);
            tabla_articulos.Columns.Add(codi);
            tabla_articulos.Columns.Add(nom);
            tabla_articulos.Columns.Add(prese);
            tabla_articulos.Columns.Add(canti);
            tabla_articulos.Columns.Add(preci);
            tabla_articulos.Columns.Add(utili);
            tabla_articulos.Columns.Add(preciV);
            tabla_articulos.Columns.Add(preciD);
            tabla_articulos.Columns.Add(utiliD);
            tabla_articulos.Columns.Add(preciVD);
            tabla_articulos.Columns.Add(iva);
            tabla_articulos.Columns.Add(total);
            tabla_articulos.Columns.Add(can_exis);
            tabla_articulos.Columns.Add(modi);

            DataGridViewComboBoxColumn comboboxColumn = tabla_articulos.Columns[7] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn comboboxColumn2 = tabla_articulos.Columns[10] as DataGridViewComboBoxColumn;

            comboboxColumn.DataSource = utilidades.datosTablaMayoreo(false);
            comboboxColumn.DisplayMember = "nombre";
            comboboxColumn.ValueMember = "idutilidad_compra";

            comboboxColumn2.DataSource = utilidades.datosTablaDetalle(false);
            comboboxColumn2.DisplayMember = "nombre";
            comboboxColumn2.ValueMember = "idutilidad_compra";

        }

        private void compras_de_productos_Resize(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void cargarListas()
        {
            cargandoListas.cargarLista(tipos_factura.datosTabla(), listaTipofac, "nombre", "idtipo_factura");
            listaTipofac.SelectedIndex = 2;
            cargandoListas.cargarLista(proveedores.datosTabla(false), listaProveedor, "nombre_proveedor", "idproveedor");
            cargandoListas.cargarLista(usuarios.datosTabla(), listaUsu, "usuario", "idusuario");
            int index=listaUsu.FindStringExact(sesion.Datos[0]);
            listaUsu.SelectedIndex = index;
            cargandoListas.cargarLista(sucursales.datosTabla(false), listaSucursal, "numero_de_sucursal", "idsucursal");
            listaSucursal.SelectedValue = sesion.DatosRegistro[1];
        }

        private void cargarTablas()
        {
            tabla = new cargar_tablas(tablad, txtBusqueda, conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_COMPRA(), "productoCod");
            tabla.cargarSinContadorRegistros();
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            busqueda = true;
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
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (txtBusqueda.TextLength != 0)
                {
                    tablad.Focus();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (txtBusqueda.TextLength != 0)
                {
                    if (busqueda)
                    {
                        try
                        {
                            colocandoProductos();
                            txtBusqueda.Text = "";
                            txtBusqueda.Focus();
                            tablad.Visible = false;
                            busqueda = false;

                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        private void tablad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
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
                        colocandoProductos();
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

        private void colocandoProductos()
        {
            if (!productoRepetidos(tablad.CurrentRow.Cells[0].Value.ToString()))
            {
                tabla_articulos.Rows.Add(
                tablad.CurrentRow.Cells[0].Value.ToString(),
                correl(),
                tablad.CurrentRow.Cells[1].Value.ToString(),
                tablad.CurrentRow.Cells[2].Value.ToString(),
                null,
                0,
                0.0,
                null,
                0.0,
                0.0,
                null,
                0.0,
                0.0,
                0.0,
                0);

                ((DataGridViewComboBoxCell)tabla_articulos.Rows[tabla_articulos.RowCount - 1].Cells[7]).Value = 2;
                ((DataGridViewComboBoxCell)tabla_articulos.Rows[tabla_articulos.RowCount - 1].Cells[10]).Value = 4;

                calcularTotal();
                tabla_articulos.Focus();
                colocarEnelutimoRegistro();


            }
            else
            {
                MessageBox.Show("Este producto ya esta ingresado", "Producto repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private string correl()
        {
            return (tabla_articulos.RowCount + 1).ToString();
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

        private bool productoRepetidos(string idsp)
        {
            bool repetido = false;

            if (tabla_articulos.RowCount != 0)
            {
                foreach (DataGridViewRow fila in tabla_articulos.Rows)
                {
                    if (fila.Cells[0].Value.ToString().Equals(idsp))
                    {
                        repetido = true;
                        break;
                    }
                }
            }
            return repetido;
        }

        private void tabla_articulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla_articulos.Rows.Count!=0)
            {
                if (tabla_articulos.Columns[e.ColumnIndex].Index==4)
                {
                    if (e.RowIndex != -1)
                    {
                        setCellComboBoxItems(tabla_articulos, e.RowIndex, e.ColumnIndex, presentaciones_productos.presentacionesXproducto2(tabla_articulos.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    }   
                }

                if (tabla_articulos.Columns[e.ColumnIndex].Index == 15)
                {
                    if(e.RowIndex != -1)
                    {
                        DataGridViewComboBoxCell celda = (DataGridViewComboBoxCell)tabla_articulos.CurrentRow.Cells[4];

                        if (celda.Value == null || celda.Value.Equals(""))
                        {
                            MessageBox.Show("Por favor ingrese la presentación", "No hay presentación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabla_articulos.CurrentCell = tabla_articulos.CurrentRow.Cells[4];
                        }
                        else
                        {
                            

                            productos.presentaciones_por_producto pre = new productos.presentaciones_por_producto();
                            pre.Conexion_remota = false;
                            pre.Compras = true;
                            pre.Idprepro = celda.Value.ToString();
                            pre.PrecioM = tabla_articulos.CurrentRow.Cells[8].Value.ToString();
                            pre.PrecioD = tabla_articulos.CurrentRow.Cells[11].Value.ToString();
                            pre.Idsp = tabla_articulos.Rows[e.RowIndex].Cells[0].Value.ToString();
                            pre.ShowDialog();

                            if (pre.Prese != null)
                            {
                                if (datos_presentaciones != null)
                                {
                                    try
                                    {
                                        datos_presentaciones.Add(pre.Idsp, pre.Prese);
                                    }
                                    catch
                                    {
                                        datos_presentaciones.Remove(pre.Idsp);
                                        try
                                        {
                                            datos_presentaciones.Add(pre.Idsp, pre.Prese);
                                            Console.WriteLine("Eliminado e ingresado");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                    }
                                }
                                else
                                {
                                    datos_presentaciones = new Dictionary<string, List<presentaciones_productos>>();
                                    datos_presentaciones.Add(pre.Idsp, pre.Prese);
                                }
                            }
                        }
                    }   
                }
            }
        }

        

        private void setCellComboBoxItems(DataGridView dataGrid, int rowIndex, int colIndex, DataTable datos)
        {
            if (datos.Rows.Count != 0)
            {
                DataGridViewComboBoxCell dgvcbc = (DataGridViewComboBoxCell)dataGrid.Rows[rowIndex].Cells[colIndex];
                // You might pass a boolean to determine whether to clear or not.
                dgvcbc.DataSource = datos;
                dgvcbc.DisplayMember = "nombre";
                dgvcbc.ValueMember = "idpresentacion_producto";

                prese = new List<presentaciones_productos>();
                foreach (DataRow fila in datos.Rows)
                {
                    
                    string acti = fila[7].ToString();

                    if (acti.Equals("Activo"))
                    {
                        presentaciones_productos pp = new presentaciones_productos();
                        pp.Idpresentacion_producto = fila[0].ToString();
                        pp.Precio = fila[4].ToString();
                        prese.Add(pp);
                    }
                }

                if (datos_presentaciones != null)
                {
                    try
                    {
                        datos_presentaciones.Add(tabla_articulos.CurrentRow.Cells[0].Value.ToString(), prese);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    try
                    {
                        datos_presentaciones = new Dictionary<string, List<presentaciones_productos>>();
                        datos_presentaciones.Add(tabla_articulos.CurrentRow.Cells[0].Value.ToString(), prese);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("No se encontraron presentaciones para este producto", "No hay presentaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private bool validar()
        {
            bool valido = false;
            error.Clear();
            string mensaje = "No puedes dejar en blanco este campo";

            if (listaTipofac.SelectedIndex == -1)
            {
                valido = true;
                error.SetError(listaTipofac, mensaje);
            }
            if (listaProveedor.SelectedIndex == -1)
            {
                valido = true;
                error.SetError(listaProveedor, mensaje);
            }
            if (txtNumeroFac.TextLength==0)
            {
                valido = true;
                error.SetError(txtNumeroFac, mensaje);
            }

            if (tabla_articulos.RowCount == 0)
            {
                valido = true;
                error.SetError(tabla_articulos, "Tienes que agregar almenos un producto");
            }
            else
            {
                foreach (DataGridViewRow fila in tabla_articulos.Rows)
                {
                    if (fila.Cells[5].Value.ToString().Equals("0"))
                    {
                        valido = true;
                        DataGridViewCellStyle stilo = new DataGridViewCellStyle();
                        stilo.SelectionBackColor = Color.OrangeRed;
                        tabla_articulos.DefaultCellStyle = stilo;
                        tabla_articulos.CurrentCell = tabla_articulos.Rows[fila.Index].Cells[5];
                        MessageBox.Show("Una o mas cantidades estan a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    if (fila.Cells[6].Value.ToString().Equals("0"))
                    {
                        valido = true;
                        DataGridViewCellStyle stilo = new DataGridViewCellStyle();
                        stilo.SelectionBackColor = Color.OrangeRed;
                        tabla_articulos.DefaultCellStyle = stilo;
                        tabla_articulos.CurrentCell = tabla_articulos.Rows[fila.Index].Cells[6];
                        MessageBox.Show("Una o mas cantidades estan a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    if (fila.Cells[9].Value.ToString().Equals("0"))
                    {
                        valido = true;
                        DataGridViewCellStyle stilo = new DataGridViewCellStyle();
                        stilo.SelectionBackColor = Color.OrangeRed;
                        tabla_articulos.DefaultCellStyle = stilo;
                        tabla_articulos.CurrentCell = tabla_articulos.Rows[fila.Index].Cells[9];
                        MessageBox.Show("Una o mas cantidades estan a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
  
            return valido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                //ingresandoDatos();
            }
        }

        private List<conexiones_BD.clases.compras.detalles_compras> generarDetallesProductos()
        {
            List<conexiones_BD.clases.compras.detalles_compras> dc = new List<conexiones_BD.clases.compras.detalles_compras>();
            foreach(DataGridViewRow fila in tabla_articulos.Rows)
            {
                dc.Add(
                    new conexiones_BD.clases.compras.detalles_compras(fila.Cells[12].Value.ToString(),
                    (Convert.ToInt32(fila.Cells[4].Value.ToString()) * Convert.ToInt32(fila.Cells[11].Value.ToString())).ToString(),
                    fila.Cells[5].Value.ToString(),
                    fila.Cells[6].Value.ToString(),
                    fila.Cells[7].Value.ToString(),
                    fila.Cells[9].Value.ToString(),
                    fila.Cells[10].Value.ToString(),
                    "0",
                    fila.Cells[14].Value.ToString(),
                    fila.Cells[13].Value.ToString(),
                    fila.Cells[15].Value.ToString(),
                    fila.Cells[16].Value.ToString(),
                    fila.Cells[4].Value.ToString(),
                    fila.Cells[17].Value.ToString(),
                    fila.Cells[12].Value.ToString()
                    )
                    );
            }

            return dc;
        }

        private void ingresandoDatos()
        {
            maneja_fechas fech = new maneja_fechas();
            conexiones_BD.clases.compras.facturas_compras fc = new conexiones_BD.clases.compras.facturas_compras(
                txtNumeroFac.Text,
                listaTipofac.SelectedValue.ToString(),
                listaUsu.SelectedValue.ToString(),
                "prueba",
                iva,
                "0.0",
                total,
                fech.fechaMysql(fechaFactura),
                listaProveedor.SelectedValue.ToString());

            conexiones_BD.clases.compras.compras c = new conexiones_BD.clases.compras.compras(
                "0",
                listaSucursal.SelectedValue.ToString(),
                fech.fechaMysql(fechaActual),
                "1",
                sesion.Idcaja);

            conexiones_BD.operaciones op = new conexiones_BD.operaciones();

            if (op.transaccionComprarProdu(fc,c,this.generarDetallesProductos(),registro)>0)
            {
                MessageBox.Show("La compra se ingreso correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fechaActual.Value = DateTime.Now;
                registro = new Dictionary<string, List<presentaciones_productos>>();
                tabla_articulos.Rows.Clear();
                cargarTablas();
                txtNumeroFac.Text = "";
                listaProveedor.SelectedIndex = -1;

            }else
            {
                MessageBox.Show("La compra no se pudo ingresar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            
        }

        private void calcularTotal()
        {
            if (tabla_articulos.RowCount!=0)
            {
                if (listaTipofac.SelectedIndex == 2)
                {
                    double precio = 0.0;
                    double iva = 0.0;
                    foreach (DataGridViewRow fila in tabla_articulos.Rows)
                    {
                        precio += Convert.ToDouble(fila.Cells[13].Value);
                        iva += Convert.ToDouble(fila.Cells[12].Value);
                    }

                    lblCantidad_de_articulos.Text = "Cantidad de articulos " + tabla_articulos.Rows.Count;
                    lblSubt.Text = "$ " + precio.ToString();
                    sub_total = precio.ToString();
                    lblIva.Text = "$ " + iva.ToString();
                    iva_ = iva.ToString();
                    lblTotal.Text = "$ " + (precio + iva).ToString();
                    total_neto = (precio + iva).ToString();
                }
                else
                {
                    double precio = 0.0;
                    double iva = 0.0;
                    foreach (DataGridViewRow fila in tabla_articulos.Rows)
                    {
                        precio += Convert.ToDouble(fila.Cells[13].Value);
                    }

                    lblCantidad_de_articulos.Text = "Cantidad de articulos " + tabla_articulos.Rows.Count;
                    lblSubt.Text = "$ " + precio.ToString();
                    sub_total = precio.ToString();
                    lblIva.Text = "$ " + iva.ToString();
                    iva_ = iva.ToString();
                    lblTotal.Text = "$ " + (precio + iva).ToString();
                    total_neto = (precio + iva).ToString();
                }
                
            }
        }

        private void tabla_articulos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.RowIndex);
        }

        private void tabla_articulos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (tabla_articulos.Rows.Count != 0)
                {
                    if (tabla_articulos.CurrentCell.ColumnIndex == 3)
                    {
                        if (MessageBox.Show("¿Desea quitar este producto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        {
                            barraDeprogreso(10);
                            try
                            {
                                if (datos_presentaciones != null)
                                {
                                    datos_presentaciones.Remove(tabla_articulos.CurrentRow.Cells[0].Value.ToString());
                                }  
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            tabla_articulos.Rows.RemoveAt(tabla_articulos.CurrentRow.Index);
                            Console.WriteLine("Presentaciones que hay: "+datos_presentaciones.Count);
                        }
                    } 
                }
            }
            catch
            {

            }
        }

        private void relog_Tick(object sender, EventArgs e)
        {
            lblrelog.Text = DateTime.Now.ToString();
        }

        private void tabla_articulos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla_articulos.RowCount != 0)
            {
                switch (tabla_articulos.Columns[e.ColumnIndex].Index)
                {
                    
                    case 5:
                        {
                            DataGridViewComboBoxCell prese = tabla_articulos.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell;
                            if (!tabla_articulos.CurrentRow.Cells[6].Value.Equals("0"))
                            {
                                foreach (DataRowView it in prese.Items)
                                {
                                    if ((int)prese.Value == (int)it[0])
                                    {
                                        Int32 numero = (int)it[3];
                                        Double canti = Convert.ToDouble(tabla_articulos.CurrentRow.Cells[5].Value);
                                        tabla_articulos.CurrentRow.Cells[13].Value = Math.Round((canti * Convert.ToDouble(tabla_articulos.CurrentRow.Cells[6].Value)), 2);
                                        tabla_articulos.CurrentRow.Cells[14].Value = (numero * canti);

                                        Double total = Math.Round((canti * Convert.ToDouble(tabla_articulos.CurrentRow.Cells[6].Value)), 2);
                                        Double iva = Math.Round(((total / 1.13) * 0.13), 2);


                                        if (listaTipofac.SelectedIndex == 2)
                                        {
                                            tabla_articulos.CurrentRow.Cells[12].Value = iva;
                                            tabla_articulos.CurrentRow.Cells[13].Value = Math.Round((total / 1.13), 2);
                                            tabla_articulos.CurrentRow.Cells[14].Value = (numero * canti);
                                        }
                                        else
                                        {
                                            tabla_articulos.CurrentRow.Cells[12].Value = 0;
                                            tabla_articulos.CurrentRow.Cells[13].Value = total;
                                            tabla_articulos.CurrentRow.Cells[14].Value = (numero * canti);
                                        }

                                        calcularTotal();
                                    }
                                }
                            }
                            
                            break;
                        }
                    case 6:
                        {
                            DataGridViewComboBoxCell combo = tabla_articulos.Rows[e.RowIndex].Cells[7] as DataGridViewComboBoxCell;
                            DataGridViewComboBoxCell prese = tabla_articulos.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell;

                            foreach (DataRowView item in combo.Items)
                            {
                                if ((int)combo.Value == (int)item[0])
                                {
                                    Double uti = Convert.ToDouble(item[3]);
                                    DataGridViewTextBoxCell COM = tabla_articulos.Rows[e.RowIndex].Cells[6] as DataGridViewTextBoxCell;
                                    DataGridViewTextBoxCell PVM = tabla_articulos.Rows[e.RowIndex].Cells[8] as DataGridViewTextBoxCell;

                                    PVM.Value = Math.Round((Convert.ToDouble(COM.Value) / uti), 2);
                                    
                                }
                            }

                            foreach(DataRowView it in prese.Items)
                            {
                                if ((int)prese.Value == (int)it[0])
                                {
                                    Int32 numero = (int)it[3];
                                    Double canti = Convert.ToDouble(tabla_articulos.CurrentRow.Cells[5].Value);
                                    tabla_articulos.CurrentRow.Cells[13].Value = Math.Round((canti * Convert.ToDouble(tabla_articulos.CurrentRow.Cells[6].Value)), 2);
                                    tabla_articulos.CurrentRow.Cells[14].Value = (numero * canti);

                                    Double total = Math.Round((canti * Convert.ToDouble(tabla_articulos.CurrentRow.Cells[6].Value)), 2);
                                    Double iva = Math.Round(((total / 1.13) * 0.13), 2);


                                    if (listaTipofac.SelectedIndex == 2)
                                    {
                                        tabla_articulos.CurrentRow.Cells[12].Value = iva;
                                        tabla_articulos.CurrentRow.Cells[13].Value = Math.Round((total / 1.13), 2);
                                        tabla_articulos.CurrentRow.Cells[14].Value = (numero * canti);
                                    }
                                    else
                                    {
                                        tabla_articulos.CurrentRow.Cells[12].Value = 0;
                                        tabla_articulos.CurrentRow.Cells[13].Value = total;
                                        tabla_articulos.CurrentRow.Cells[14].Value = (numero * canti);
                                    }

                                    calcularTotal();
                                }
                            }
                            break;
                        }

                    case 7:
                        {
                            DataGridViewComboBoxCell combo = tabla_articulos.Rows[e.RowIndex].Cells[7] as DataGridViewComboBoxCell;
                            foreach (DataRowView item in combo.Items)
                            {
                                if ((int)combo.Value == (int)item[0])
                                {
                                    Double uti = Convert.ToDouble(item[3]);
                                    DataGridViewTextBoxCell COM = tabla_articulos.Rows[e.RowIndex].Cells[6] as DataGridViewTextBoxCell;
                                    DataGridViewTextBoxCell PVM = tabla_articulos.Rows[e.RowIndex].Cells[8] as DataGridViewTextBoxCell;

                                    PVM.Value = Math.Round((Convert.ToDouble(COM.Value) / uti), 2);
                                    
                                    
                                }
                            }

                            
                            break;
                        }

                    case 9:
                        {
                            DataGridViewComboBoxCell combo = tabla_articulos.Rows[e.RowIndex].Cells[10] as DataGridViewComboBoxCell;
                            foreach (DataRowView item in combo.Items)
                            {
                                if ((int)combo.Value == (int)item[0])
                                {
                                    Double uti = Convert.ToDouble(item[3]);
                                    DataGridViewTextBoxCell COM = tabla_articulos.Rows[e.RowIndex].Cells[9] as DataGridViewTextBoxCell;
                                    DataGridViewTextBoxCell PVM = tabla_articulos.Rows[e.RowIndex].Cells[11] as DataGridViewTextBoxCell;

                                    PVM.Value = Math.Round((Convert.ToDouble(COM.Value) / uti), 2);
                                }
                            }
                            break;
                        }

                    case 10:
                        {
                            DataGridViewComboBoxCell combo = tabla_articulos.Rows[e.RowIndex].Cells[10] as DataGridViewComboBoxCell;
                            foreach (DataRowView item in combo.Items)
                            {
                                if ((int)combo.Value == (int)item[0])
                                {
                                    Double uti = Convert.ToDouble(item[3]);
                                    DataGridViewTextBoxCell COM = tabla_articulos.Rows[e.RowIndex].Cells[9] as DataGridViewTextBoxCell;
                                    DataGridViewTextBoxCell PVM = tabla_articulos.Rows[e.RowIndex].Cells[11] as DataGridViewTextBoxCell;

                                    PVM.Value = Math.Round((Convert.ToDouble(COM.Value) / uti), 2);
                                }
                            }
                            break;
                        }
                }
            }
            
        }

        private void recalcular_totales()
        {
            if (tabla_articulos.RowCount != 0)
            {
                double total = 0.0;
                double iva = 0.0;
                double cantidad = 0.0;
                double precio = 0.0;
                if (listaTipofac.SelectedIndex == 2)
                {
                    foreach(DataGridViewRow fila in tabla_articulos.Rows)
                    {
                        cantidad = Convert.ToDouble(fila.Cells[5].Value);
                        precio = Convert.ToDouble(fila.Cells[6].Value);

                        total = Math.Round(((cantidad * precio)/1.13), 2, MidpointRounding.AwayFromZero);
                        iva = Math.Round((((cantidad * precio) / 1.13) * 0.13), 2, MidpointRounding.AwayFromZero);

                        fila.Cells[12].Value = iva;
                        fila.Cells[13].Value = total;
                    }
                    calcularTotal();
                }
                else
                {
                    foreach (DataGridViewRow fila in tabla_articulos.Rows)
                    {
                        cantidad = Convert.ToDouble(fila.Cells[5].Value);
                        precio = Convert.ToDouble(fila.Cells[6].Value);

                        total = Math.Round((cantidad * precio), 2);
                        fila.Cells[12].Value = iva;
                        fila.Cells[13].Value = total;
                    }
                    calcularTotal();
                }
            }
        }

        private void colocarEnelutimoRegistro()
        {
            if (tabla_articulos.Rows.Count != 0)
            {
                tabla_articulos.CurrentCell = tabla_articulos.Rows[tabla_articulos.Rows.Count - 1].Cells[4];
            }
        }

        private void tabla_articulos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewColumn col = tabla_articulos.Columns[tabla_articulos.CurrentCell.ColumnIndex];
            if (col is DataGridViewComboBoxColumn)
            {
                tabla_articulos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tabla_articulos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5:
                    {
                        validando_valores(e);
                        break;
                    }
                case 6:
                    {
                        validando_valores(e);
                        break;
                    }
                case 8:
                    {
                        validando_valores(e);
                        break;
                    }
                case 9:
                    {
                        validando_valores(e);
                        break;
                    }
                case 11:
                    {
                        validando_valores(e);
                        break;
                    }
            }
            
        }

        private void validando_valores(DataGridViewCellValidatingEventArgs e)
        {
            if (!es_numero(e.FormattedValue.ToString()))
            {
                e.Cancel = true;
                MessageBox.Show("Esta celda no acepta letras", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabla_articulos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5:
                    {
                        DataGridViewComboBoxCell combo = tabla_articulos.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell;
                        if (combo.Value==null || combo.Value.Equals(""))
                        {
                            MessageBox.Show("Por favor ingrese la presentación", "No hay presentación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabla_articulos.CurrentCell = tabla_articulos.CurrentRow.Cells[4];
                        }
                        break;
                    }
                case 6:
                    {
                        DataGridViewComboBoxCell combo = tabla_articulos.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell;
                        if (combo.Value == null || combo.Value.Equals(""))
                        {
                            MessageBox.Show("Por favor ingrese la presentación", "No hay presentación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabla_articulos.CurrentCell = tabla_articulos.CurrentRow.Cells[4];
                        }
                        break;
                    }
                case 8:
                    {
                        DataGridViewComboBoxCell combo = tabla_articulos.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell;
                        if (combo.Value == null || combo.Value.Equals(""))
                        {
                            MessageBox.Show("Por favor ingrese la presentación", "No hay presentación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabla_articulos.CurrentCell = tabla_articulos.CurrentRow.Cells[4];
                        }
                        break;
                    }
                case 9:
                    {
                        DataGridViewComboBoxCell combo = tabla_articulos.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell;
                        if (combo.Value == null || combo.Value.Equals(""))
                        {
                            MessageBox.Show("Por favor ingrese la presentación", "No hay presentación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabla_articulos.CurrentCell = tabla_articulos.CurrentRow.Cells[4];
                        }
                        break;
                    }
                case 11:
                    {
                        DataGridViewComboBoxCell combo = tabla_articulos.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell;
                        if (combo.Value == null || combo.Value.Equals(""))
                        {
                            MessageBox.Show("Por favor ingrese la presentación", "No hay presentación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabla_articulos.CurrentCell = tabla_articulos.CurrentRow.Cells[4];
                        }
                        break;
                    }

            }
            

        }

        private void listaTipofac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabla_articulos.RowCount != 0)
            {
                if (listaTipofac.SelectedIndex != 2)
                {
                    if (MessageBox.Show("Se cambiaran las cantidades de IVA y TOTAL", "Cambios de cantidades", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        recalcular_totales();
                    }
                    else
                    {
                        listaTipofac.SelectedIndex = tipo_factura;
                    }
                }
                else
                {
                    if (MessageBox.Show("Se cambiaran las cantidades de IVA y TOTAL", "Cambios de cantidades", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        recalcular_totales();
                    }
                    else
                    {
                        listaTipofac.SelectedIndex = tipo_factura;
                    }
                }
            }
        }

        private void listaTipofac_Click(object sender, EventArgs e)
        {
            this.tipo_factura = listaTipofac.SelectedIndex;
        }

        private void btnReimprimir_Click_1(object sender, EventArgs e)
        {
            
        }

        private void tabla_articulos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                tabla_articulos.Cursor = Cursors.Hand;
            }
            else
            {
                tabla_articulos.Cursor = Cursors.Default;
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!validar())
            {
                DataGridViewCellStyle stilo = new DataGridViewCellStyle();
                stilo.SelectionBackColor = SystemColors.Highlight;
                tabla_articulos.DefaultCellStyle = stilo;

                if (MessageBox.Show("¿Deseas ingresar los datos de esta compra?\nTen en cuenta que los precios se definiran en base a las utilidades.", "Ingresar compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conexiones_BD.operaciones op = new conexiones_BD.operaciones();
                    op.Conexion_remota = false;

                    if(op.transaccionComprarProdu(creando_factura(), creando_compra(), creando_detalles_factura(), datos_presentaciones) > 0)
                    {
                        MessageBox.Show("Se ingresaron los datos", "Compra ingresada con exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabla_articulos.Rows.Clear();
                        fechaFactura.Value = DateTime.Now;
                        listaProveedor.SelectedIndex = -1;
                        txtNumeroFac.Text = "";
                        lblSubt.Text = "0.0";
                        lblIva.Text = "0.0";
                        lblDescuento.Text = "0.0";
                        lblTotal.Text = "0.0";
                    }
                    else
                    {
                        MessageBox.Show("No se guardaron los datos", "Ocurrio algún error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabla_articulos.Rows.Clear();
            fechaActual.Value = DateTime.Now;
            listaProveedor.SelectedIndex = -1;
            txtNumeroFac.Text = "";
            if (!tabla_articulos.Enabled)
            {
                tabla_articulos.Enabled = true;
            }
            lblSubt.Text = "0.0";
            lblIva.Text = "0.0";
            lblDescuento.Text = "0.0";
            lblTotal.Text = "0.0";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_compras com = new busqueda_compras();
            com.ShowDialog();
        }

        private conexiones_BD.clases.compras.facturas_compras creando_factura()
        {
            conexiones_BD.clases.compras.facturas_compras fact = new conexiones_BD.clases.compras.facturas_compras(
                txtNumeroFac.Text.ToString(),
                listaTipofac.SelectedValue.ToString(),
                listaUsu.SelectedValue.ToString(),
                total_neto,
                iva_,
                "0.0",
                sub_total,
                fechaFactura.Value.ToString("yyyy-MM-dd hh:mm:ss"),
                listaProveedor.SelectedValue.ToString()
                );

            return fact;
        }

        private conexiones_BD.clases.compras.compras creando_compra()
        {
            conexiones_BD.clases.compras.compras compra = new conexiones_BD.clases.compras.compras(
                "",
                listaSucursal.SelectedValue.ToString(),
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                "1",
                sesion.Idcaja
                );

            return compra;
        }

        private List<conexiones_BD.clases.compras.detalles_compras> creando_detalles_factura()
        {
            List<conexiones_BD.clases.compras.detalles_compras> detalles = new List<conexiones_BD.clases.compras.detalles_compras>();
            foreach(DataGridViewRow fila in tabla_articulos.Rows)
            {
                Double utiM=0.0, utiD=0.0;
                Int32 canti=0;
                DataGridViewComboBoxCell combo = fila.Cells[7] as DataGridViewComboBoxCell;
                foreach (DataRowView item in combo.Items)
                {
                    if ((int)combo.Value == (int)item[0])
                    {
                        utiM = Convert.ToDouble(item[3]);
                    }
                }

                DataGridViewComboBoxCell combo1 = fila.Cells[10] as DataGridViewComboBoxCell;
                foreach (DataRowView item in combo1.Items)
                {
                    if ((int)combo1.Value == (int)item[0])
                    {
                         utiD = Convert.ToDouble(item[3]);
                    }
                }

                DataGridViewComboBoxCell prese = fila.Cells[4] as DataGridViewComboBoxCell;
                foreach (DataRowView item in prese.Items)
                {
                    if ((int)prese.Value == (int)item[0])
                    {
                        canti = Convert.ToInt32(item[3]);
                    }
                }

                detalles.Add(new conexiones_BD.clases.compras.detalles_compras(
                    fila.Cells[0].Value.ToString(),
                    fila.Cells[5].Value.ToString(),
                    fila.Cells[6].Value.ToString(),
                    fila.Cells[9].Value.ToString(),
                    sub_total,
                    utiM.ToString(),
                    utiD.ToString(),
                    "",
                    combo.Value.ToString(),
                    combo1.Value.ToString(),
                    fila.Cells[8].Value.ToString(),
                    fila.Cells[11].Value.ToString(),
                    canti.ToString(),
                    prese.Value.ToString(),
                    fila.Cells[12].Value.ToString()
                    ));
            }

            return detalles;
        }



        private bool es_numero(string num)
        {
            try
            {
                Convert.ToDouble(num);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
