using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.Reportes.Interfaz.auxiliares
{
    
    public partial class tipos_categorias : Form
    {
        string nombre_categoria = "";
        bool reporte_sencillo = false;
        bool cancelado = false;
        utilitarios.cargar_tablas tabla;

        public string Nombre_categoria { get => nombre_categoria; set => nombre_categoria = value; }
        public bool Reporte_sencillo { get => reporte_sencillo; set => reporte_sencillo = value; }
        public bool Cancelado { get => cancelado; set => cancelado = value; }

        public tipos_categorias()
        {
            InitializeComponent();
        }

        private void cargarTabla()
        {
            tabla = new utilitarios.cargar_tablas(tabla_categorias, txtBusqueda, conexiones_BD.clases.categorias.datosTabla(false), "nombre_categoria");
            tabla.cargarSinContadorRegistros();
        }

        private void tipos_categorias_Load(object sender, EventArgs e)
        {
            this.cargarTabla();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            tabla.FiltrarLocalmenteSinContadorRegistros();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Cancelado = true;
            this.Close();
        }

        private void tabla_categorias_Click(object sender, EventArgs e)
        {
            if (tabla_categorias.Rows.Count != 0)
            {
                if (MessageBox.Show("¿Deseas un tipo de reporte sencillo?", "Tipo de reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nombre_categoria = tabla_categorias.CurrentRow.Cells[0].Value.ToString();
                    reporte_sencillo = true;
                    this.Close();
                }
                else
                {
                    nombre_categoria = tabla_categorias.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
        }
    }
}
