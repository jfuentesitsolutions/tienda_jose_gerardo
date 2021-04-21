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
    public partial class tipos_marcas : Form
    {
        string nombre_marca = "";
        bool reporte_sencillo = false;
        bool cancelado = false;
        utilitarios.cargar_tablas tabla;
        public tipos_marcas()
        {
            InitializeComponent();
        }

        public string Nombre_marca { get => nombre_marca; set => nombre_marca = value; }
        public bool Reporte_sencillo { get => reporte_sencillo; set => reporte_sencillo = value; }
        public bool Cancelado { get => cancelado; set => cancelado = value; }

        private void cerrar_Click(object sender, EventArgs e)
        {
            cancelado = true;
            this.Close();
        }

        private void tabla_marcas_Click(object sender, EventArgs e)
        {
            if (tabla_marcas.Rows.Count != 0)
            {
                if (MessageBox.Show("¿Deseas un tipo de reporte sencillo?", "Tipo de reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nombre_marca = tabla_marcas.CurrentRow.Cells[0].Value.ToString();
                    reporte_sencillo = true;
                    this.Close();
                }
                else
                {
                    nombre_marca = tabla_marcas.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
        }

        private void tipos_marcas_Load(object sender, EventArgs e)
        {
            tabla = new utilitarios.cargar_tablas(tabla_marcas, txtBusqueda, conexiones_BD.clases.marcas.datosTabla(false), "nombre");
            tabla.cargarSinContadorRegistros();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            tabla.FiltrarLocalmenteSinContadorRegistros();
        }
    }
}
