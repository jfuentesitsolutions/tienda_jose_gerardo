using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espera_datos
{
    public partial class splash_espera : Form
    {
        public splash_espera()
        {
            InitializeComponent();
        }
        public Func<List<DataTable>> Funcion
        {
            get
            {
                return funcion;
            }

            set
            {
                funcion = value;
            }
        }
        List<DataTable> datos_varios = null;
        DataTable datos = null;
        int resultado = 0;
        bool conec_server = false;
        Boolean conexion_exitosa = false;

        public int Tipo_operacion { get => tipo_operacion; set => tipo_operacion = value; }
        public List<DataTable> Datos_varios { get => datos_varios; set => datos_varios = value; }
        public DataTable Datos { get => datos; set => datos = value; }
        public Func<DataTable> Funcion_recargar { get => funcion_recargar; set => funcion_recargar = value; }
        public Func<int> Funcion_sentencia { get => funcion_sentencia; set => funcion_sentencia = value; }
        public int Resultado { get => resultado; set => resultado = value; }
        public bool Conec_server { get => conec_server; set => conec_server = value; }
        public Func<bool> Funcion_prueba { get => funcion_prueba; set => funcion_prueba = value; }
        public bool Conexion_exitosa { get => conexion_exitosa; set => conexion_exitosa = value; }

        private int tipo_operacion = 0;
        Func<List<DataTable>> funcion;
        private Func<DataTable> funcion_recargar;
        private Func<int> funcion_sentencia;
        private Func<Boolean> funcion_prueba;

        private void splash_espera_Shown(object sender, EventArgs e)
        {
            switch (tipo_operacion)
            {
                case 0:
                    {
                        Task.Factory.StartNew(funcion).ContinueWith((t) => tareaCompletada(t.Result[0], t.Result));
                        break;
                    }
                case 1:
                    {
                        Task.Factory.StartNew(funcion_recargar).ContinueWith((t) => retorno_datos_actualizados(t.Result));
                        break;
                    }
                case 2:
                    {
                        Task.Factory.StartNew(funcion_sentencia).ContinueWith((t) => retorno_respuesta_sentencia(t.Result));
                        break;
                    }
                case 3:
                    {
                        Task.Factory.StartNew(funcion_prueba).ContinueWith((t) => retorno_respuesta_conexion(t.Result));
                        break;
                    }
            }
            
        }

        private void tareaCompletada(DataTable d, List<DataTable> da)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    Datos_varios = da;
                    Datos = d;
                    DialogResult = DialogResult.OK;
                    Close();
                }));
            }
        }

        private void retorno_datos_actualizados(DataTable d)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    if (d.Rows.Count > 0)
                    {
                        Datos = d;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                    
                    Close();
                }));
            }
        }

        private void retorno_respuesta_sentencia(int d)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    resultado = d;
                    DialogResult = DialogResult.OK;
                    Close();
                }));
            }
        }

        private void retorno_respuesta_conexion(Boolean d)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    conexion_exitosa = d;
                    DialogResult = DialogResult.OK;
                    Close();
                }));
            }
        }

        //boton para salir de la transferencia
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //funcion de carga
        private void splash_espera_Load(object sender, EventArgs e)
        {
            if (Conec_server)
            {
                this.Width = 325;
                this.Height = 200;
                imagen.Image = Properties.Resources.animado1;
            }
            
        }
    }
}
