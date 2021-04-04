using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cache_manager;
using Microsoft.Win32;

namespace control_principal
{
    public partial class login : Form
    {
        Boolean autorizado = false;
        public login()
        {
            InitializeComponent();
        }

        public bool Autorizado
        {
            get
            {
                return autorizado;
            }

            set
            {
                autorizado = value;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {
            verificarConfiguracion();
        }

        private void configurar_Click(object sender, EventArgs e)
        {
            configuraciones_iniciales ci = new configuraciones_iniciales();
            ci.ShowDialog();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
             iniciarsesion();       
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            String texto = txtContrase.Text;

            txtContrase.UseSystemPasswordChar = !chkMostrar.Checked;
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContrase.Focus();
                txtContrase.SelectAll();
            }
        }

        private void iniciarsesion()
        {
            using(espera_datos.splash_espera es=new espera_datos.splash_espera())
            {
                es.Funcion_recargar = conexion_validacion;
                es.Tipo_operacion = 1;
                if (es.ShowDialog() == DialogResult.OK)
                {
                    if (es.Datos.Rows.Count == 1)
                    {
                        MessageBox.Show("Bienvenido al sistema " + es.Datos.Rows[0][1].ToString());
                        sessionManager.secion sesion = sessionManager.secion.Instancia;

                        for (int i = 0; i < es.Datos.Columns.Count; i++)
                        {
                            sesion.Datos.Add(es.Datos.Rows[0][i].ToString());
                        }
                        cargarDatosRegistros();
                        autorizado = true;

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No hay conexión a la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        autorizado = false;
                        txtContrase.Focus();
                        txtContrase.SelectAll();
                    }
                }
            }
  
        }

        private DataTable conexion_validacion()
        {
            DataTable datos = new DataTable();
            datos = conexiones_BD.clases.usuarios.datos_Usuario(txtUsuario.Text, txtContrase.Text);
            return datos;
        }
        private void txtContrase_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();
            }
        }

        private void chkMostrar_CheckedChanged_2(object sender, EventArgs e)
        {
            String texto = txtContrase.Text;

            txtContrase.UseSystemPasswordChar = !chkMostrar.Checked;
        }

        private void btnConfigInicial_Click(object sender, EventArgs e)
        {
            configuraciones_iniciales con = new configuraciones_iniciales();
            con.ShowDialog();
            if (con.Configurado)
            {
                Application.Restart();
            }
        }

        private void verificarConfiguracion()
        {
            string lectura = (string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "numero_sucursal", "NE");
            if (lectura==null || lectura.Equals("NE"))
            {
                btnConfigInicial.Visible = true;
            }
            else
            {
                btnConfigInicial.Visible = false;
            }
        }

        private void cargarDatosRegistros()
        {
            sessionManager.secion sesion = sessionManager.secion.Instancia;
            string lectura = (string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "idsucursal", "NE");
            if (!lectura.Equals("NE"))
            {
                sesion.DatosRegistro.Add((string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "numero_sucursal", "NE"));
                sesion.DatosRegistro.Add((string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "idsucursal", "NE"));
                sesion.DatosRegistro.Add((string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "direccion", "NE"));
                sesion.DatosRegistro.Add((string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "telefono", "NE"));
                sesion.DatosRegistro.Add((string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "encargado_sucursal", "NE"));
                sesion.DatosRegistro.Add((string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "idempleado", "NE"));
                sesion.DatosRegistro.Add((string)Registry.GetValue("HKEY_CURRENT_USER\\PuntoVentaGerardo\\configura", "nombre_del_equipo", "Nombre no configurado"));

            }
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
