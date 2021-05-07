using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace interfaces.productos
{
    public partial class existencias : Form
    {
        private bool conexion_remota = false;
        private string idsuc;
        private string cantidad;
        conexiones_BD.clases.presentaciones_productos pp;
        private Int32 cantidad_anterior=0;
        private Int32 cantidad_total = 0;
        public existencias()
        {
            InitializeComponent();
        }
        sessionManager.secion sesion = sessionManager.secion.Instancia;

        public bool Conexion_remota { get => conexion_remota; set => conexion_remota = value; }
        public string Idsuc { get => idsuc; set => idsuc = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }
        public int Cantidad_total { get => cantidad_total; set => cantidad_total = value; }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void existencias_Load(object sender, EventArgs e)
        {
            pp = new conexiones_BD.clases.presentaciones_productos();
            pp.Idsucursal_producto = idsuc;
            colocandoDatos();
            //foreach(string se in sesion.Datos)
            //{
            //    Console.WriteLine("Datos: "+se);
            //}
        }

        private DataTable datos()
        {
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            op.Conexion_remota = conexion_remota;

            return op.Consultar(pp.presentaciones_productos_asce());
        }

        private void colocandoDatos()
        {
            DataTable dato = datos();
            Int32 cant = Convert.ToInt32(cantidad);
            int modu = 0;
            int aux = 0;
            int total = 0;

            if (dato.Rows.Count != 0)
            {
                foreach(DataRow fila in dato.Rows)
                { 
                    if (aux == 0)
                    {
                        int canti = (int)fila[1];
                        total = ((int)cant / canti);
                        modu = ((int)cant % canti);
                        aux++;
                        tabla_existencias.Rows.Add(fila[0] + "x" + fila[1], total, fila[2], fila[1]);
                    }
                    else
                    {
                        int canti = (int)fila[1];
                        total = ((int)modu / canti);
                        modu = ((int)modu % canti);

                        tabla_existencias.Rows.Add(fila[0] + "x" + fila[1], total, fila[2], fila[1]);
                    }        
                }
            }
            conteo_existencias();
        }

        private void tabla_existencias_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                cantidad_anterior = Convert.ToInt32(tabla_existencias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            }
        }

        private void conteo_existencias()
        {
            Cantidad_total = 0;
            foreach(DataGridViewRow fila in tabla_existencias.Rows)
            {
                Cantidad_total += (Convert.ToInt32(fila.Cells[1].Value.ToString()) * Convert.ToInt32(fila.Cells[3].Value.ToString()));
            }

        }

        private void tabla_existencias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                try
                {
                    Int32 valor = Convert.ToInt32(tabla_existencias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    auxiliares.justificacion just = new auxiliares.justificacion();
                    if (valor == cantidad_anterior)
                    {
                        
                    }
                    else if (valor < cantidad_anterior)
                    {
                        if (just.ShowDialog() == DialogResult.OK)
                        {
                            int canti = valor - cantidad_anterior;
                            if(!guardando_ajuste("2", e.ColumnIndex, e.RowIndex, just.txtJustificacion.Text, canti.ToString()))
                            {
                                tabla_existencias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cantidad_anterior;
                            }
                            else
                            {
                                conteo_existencias();
                                guardando_existencias();
                            }
                        }
                    }
                    else
                    {
                        if (just.ShowDialog() == DialogResult.OK)
                        {
                            int canti = valor - cantidad_anterior;
                            if (!guardando_ajuste("1", e.ColumnIndex, e.RowIndex, just.txtJustificacion.Text, canti.ToString()))
                            {
                                tabla_existencias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cantidad_anterior;
                            }
                            else
                            {
                                conteo_existencias();
                                guardando_existencias();
                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabla_existencias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cantidad_anterior;
                }          
            }

            
        }

        private bool guardando_ajuste(string tipo_ajus, int columna, int fila, string justi, string canti)
        {
            DateTime fecha = DateTime.Now;
            conexiones_BD.clases.ajustes ajus = new conexiones_BD.clases.ajustes
            {
                idusuario = sesion.Datos[6],
                idpre_pro = tabla_existencias.Rows[fila].Cells[2].Value.ToString(),
                justificacion = justi,
                cantidad = canti,
                tipo_ajuste = tipo_ajus,
                fecha_ajuste = fecha.ToString("yyyy-MM-dd hh:mm:ss") 
            };

            ajus.cargar_datos_para_envio();

            if (ajus.guardar(false, false)>1) {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void guardando_existencias()
        {
            conexiones_BD.clases.sucursales_productos sp = new conexiones_BD.clases.sucursales_productos
            {
                Existencias = Cantidad_total.ToString(),
                Idsucursal_producto = idsuc
            };
            conexiones_BD.operaciones op = new conexiones_BD.operaciones();
            if (op.actualizar(sp.modificarExistenciaProducto().ToString())>=1)
            {
                MessageBox.Show("Actualizado");
            }
        }
    }
}
