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
    public partial class proveedores_por_producto : Form
    {
        private bool conexion_remota = false;
        private string idproducto;
        utilitarios.cargar_tablas tabla;
        private int proveedor_anterior;
        conexiones_BD.clases.proveedores_productos pp;
        int numero_registro = 0;

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }
        public string Idproducto { get => idproducto; set => idproducto = value; }
        public int Numero_registro { get => numero_registro; set => numero_registro = value; }

        public proveedores_por_producto()
        {
            InitializeComponent();
        }

        private void proveedores_por_producto_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);

            if (!conexion_remota)
            {
                btnAgrega.Visible = false;
                btnEliminar.Visible = false;
            }

            DataGridViewComboBoxColumn comboboxColumn = tabla_proveedores.Columns[2] as DataGridViewComboBoxColumn;
            using (espera_datos.splash_espera es = new espera_datos.splash_espera())
            {
                es.Funcion = cargandoDatos;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    comboboxColumn.DataSource = es.Datos_varios[1];
                    comboboxColumn.DisplayMember = "nombre_proveedor";
                    comboboxColumn.ValueMember = "idproveedor";

                    tabla = new utilitarios.cargar_tablas(tabla_proveedores, new TextBox(), es.Datos_varios[0], "nombre_proveedor");
                    tabla.cargarSinContadorRegistros();
                }
            }

            colocando_datos();
        }

        private void datos_anteriores(int columna, int fila)
        {
            switch (columna)
            {
                case 2:
                    {
                        DataGridViewComboBoxCell celda = tabla_proveedores.Rows[fila].Cells[columna] as DataGridViewComboBoxCell;
                        proveedor_anterior = (int)celda.Value;
                        break;
                    }
            }
        }

        private void colocando_datos()
        {
            if (tabla_proveedores.DataBindings != null)
            {
                foreach (DataGridViewRow filaa in tabla_proveedores.Rows)
                {
                    int prese = (int)filaa.Cells[1].Value;  
                    foreach (DataRowView item in ((DataGridViewComboBoxCell)filaa.Cells[2]).Items)
                    {
                        if ((int)item[0] == prese)
                        {
                            ((DataGridViewComboBoxCell)filaa.Cells[2]).Value = item[0];
                        }
                    }
                }
            }
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Numero_registro = tabla_proveedores.RowCount;
        }

        private List<DataTable> cargandoDatos()
        {
            List<DataTable> datos = new List<DataTable>();
            datos.Add(conexiones_BD.clases.proveedores_productos.datosTabla(idproducto, conexion_remota));
            datos.Add(conexiones_BD.clases.proveedores.datosTabla(conexion_remota));
            return datos;
        }

        private void tabla_proveedores_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colocando_datos();
        }

        private void tabla_proveedores_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            datos_anteriores(e.ColumnIndex, e.RowIndex);
        }

        private void guardando_datos_de_celdas(int columna, int fila)
        {
            switch (columna)
            {
                case 2:
                    {
                        if (MessageBox.Show("¿Quieres cambiar este proveedor?", "Cambio de proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cargando_objeto(fila);
                            using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                            {
                                es.Funcion_sentencia = modificando_proveedor;
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
                                        foreach (DataRowView item in ((DataGridViewComboBoxCell)tabla_proveedores.Rows[fila].Cells[columna]).Items)
                                        {
                                            if ((int)item[0] == proveedor_anterior)
                                            {
                                                ((DataGridViewComboBoxCell)tabla_proveedores.Rows[fila].Cells[columna]).Value = item[0];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRowView item in ((DataGridViewComboBoxCell)tabla_proveedores.Rows[fila].Cells[columna]).Items)
                            {
                                if ((int)item[0] == proveedor_anterior)
                                {
                                    ((DataGridViewComboBoxCell)tabla_proveedores.Rows[fila].Cells[columna]).Value = item[0];
                                }
                            }
                        }
                        
                        break;
                    }  
            }
        }

        private void cargando_objeto(int fila)
        {
            DataGridViewComboBoxCell celda = tabla_proveedores.Rows[fila].Cells[2] as DataGridViewComboBoxCell;
            pp = new conexiones_BD.clases.proveedores_productos();
            pp.Idproveedor_producto = tabla_proveedores.Rows[fila].Cells[0].Value.ToString();
            pp.Idproveedor = celda.Value.ToString();
        }

        private int modificando_proveedor()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return op.actualizar(pp.modificar_proveedor());
        }

        private void tabla_proveedores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            guardando_datos_de_celdas(e.ColumnIndex, e.RowIndex);
        }

        private void btnAgrega_Click(object sender, EventArgs e)
        {
            agregar_proveedores frm = new agregar_proveedores();
            frm.Conexion_remota = conexion_remota;
            frm.Idproducto = idproducto;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (espera_datos.splash_espera es = new espera_datos.splash_espera())
                {
                    es.Funcion = cargandoDatos;
                    if (es.ShowDialog() == DialogResult.OK)
                    {
                        tabla = new utilitarios.cargar_tablas(tabla_proveedores, new TextBox(), es.Datos_varios[0], "nombre_proveedor");
                        tabla.cargarSinContadorRegistros();
                    }
                }

                colocando_datos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar este proveedor?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pp = new conexiones_BD.clases.proveedores_productos(tabla_proveedores.CurrentRow.Cells[0].Value.ToString());
                using (espera_datos.splash_espera es= new espera_datos.splash_espera())
                {
                    es.Funcion_sentencia = eliminando_proveedor;
                    es.Tipo_operacion = 2;
                    if (es.ShowDialog() == DialogResult.OK)
                    {
                        using (espera_datos.splash_espera ess = new espera_datos.splash_espera())
                        {
                            ess.Funcion = cargandoDatos;
                            if (ess.ShowDialog() == DialogResult.OK)
                            {

                                tabla = new utilitarios.cargar_tablas(tabla_proveedores, new TextBox(), ess.Datos_varios[0], "nombre_proveedor");
                                tabla.cargarSinContadorRegistros();
                            }
                        }
                        colocando_datos();
                    }
                }
            }
        }

        private int eliminando_proveedor()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;
            return (int)op.insertar(pp.sentenciaEliminar());
        }
    }
}
