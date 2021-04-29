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

namespace interfaces.productos
{
    public partial class presentaciones_por_producto : Form
    {
        private bool conexion_remota = false;
        private string idsp;
        utilitarios.cargar_tablas tabla;
        int presenta_anterior, tipo_anterior, cantidad_presentaciones;
        string canti_anterior, precio_anterior, idprepro, precioM, precioD;
        private bool valores_cargados, prio_anterior, esta_anterior, colocar_anterior, tipo_pre = false, compras=false;
        conexiones_BD.clases.presentaciones_productos pp;
        List<conexiones_BD.clases.presentaciones_productos> prese = null;
        public presentaciones_por_producto()
        {
            InitializeComponent();
        }

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }
        public string Idsp { get => idsp; set => idsp = value; }
        public int Cantidad_presentaciones { get => cantidad_presentaciones; set => cantidad_presentaciones = value; }
        public bool Compras { get => compras; set => compras = value; }
        public string Idprepro { get => idprepro; set => idprepro = value; }
        public string PrecioM { get => precioM; set => precioM = value; }
        public string PrecioD { get => precioD; set => precioD = value; }
        public List<presentaciones_productos> Prese { get => prese; set => prese = value; }

        private void cerrar_Click(object sender, EventArgs e)
        {
            cantidad_presentaciones = tabla_presentaciones.RowCount;
            if (tabla_presentaciones.RowCount != 0)
            {
                prese = new List<presentaciones_productos>();
                foreach (DataGridViewRow fila in tabla_presentaciones.Rows)
                {
                    DataGridViewCheckBoxCell acti = fila.Cells[7] as DataGridViewCheckBoxCell; 
                    if ((bool)acti.Value)
                    {
                        presentaciones_productos pp = new presentaciones_productos();
                        pp.Idpresentacion_producto = fila.Cells[0].Value.ToString();
                        pp.Precio = fila.Cells[4].Value.ToString();
                        prese.Add(pp);
                    } 
                }
            }

            this.Close();
        }

        private List<DataTable> cargandoDatos()
        {
            List<DataTable> datos = new List<DataTable>();
            datos.Add(conexiones_BD.clases.presentaciones_productos.presentacionesXproducto(idsp, conexion_remota));
            datos.Add(conexiones_BD.clases.presentaciones.datosTabla(conexion_remota));
            datos.Add(conexiones_BD.clases.tipo_compra.datosTabla(conexion_remota));

            return datos;
        }

        private void presentaciones_por_producto_Load(object sender, EventArgs e)
        {
            if (!conexion_remota)
            {
                btnAgregar.Visible = true;
                btnEliminar.Visible = true;
            }

            recargaDatos();
            valores_cargados = true;
            colocando_datos();

            if (compras)
            {
                List<Int32> listaM = new List<int>();
                List<Int32> listaD = new List<int>();

                foreach(DataGridViewRow fila in tabla_presentaciones.Rows)
                {
                    DataGridViewComboBoxCell celda = fila.Cells[5] as DataGridViewComboBoxCell;
                    DataGridViewCheckBoxCell acti = fila.Cells[7] as DataGridViewCheckBoxCell;

                    if ((bool)acti.Value)
                    {
                        if (celda.Value.ToString().Equals("1"))
                        {
                            listaM.Add((Int32)fila.Cells[3].Value);
                        }
                        else
                        {
                            listaD.Add((Int32)fila.Cells[3].Value);
                        }
                    }
                }

                listaM.Sort();
                listaD.Sort();

                foreach (DataGridViewRow fila in tabla_presentaciones.Rows)
                {
                    DataGridViewComboBoxCell celda = fila.Cells[5] as DataGridViewComboBoxCell;
                    DataGridViewCheckBoxCell acti = fila.Cells[7] as DataGridViewCheckBoxCell;
                    if ((bool)acti.Value)
                    {
                        if (celda.Value.ToString().Equals("1"))
                        {
                            fila.Cells[4].Value = Math.Round(((int)listaM[listaM.Count - 1] / (int)fila.Cells[3].Value) * Convert.ToDouble(precioM), 2);
                        }
                        else
                        {
                            fila.Cells[4].Value = Math.Round(Convert.ToDouble(precioD) / ((int)listaD[listaD.Count - 1] / (int)fila.Cells[3].Value) , 2);
                        }
                    }

                     if (fila.Cells[0].Value.ToString().Equals(Idprepro))
                     {
                         fila.Cells[4].Value = PrecioM;
                     }
                }
            }
        }

        private void recargaDatos()
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            DataGridViewComboBoxColumn comboboxColumn = tabla_presentaciones.Columns[2] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn comboboxColumn2 = tabla_presentaciones.Columns[5] as DataGridViewComboBoxColumn;

            using (espera_datos.splash_espera es = new espera_datos.splash_espera())
            {
                es.Funcion = cargandoDatos;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    comboboxColumn.DataSource = es.Datos_varios[1];
                    comboboxColumn.DisplayMember = "nombre_presentacion";
                    comboboxColumn.ValueMember = "idpresentacion";

                    comboboxColumn2.DataSource = es.Datos_varios[2];
                    comboboxColumn2.DisplayMember = "nombre";
                    comboboxColumn2.ValueMember = "idtipo_compra";

                    tabla = new utilitarios.cargar_tablas(tabla_presentaciones, new TextBox(), es.Datos_varios[0], "nombre_presentacion");
                    tabla.cargarSinContadorRegistros();
                }
            }
        }

        private void colocando_datos()
        {
            if (tabla_presentaciones.DataBindings != null)
            {
                foreach (DataGridViewRow filaa in tabla_presentaciones.Rows)
                {
                    int prese=(int)filaa.Cells[1].Value;
                    int tipo = 0;
                    if (filaa.Cells[8].Value.ToString().Equals("Detalle"))
                    {
                        tipo = 3;
                    }
                    else
                    {
                        tipo = 1;
                    }

                    /*Colocando la prioridad si tiene*/
                    int priori = (int)filaa.Cells[9].Value;
                    Console.WriteLine(priori);
                    /*Colocando el estado si tiene*/
                    string estado = filaa.Cells[10].Value.ToString();
                    /*Colocando el tipo de precio*/
                    string tp = filaa.Cells[11].Value.ToString();

                    foreach (DataRowView item in ((DataGridViewComboBoxCell)filaa.Cells[2]).Items)
                    {
                        if ((int)item[0] == prese)
                        {
                            ((DataGridViewComboBoxCell)filaa.Cells[2]).Value = item[0];
                        }
                    }
                    
                    foreach (DataRowView item in ((DataGridViewComboBoxCell)filaa.Cells[5]).Items)
                    {
                        if ((int)item[0] == tipo)
                        {
                            ((DataGridViewComboBoxCell)filaa.Cells[5]).Value = item[0];
                        }
                    }

                    if (priori==2)
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[6]).Value = false;
                    }
                    else
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[6]).Value = true;
                    }

                    /*Colocando si es activo*/
                    if (estado.Equals("Activo"))
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[7]).Value = true;
                    }
                    else
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[7]).Value = false;
                        filaa.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Strikeout);
                    }

                    /*Colocando el tipo de precio*/
                    if (tp.Equals("Especial"))
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[12]).Value = true;
                        filaa.DefaultCellStyle.BackColor = Color.FromArgb(229, 115, 115);
                    }
                    else
                    {
                        ((DataGridViewCheckBoxCell)filaa.Cells[12]).Value = false;
                    }
                }
            }
        }

        private void tabla_presentaciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewColumn col = tabla_presentaciones.Columns[tabla_presentaciones.CurrentCell.ColumnIndex];
            if (col is DataGridViewComboBoxColumn)
            {
                tabla_presentaciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void datos_anteriores(int columna, int fila)
        {
            switch (columna)
            {
                case 2:
                    {
                        DataGridViewComboBoxCell celda = tabla_presentaciones.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        presenta_anterior = (int)celda.Value;
                        break;
                    }
                case 3:
                    {
                        canti_anterior = tabla_presentaciones.Rows[fila].Cells[columna].Value.ToString();
                        break;
                    }
                case 4:
                    {
                        precio_anterior = tabla_presentaciones.Rows[fila].Cells[columna].Value.ToString();
                        break;
                    }
                case 5:
                    {
                        DataGridViewComboBoxCell celda = tabla_presentaciones.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        tipo_anterior = (int)celda.Value;
                        break;
                    }
                case 6:
                    {
                        DataGridViewCheckBoxCell cheque = tabla_presentaciones.Rows[fila].Cells[columna] as DataGridViewCheckBoxCell;
                        prio_anterior = (bool)cheque.Value;
                        break;
                    }
                case 7:
                    {
                        DataGridViewCheckBoxCell cheque = tabla_presentaciones.Rows[fila].Cells[columna] as DataGridViewCheckBoxCell;
                        esta_anterior = (bool)cheque.Value;
                        break;
                    }
                case 12:
                    {
                        DataGridViewCheckBoxCell cheque = tabla_presentaciones.Rows[fila].Cells[columna] as DataGridViewCheckBoxCell;
                        tipo_pre = (bool)cheque.Value;
                        break;
                    }  
            }
        }

        private void tabla_presentaciones_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            datos_anteriores(e.ColumnIndex, e.RowIndex);
        }

        private void guardando_datos_de_celdas(int columna, int fila)
        {
            switch (columna)
            {
                case 2:
                    {
                        cargando_objeto(fila);
                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_presentacion;
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
                                    foreach (DataRowView item in ((DataGridViewComboBoxCell)tabla_presentaciones.Rows[fila].Cells[columna]).Items)
                                    {
                                        if ((int)item[0] == presenta_anterior)
                                        {
                                            ((DataGridViewComboBoxCell)tabla_presentaciones.Rows[fila].Cells[columna]).Value = item[0];
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        if (isInt32(tabla_presentaciones.Rows[fila].Cells[columna].Value.ToString()))
                        {
                            cargando_objeto(fila);
                            using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                            {
                                es.Funcion_sentencia = modificando_presentacion;
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
                                        tabla_presentaciones.Rows[fila].Cells[columna].Value = canti_anterior;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El número admitido para esta celda es un entero", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabla_presentaciones.Rows[fila].Cells[columna].Value = canti_anterior;
                        }
                        
                        break;
                    }
                case 4:
                    {
                        cargando_objeto(fila);
                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_presentacion;
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
                                    tabla_presentaciones.Rows[fila].Cells[columna].Value = precio_anterior;
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
                            es.Funcion_sentencia = modificando_presentacion;
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
                                    foreach (DataRowView item in ((DataGridViewComboBoxCell)tabla_presentaciones.Rows[fila].Cells[columna]).Items)
                                    {
                                        if ((int)item[0] == tipo_anterior)
                                        {
                                            ((DataGridViewComboBoxCell)tabla_presentaciones.Rows[fila].Cells[columna]).Value = item[0];
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 6:
                    {
                        if (colocar_anterior)
                        {
                            ((DataGridViewCheckBoxCell)tabla_presentaciones.Rows[fila].Cells[columna]).Value = prio_anterior;
                        }
                        break;
                    }
                case 7:
                    {
                        if (colocar_anterior)
                        {
                            ((DataGridViewCheckBoxCell)tabla_presentaciones.Rows[fila].Cells[columna]).Value = esta_anterior;
                        }
                        break;
                    }
                case 12:
                    {
                        if (colocar_anterior)
                        {
                            ((DataGridViewCheckBoxCell)tabla_presentaciones.Rows[fila].Cells[columna]).Value = tipo_pre;
                        }
                        break;
                    }


            }
        }

        public bool isInt32(String num)
        {
            try
            {
                Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void tabla_presentaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            /*Guardando prioridad*/
            if (tabla_presentaciones.Columns[e.ColumnIndex].Index == 6)
            {
                DataGridViewRow row = tabla_presentaciones.Rows[e.RowIndex];
                DataGridViewCheckBoxCell cellSelecion = row.Cells[6] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    if (MessageBox.Show("¿Deseas quitar la prioridad de esta presentación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pp = new conexiones_BD.clases.presentaciones_productos();
                        pp.Idpresentacion_producto = row.Cells[0].Value.ToString();
                        pp.Prioridad = "2";

                        using(espera_datos.splash_espera es= new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_prioridad;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                colocar_anterior = false;
                                cellSelecion.Value = false;
                            }
                            else
                            {
                                colocar_anterior = true;
                                MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cellSelecion.Value = true;
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_presentaciones.CurrentCell = tabla_presentaciones.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                        cellSelecion.Value = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Deseas dar prioridad a esta presentación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pp = new conexiones_BD.clases.presentaciones_productos();
                        pp.Idpresentacion_producto = row.Cells[0].Value.ToString();
                        pp.Prioridad = "1";

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_prioridad;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                colocar_anterior = false;
                                cellSelecion.Value = true;
                            }
                            else
                            {
                                colocar_anterior = true;
                                MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cellSelecion.Value = false;
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_presentaciones.CurrentCell = tabla_presentaciones.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                        cellSelecion.Value = false;
                    }
                }
            }

            /*Guardando estado*/
            if (tabla_presentaciones.Columns[e.ColumnIndex].Index == 7)
            {
                DataGridViewRow row = tabla_presentaciones.Rows[e.RowIndex];
                DataGridViewCheckBoxCell cellSelecion = row.Cells[7] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    if (MessageBox.Show("¿Deseas desactivar esta presentación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pp = new conexiones_BD.clases.presentaciones_productos();
                        pp.Idpresentacion_producto = row.Cells[0].Value.ToString();
                        pp.Estado = "2";

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_estado;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                colocar_anterior = false;
                                row.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Strikeout);
                                cellSelecion.Value = false;
                            }
                            else
                            {
                                colocar_anterior = true;
                                MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cellSelecion.Value = true;
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_presentaciones.CurrentCell = tabla_presentaciones.Rows[e.RowIndex].Cells[e.ColumnIndex - 1];
                        cellSelecion.Value = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Deseas activar esta presentación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pp = new conexiones_BD.clases.presentaciones_productos();
                        pp.Idpresentacion_producto = row.Cells[0].Value.ToString();
                        pp.Estado = "1";

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_estado;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                colocar_anterior = false;
                                row.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                                cellSelecion.Value = true;
                            }
                            else
                            {
                                colocar_anterior = true;
                                MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cellSelecion.Value = false;
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_presentaciones.CurrentCell = tabla_presentaciones.Rows[e.RowIndex].Cells[e.ColumnIndex - 1];
                        cellSelecion.Value = false;
                    }
                }
            }

            /*Guardando tipo_precio*/
            if (tabla_presentaciones.Columns[e.ColumnIndex].Index == 12)
            {
                DataGridViewRow row = tabla_presentaciones.Rows[e.RowIndex];
                DataGridViewCheckBoxCell cellSelecion = row.Cells[12] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    if (MessageBox.Show("¿Deseas desactivar el precio especial?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pp = new presentaciones_productos();
                        pp.Idpresentacion_producto = row.Cells[0].Value.ToString();
                        pp.Preci_estado = "2";

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_tipo;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                colocar_anterior = false;
                                row.DefaultCellStyle.BackColor = Color.White;
                                cellSelecion.Value = false;
                            }
                            else
                            {
                                colocar_anterior = true;
                                MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cellSelecion.Value = true;
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_presentaciones.CurrentCell = tabla_presentaciones.Rows[e.RowIndex].Cells[e.ColumnIndex - 5];
                        cellSelecion.Value = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Deseas activar el precio especial?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pp = new conexiones_BD.clases.presentaciones_productos();
                        pp.Idpresentacion_producto = row.Cells[0].Value.ToString();
                        pp.Preci_estado = "1";

                        using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                        {
                            es.Funcion_sentencia = modificando_tipo;
                            es.Tipo_operacion = 2;
                            if (es.ShowDialog() == DialogResult.OK)
                            {
                                colocar_anterior = false;
                                row.DefaultCellStyle.BackColor = Color.FromArgb(229, 115, 115);
                                cellSelecion.Value = true;
                            }
                            else
                            {
                                colocar_anterior = true;
                                MessageBox.Show("No se pudo cambiar el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cellSelecion.Value = false;
                            }
                        }
                    }
                    else
                    {
                        colocar_anterior = true;
                        tabla_presentaciones.CurrentCell = tabla_presentaciones.Rows[e.RowIndex].Cells[e.ColumnIndex - 5];
                        cellSelecion.Value = false;
                    }
                }
            }
        }

        private void cargando_objeto(int fila)
        {
            DataGridViewComboBoxCell celda = tabla_presentaciones.Rows[fila].Cells[2] as DataGridViewComboBoxCell;
            DataGridViewComboBoxCell celda2 = tabla_presentaciones.Rows[fila].Cells[5] as DataGridViewComboBoxCell;
            pp = new conexiones_BD.clases.presentaciones_productos();
            pp.Idpresentacion_producto = tabla_presentaciones.Rows[fila].Cells[0].Value.ToString();
            pp.Idpresentacion = celda.Value.ToString();
            pp.Cantidad_unidades= tabla_presentaciones.Rows[fila].Cells[3].Value.ToString();
            pp.Precio= tabla_presentaciones.Rows[fila].Cells[4].Value.ToString();

            if ((int)celda2.Value == 3)
            {
                pp.Tipo = "2";
            }
            else
            {
                pp.Tipo = "1";
            }            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregar_presentacion frm = new agregar_presentacion();
            frm.Nombre_productos = "Nuevo producto";
            frm.Idsuc_producto = idsp;
            frm.Conexion_remota = conexion_remota;
            using (espera_datos.splash_espera es = new espera_datos.splash_espera())
            {
                es.Funcion_recargar = carga_lista_presentaciones;
                es.Tipo_operacion = 1;

                if (es.ShowDialog() == DialogResult.OK)
                {
                    frm.Datos_presentaciones = es.Datos;
                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        recargaDatos();
                        colocando_datos();
                    }
                }
            }
        }

        private DataTable carga_lista_presentaciones()
        {
            return presentaciones.datosTabla(conexion_remota);
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea quitar esta presentación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                try
                {
                    pp = new conexiones_BD.clases.presentaciones_productos(tabla_presentaciones.CurrentRow.Cells[0].Value.ToString());
                    using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                    {
                        es.Funcion_sentencia = eliminar_presentacion;
                        es.Tipo_operacion = 2;
                        if (es.ShowDialog() == DialogResult.OK)
                        {
                            recargaDatos();
                            colocando_datos();
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void tabla_presentaciones_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colocando_datos();
        }

        private int eliminar_presentacion()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;

            return (int)op.insertar(pp.sentenciaEliminar());
        }

        private void tabla_presentaciones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int modificando_presentacion()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(pp.modificar_presentacion_producto());
        }

        private void tabla_presentaciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            guardando_datos_de_celdas(e.ColumnIndex, e.RowIndex);
        }

        private int modificando_prioridad()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(pp.modificar_prioridad());
        }

        private int modificando_estado()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(pp.modificar_estado());
        }

        private int modificando_tipo()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(pp.modificar_tipo_precio());
        }
    }
}
