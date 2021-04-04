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
    public partial class modificacion_de_productos_en_tabla : Form
    {
        utilitarios.cargar_tablas tabla;
        bool conexion_remota=false;
        bool valores_cargados = false;
        string nombre_anterior = "", costo_UM_anterior="", costo_VM_anterior="", costo_UD_anterior, costo_VD_anterior="";
        int uti_m_anterior, uti_d_anterior, existencia_anterior,idmar_anterior, idcateg_anterior, idesta_anterior;
        bool kardex_anterior, estado_anterior, colocar_anterior=false;
        conexiones_BD.clases.productos pro;
        conexiones_BD.clases.sucursales_productos sp;
        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }

        public modificacion_de_productos_en_tabla()
        {
            InitializeComponent();
            
        }
      
        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modificacion_de_productos_en_tabla_Load(object sender, EventArgs e)
        {
            
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            DataGridViewComboBoxColumn comboboxColumn = tabla_productos.Columns[5] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn comboboxColumn2 = tabla_productos.Columns[8] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn comboboxColumn3 = tabla_productos.Columns[12] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn comboboxColumn4 = tabla_productos.Columns[13] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn comboboxColumn5 = tabla_productos.Columns[14] as DataGridViewComboBoxColumn;


            using(espera_datos.splash_espera es=new espera_datos.splash_espera())
            {
                es.Conec_server = true;
                es.Funcion = cargandoDatos;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    comboboxColumn.DataSource = es.Datos_varios[1];
                    comboboxColumn.DisplayMember = "nombre";
                    comboboxColumn.ValueMember = "idutilidad_compra";

                    comboboxColumn2.DataSource = es.Datos_varios[2];
                    comboboxColumn2.DisplayMember = "nombre";
                    comboboxColumn2.ValueMember = "idutilidad_compra";

                    comboboxColumn3.DataSource = es.Datos_varios[3];
                    comboboxColumn3.DisplayMember = "nombre";
                    comboboxColumn3.ValueMember = "idmarca";

                    comboboxColumn4.DataSource = es.Datos_varios[4];
                    comboboxColumn4.DisplayMember = "nombre_categoria";
                    comboboxColumn4.ValueMember = "idcategoria";

                    comboboxColumn5.DataSource = es.Datos_varios[5];
                    comboboxColumn5.DisplayMember = "nombre";
                    comboboxColumn5.ValueMember = "idestante";

                    tabla = new utilitarios.cargar_tablas(tabla_productos, txtBusqueda, es.Datos_varios[0], "productoCod");
                    tabla.cargarSinContadorRegistros();

                    imgServidor.Visible = conexion_remota;
                    btnAgregar.Visible = conexion_remota;
                }
            }
            valores_cargados = true;
            colocando_datos();
            
        }

        private List<DataTable> cargandoDatos()
        {
            List<DataTable> datos = new List<DataTable>();
            datos.Add(conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_PARA_MODIFICACIÓN(conexion_remota));
            datos.Add(conexiones_BD.clases.utilidades.datosTablaMayoreo(conexion_remota));
            datos.Add(conexiones_BD.clases.utilidades.datosTablaDetalle(conexion_remota));
            datos.Add(conexiones_BD.clases.marcas.datosTabla(conexion_remota));
            datos.Add(conexiones_BD.clases.categorias.datosTabla(conexion_remota));
            datos.Add(conexiones_BD.clases.estantes.datosTabla(conexion_remota));
            return datos;
        }

        private DataTable recargandoDatos()
        {
            return conexiones_BD.clases.productos.CARGAR_TABLA_PRODUCTOS_PARA_MODIFICACIÓN(conexion_remota);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.Exception);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            tabla.FiltrarLocalmenteSinContadorRegistros();
            colocando_datos();
        }

        private void colocando_datos()
        {
            if (tabla_productos.DataBindings != null)
            {
                foreach (DataGridViewRow filaa in tabla_productos.Rows)
                {
                    int utiM = (int)filaa.Cells[19].Value;
                    int utiD = (int)filaa.Cells[20].Value;
                    int idmarca = (int)filaa.Cells[21].Value;
                    int idcate = (int)filaa.Cells[22].Value;
                    int idesta = (int)filaa.Cells[23].Value;
                    string kardex = filaa.Cells[24].Value.ToString();
                    string estado = filaa.Cells[25].Value.ToString();

                    foreach (DataRowView item in ((DataGridViewComboBoxCell)filaa.Cells[5]).Items)
                    {
                        if ((int)item[0] == utiM)
                        {
                            ((DataGridViewComboBoxCell)filaa.Cells[5]).Value = item[0];
                        }
                    }

                    foreach (DataRowView item in ((DataGridViewComboBoxCell)filaa.Cells[8]).Items)
                    {
                        if ((int)item[0] == utiD)
                        {
                            ((DataGridViewComboBoxCell)filaa.Cells[8]).Value = item[0];
                        }
                    }

                    foreach (DataRowView item in ((DataGridViewComboBoxCell)filaa.Cells[12]).Items)
                    {
                        if ((int)item[0] == idmarca)
                        {
                            ((DataGridViewComboBoxCell)filaa.Cells[12]).Value = item[0];
                        }
                    }

                    bool busqueda = false;
                    foreach (DataRowView item in ((DataGridViewComboBoxCell)filaa.Cells[13]).Items)
                    {
                        if ((int)item[0] == idcate)
                        {
                            ((DataGridViewComboBoxCell)filaa.Cells[13]).Value = item[0];
                            busqueda = true;
                        }
                    }

                    if (!busqueda)
                    {
                        ((DataGridViewComboBoxCell)filaa.Cells[13]).Value = 62;
                    }

                    foreach (DataRowView item in ((DataGridViewComboBoxCell)filaa.Cells[14]).Items)
                    {
                        if ((int)item[0] == idesta)
                        {
                            ((DataGridViewComboBoxCell)filaa.Cells[14]).Value = item[0];
                        }
                    }

                    if (kardex.Equals("SI"))
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[15]).Value = true;
                    }
                    else
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[15]).Value = false;
                    }

                    if (estado.Equals("Activo"))
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[17]).Value = true;
                    }
                    else
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[17]).Value = false;
                        filaa.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Strikeout);
                    }
                }
            }  
        }

        private void tabla_productos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (valores_cargados)
            {
                if (tabla_productos.Columns[e.ColumnIndex].Index == 5)
                {
                    DataGridViewComboBoxCell combo = tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    foreach (DataRowView item in combo.Items)
                    {
                        if ((int)combo.Value == (int)item[0])
                        {
                            Double uti = Convert.ToDouble(item[3]);
                            DataGridViewTextBoxCell COM = tabla_productos.Rows[e.RowIndex].Cells[4] as DataGridViewTextBoxCell;
                            DataGridViewTextBoxCell PVM = tabla_productos.Rows[e.RowIndex].Cells[6] as DataGridViewTextBoxCell;

                            PVM.Value = Math.Round(((Double)COM.Value / uti), 2);
                        }
                    }
                }

                if (tabla_productos.Columns[e.ColumnIndex].Index == 4)
                {
                    DataGridViewComboBoxCell combo = tabla_productos.Rows[e.RowIndex].Cells[5] as DataGridViewComboBoxCell;
                    foreach (DataRowView item in combo.Items)
                    {
                        if ((int)combo.Value == (int)item[0])
                        {
                            Double uti = Convert.ToDouble(item[3]);
                            DataGridViewTextBoxCell COM = tabla_productos.Rows[e.RowIndex].Cells[4] as DataGridViewTextBoxCell;
                            DataGridViewTextBoxCell PVM = tabla_productos.Rows[e.RowIndex].Cells[6] as DataGridViewTextBoxCell;

                            PVM.Value = Math.Round(((Double)COM.Value / uti), 2);
                        }
                    }
                }

                if (tabla_productos.Columns[e.ColumnIndex].Index == 8)
                {
                    DataGridViewComboBoxCell combo = tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    foreach (DataRowView item in combo.Items)
                    {
                        if ((int)combo.Value == (int)item[0])
                        {
                            Double uti = Convert.ToDouble(item[3]);
                            DataGridViewTextBoxCell COD = tabla_productos.Rows[e.RowIndex].Cells[7] as DataGridViewTextBoxCell;
                            DataGridViewTextBoxCell PVD = tabla_productos.Rows[e.RowIndex].Cells[9] as DataGridViewTextBoxCell;

                            PVD.Value = Math.Round(((Double)COD.Value / uti), 2);
                        }
                    }
                }

                if (tabla_productos.Columns[e.ColumnIndex].Index == 7)
                {
                    DataGridViewComboBoxCell combo = tabla_productos.Rows[e.RowIndex].Cells[8] as DataGridViewComboBoxCell;
                    foreach (DataRowView item in combo.Items)
                    {
                        if ((int)combo.Value == (int)item[0])
                        {
                            Double uti = Convert.ToDouble(item[3]);
                            DataGridViewTextBoxCell COD = tabla_productos.Rows[e.RowIndex].Cells[7] as DataGridViewTextBoxCell;
                            DataGridViewTextBoxCell PVD = tabla_productos.Rows[e.RowIndex].Cells[9] as DataGridViewTextBoxCell;

                            PVD.Value = Math.Round(((Double)COD.Value / uti), 2);
                        }
                    }
                }
            }
        }

        private void tabla_productos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewColumn col = tabla_productos.Columns[tabla_productos.CurrentCell.ColumnIndex];
            if (col is DataGridViewComboBoxColumn)
            {
                    tabla_productos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tabla_productos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            datos_anteriores(e.ColumnIndex, e.RowIndex);
        }

        private void datos_anteriores(int columna, int fila)
        {
            switch (columna)
            {
                case 3:
                    {
                        nombre_anterior = tabla_productos.Rows[fila].Cells[columna].Value.ToString();
                        break;
                    }
                case 4:
                    {
                        costo_UM_anterior = tabla_productos.Rows[fila].Cells[columna].Value.ToString();
                        break;
                    }
                case 5:
                    {
                        DataGridViewComboBoxCell celda = tabla_productos.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        uti_m_anterior = (int)celda.Value;
                        break;
                    }
                case 6:
                    {
                        costo_VM_anterior = tabla_productos.Rows[fila].Cells[columna].Value.ToString();
                        break;
                    }
                case 7:
                    {
                        costo_UD_anterior = tabla_productos.Rows[fila].Cells[columna].Value.ToString();
                        break;
                    }
                case 8:
                    {
                        DataGridViewComboBoxCell celda = tabla_productos.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        uti_d_anterior = (int)celda.Value;
                        break;
                    }
                case 9:
                    {
                        costo_VD_anterior = tabla_productos.Rows[fila].Cells[columna].Value.ToString();
                        break;
                    }
                case 11:
                    {
                        existencia_anterior = Convert.ToInt32(tabla_productos.Rows[fila].Cells[columna].Value.ToString());
                        break;
                    }
                case 12:
                    {
                        DataGridViewComboBoxCell celda = tabla_productos.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        idmar_anterior = (int)celda.Value;
                        break;
                    }
                case 13:
                    {
                        DataGridViewComboBoxCell celda = tabla_productos.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        idcateg_anterior = (int)celda.Value;
                        break;
                    }
                case 14:
                    {
                        DataGridViewComboBoxCell celda = tabla_productos.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        idesta_anterior = (int)celda.Value;
                        break;
                    }
                case 15:
                    {
                        DataGridViewCheckBoxCell cheque = tabla_productos.Rows[fila].Cells[columna] as DataGridViewCheckBoxCell;
                        kardex_anterior = (bool)cheque.Value;
                        break;
                    }
                case 16:
                    {
                        break;
                    }
                case 17:
                    {
                        DataGridViewCheckBoxCell cheque = tabla_productos.Rows[fila].Cells[columna] as DataGridViewCheckBoxCell;
                        estado_anterior = (bool)cheque.Value;
                        break;
                    }
            }
        }

        private void tabla_productos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 || e.ColumnIndex == 18 || e.ColumnIndex==16 || e.ColumnIndex==2 || e.ColumnIndex==11)
            {
                tabla_productos.Cursor = Cursors.Hand;
            }
            else
            {
                tabla_productos.Cursor = Cursors.Default;
            }
        }

        private void tabla_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (tabla_productos.Columns[e.ColumnIndex].Index==15)
            {
                DataGridViewRow row = tabla_productos.Rows[e.RowIndex];
                DataGridViewCheckBoxCell cellSelecion = row.Cells[15] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    if (MessageBox.Show("¿Deseas desactivar el kardex de este producto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sp = new conexiones_BD.clases.sucursales_productos();
                        sp.Idsucursal_producto = row.Cells[1].Value.ToString();
                        sp.Kardex = "2";

                        using(espera_datos.splash_espera es=new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_kardex;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    colocar_anterior = false;
                                }
                                else
                                {
                                    colocar_anterior = true;
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_productos.CurrentCell = tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex+1];
                    }        
                }
                else
                {
                    if (MessageBox.Show("¿Deseas activar el kardex de este producto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sp = new conexiones_BD.clases.sucursales_productos();
                        sp.Idsucursal_producto = row.Cells[1].Value.ToString();
                        sp.Kardex = "1";

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_kardex;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    colocar_anterior = false;
                                }
                                else
                                {
                                    colocar_anterior = true;
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_productos.CurrentCell = tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                    }
                }
            }

            if (tabla_productos.Columns[e.ColumnIndex].Index == 17)
            {
                DataGridViewRow row = tabla_productos.Rows[e.RowIndex];
                DataGridViewCheckBoxCell cellSelecion = row.Cells[17] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    if (MessageBox.Show("¿Deseas desactivar este producto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sp = new conexiones_BD.clases.sucursales_productos();
                        sp.Idsucursal_producto = row.Cells[1].Value.ToString();
                        sp.Estado = "2";

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_estado;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    colocar_anterior = false;
                                    row.DefaultCellStyle.Font= new Font("Times New Roman", 12, FontStyle.Strikeout);
                                    tabla_productos.CurrentCell = tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                                }
                                else
                                {
                                    colocar_anterior = true;
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_productos.CurrentCell = tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Deseas activar este producto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sp = new conexiones_BD.clases.sucursales_productos();
                        sp.Idsucursal_producto = row.Cells[1].Value.ToString();
                        sp.Estado = "1";

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_estado;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    colocar_anterior = false;
                                    row.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                                    tabla_productos.CurrentCell = tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                                }
                                else
                                {
                                    colocar_anterior = true;
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_productos.CurrentCell = tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                    }
                }
            }
        }

        private void tabla_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla_productos.Columns[e.ColumnIndex].Index==2)
            {
                mantenimientos.auxiliares.agregaCodigos codi = new mantenimientos.auxiliares.agregaCodigos();
                codi.Conexion_remota = conexion_remota;
                codi.Idproducto = tabla_productos.Rows[e.RowIndex].Cells[0].Value.ToString();
                codi.ShowDialog();
            }

            if (tabla_productos.Columns[e.ColumnIndex].Index == 10)
            {
                presentaciones_por_producto pre = new presentaciones_por_producto();
                pre.Conexion_remota = conexion_remota;
                pre.Idsp = tabla_productos.Rows[e.RowIndex].Cells[1].Value.ToString();
                pre.ShowDialog();
                tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = pre.Cantidad_presentaciones;
            }

            if (tabla_productos.Columns[e.ColumnIndex].Index == 18)
            {
                proveedores_por_producto pro = new proveedores_por_producto();
                pro.Idproducto= tabla_productos.Rows[e.RowIndex].Cells[0].Value.ToString();
                pro.Conexion_remota = conexion_remota;
                pro.ShowDialog();
                tabla_productos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = pro.Numero_registro;
            }
        }

        private void tabla_productos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colocando_datos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ventas.auxiliares.nuevo_producto_simplificado np = new ventas.auxiliares.nuevo_producto_simplificado();
            np.txtCodigo.Text = txtBusqueda.Text;
            np.Conexion_remota = conexion_remota;
            np.panelTitulo.BackColor = Color.Black;
            np.ShowDialog();
            if (np.Ingresado)
            {
                using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                {
                    es.Funcion_recargar = recargandoDatos;
                    if (es.ShowDialog() == DialogResult.OK)
                    {
                        tabla = new utilitarios.cargar_tablas(tabla_productos, txtBusqueda, es.Datos, "productoCod");
                        tabla.cargarSinContadorRegistros();
                    }
                }
                valores_cargados = true;
                colocando_datos();
            }
        }

        private void tabla_productos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla_productos.Columns[e.ColumnIndex].Index == 11)
            {
                existencias exis = new existencias();
                exis.Conexion_remota = conexion_remota;
                exis.Idsuc = tabla_productos.Rows[e.RowIndex].Cells[1].Value.ToString();
                exis.Cantidad = tabla_productos.Rows[e.RowIndex].Cells[11].Value.ToString();
                exis.ShowDialog();
            }
        }

        private int modificando_estado()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(sp.modificar_estado());
        }

        private int modificando_kardex()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(sp.modificando_kardex());
        }

        private void tabla_productos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            guardando_datos_de_celdas(e.ColumnIndex, e.RowIndex);
        }

        private void guardando_datos_de_celdas(int columna, int fila)
        {
            switch (columna)
            {
                case 3:
                    {
                        if (!nombre_anterior.Equals(tabla_productos.Rows[fila].Cells[columna].Value))
                        {
                            if (MessageBox.Show("¿Deseas cambiar el nombre del producto: " + nombre_anterior + " por: \n" + tabla_productos.Rows[fila].Cells[columna].Value.ToString() + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                pro = new conexiones_BD.clases.productos(tabla_productos.CurrentRow.Cells[0].Value.ToString(), tabla_productos.Rows[fila].Cells[columna].Value.ToString());
                                using (espera_datos.splash_espera es = new espera_datos.splash_espera())
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
                                            tabla_productos.Rows[fila].Cells[columna].Value = nombre_anterior;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                tabla_productos.Rows[fila].Cells[columna].Value = nombre_anterior;
                            }
                        }
                        
                        break;
                    }
                case 4:
                    {
                        cargando_objeto(fila);
                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_utilidades;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tabla_productos.Rows[fila].Cells[columna].Value = costo_UM_anterior;
                                }
                            }
                        }
                        
                        break;
                    }
                case 5:
                    {
                        cargando_objeto(fila);
                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_utilidades;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    foreach (DataRowView item in ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Items)
                                    {
                                        if ((int)item[0] == uti_m_anterior)
                                        {
                                            ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Value = item[0];
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 6:
                    {
                        cargando_objeto(fila);
                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_utilidades;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tabla_productos.Rows[fila].Cells[columna].Value = costo_VM_anterior;
                                }
                            }
                        }
                        break;
                    }
                case 7:
                    {
                        cargando_objeto(fila);
                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_utilidades;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tabla_productos.Rows[fila].Cells[columna].Value = costo_UD_anterior;
                                }
                            }
                        }
                        break;
                    }
                case 8:
                    {
                        cargando_objeto(fila);
                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_utilidades;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    foreach (DataRowView item in ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Items)
                                    {
                                        if ((int)item[0] == uti_d_anterior)
                                        {
                                            ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Value = item[0];
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 9:
                    {
                        cargando_objeto(fila);
                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_utilidades;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tabla_productos.Rows[fila].Cells[columna].Value = costo_VD_anterior;
                                }
                            }
                        }
                        break;
                    }
                case 11:
                    {
                        sp = new conexiones_BD.clases.sucursales_productos(tabla_productos.Rows[fila].Cells[1].Value.ToString(),
                            tabla_productos.Rows[fila].Cells[columna].Value.ToString(), "1");

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_existencias;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tabla_productos.Rows[fila].Cells[columna].Value = existencia_anterior.ToString();
                                }
                            }
                        }


                        break;
                    }
                case 12:
                    {
                        DataGridViewComboBoxCell celda = tabla_productos.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        pro = new conexiones_BD.clases.productos();
                        pro.Idproducto = tabla_productos.Rows[fila].Cells[0].Value.ToString();
                        pro.Idmarca = celda.Value.ToString();

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_marca;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    foreach (DataRowView item in ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Items)
                                    {
                                        if ((int)item[0] == idmar_anterior)
                                        {
                                            ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Value = item[0];
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    }
                case 13:
                    {
                        DataGridViewComboBoxCell celda = tabla_productos.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        pro = new conexiones_BD.clases.productos();
                        pro.Idproducto = tabla_productos.Rows[fila].Cells[0].Value.ToString();
                        pro.Idcategoria = celda.Value.ToString();

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_categoria;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    foreach (DataRowView item in ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Items)
                                    {
                                        if ((int)item[0] == idcateg_anterior)
                                        {
                                            ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Value = item[0];
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 14:
                    {
                        DataGridViewComboBoxCell celda = tabla_productos.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        sp = new conexiones_BD.clases.sucursales_productos();
                        sp.Idsucursal_producto = tabla_productos.Rows[fila].Cells[1].Value.ToString();
                        sp.Idestante = celda.Value.ToString();

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_estante;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                if (es.Resultado > 0)
                                {
                                    //MessageBox.Show("cambio exitoso", "Exíto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    foreach (DataRowView item in ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Items)
                                    {
                                        if ((int)item[0] == idesta_anterior)
                                        {
                                            ((DataGridViewComboBoxCell)tabla_productos.Rows[fila].Cells[columna]).Value = item[0];
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 15:
                    {
                        if (colocar_anterior)
                        {
                            ((DataGridViewCheckBoxCell)tabla_productos.Rows[fila].Cells[columna]).Value=kardex_anterior;
                        }
                        break;
                    }
                case 16:
                    {
                        break;
                    }
                case 17:
                    {
                        if (colocar_anterior)
                        {
                            ((DataGridViewCheckBoxCell)tabla_productos.Rows[fila].Cells[columna]).Value = estado_anterior;
                        }
                        break;
                    }
            }
        }

        private void cargando_objeto(int fila)
        {
            DataGridViewComboBoxCell celda = tabla_productos.Rows[fila].Cells[5] as DataGridViewComboBoxCell;
            DataGridViewComboBoxCell celda2 = tabla_productos.Rows[fila].Cells[8] as DataGridViewComboBoxCell;
            sp = new conexiones_BD.clases.sucursales_productos(tabla_productos.Rows[fila].Cells[1].Value.ToString(),
                celda.Value.ToString(),
                celda2.Value.ToString(),
                tabla_productos.Rows[fila].Cells[9].Value.ToString(),
                tabla_productos.Rows[fila].Cells[7].Value.ToString(),
                tabla_productos.Rows[fila].Cells[6].Value.ToString(),
                tabla_productos.Rows[fila].Cells[4].Value.ToString(), "1");
        }

        private int modificando_existencias()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(sp.modificarExistenciaProducto().ToString());
        }

        private int modificando_utilidades()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(sp.modificarUtilidadesProducto());
        }

        private int modificando_nombre()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(pro.modificando_nombre());
        }

        private int modificando_marca()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(pro.modificando_marca());
        }

        private int modificando_categoria()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(pro.modificando_categoria());
        }

        private int modificando_estante()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(sp.modificando_estante());
        }
    }
}
