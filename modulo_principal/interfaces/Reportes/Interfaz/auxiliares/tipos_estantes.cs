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
    public partial class tipos_estantes : Form
    {
        string nombre_estante = "";
        bool reporte_sencillo = false;
        bool cancelado = false;
        utilitarios.cargar_tablas tabla;

        public tipos_estantes()
        {
            InitializeComponent();
        }

        public bool Reporte_sencillo { get => reporte_sencillo; set => reporte_sencillo = value; }
        public string Nombre_estante { get => nombre_estante; set => nombre_estante = value; }
        public bool Cancelado { get => cancelado; set => cancelado = value; }

        private void cerrar_Click(object sender, EventArgs e)
        {
            cancelado = true;
            this.Close();
        }

        private void tipos_estantes_Load(object sender, EventArgs e)
        {
            tabla = new utilitarios.cargar_tablas(tabla_estantes, txtBusqueda, conexiones_BD.clases.estantes.datosTabla(false), "nombre");
            tabla.cargarSinContadorRegistros();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            tabla.FiltrarLocalmenteSinContadorRegistros();
        }

        private void tabla_estantes_Click(object sender, EventArgs e)
        {
            if (tabla_estantes.Rows.Count != 0)
            {
                if (MessageBox.Show("¿Deseas un tipo de reporte sencillo?", "Tipo de reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Nombre_estante = tabla_estantes.CurrentRow.Cells[0].Value.ToString();
                    reporte_sencillo = true;
                    this.Close();
                }
                else
                {
                    Nombre_estante = tabla_estantes.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
        }
    }
}
