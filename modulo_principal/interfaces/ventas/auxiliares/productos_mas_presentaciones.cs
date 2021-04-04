﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.ventas.auxiliares
{
    public partial class productos_mas_presentaciones : Form
    {
        string idsucursalProducto = null;
        string idpresentacion_poroducto, total, utilidad, utiliadM, utilidadD, precio, codigo, presentacion, cantidad_interna, sucursal_producto;
        bool llenado = false;
        bool modificar = false;
        utilitarios.cargar_tablas tabla;
        TextBox bus;
        bool uti_detalle = false;

        public productos_mas_presentaciones()
        {
            InitializeComponent();
        }

        public string IdsucursalProducto
        {
            get
            {
                return idsucursalProducto;
            }

            set
            {
                idsucursalProducto = value;
            }
        }

        public bool Modificar
        {
            get
            {
                return modificar;
            }

            set
            {
                modificar = value;
            }
        }

        public bool Llenado
        {
            get
            {
                return llenado;
            }

            set
            {
                llenado = value;
            }
        }

        public string Idpresentacion_poroducto
        {
            get
            {
                return idpresentacion_poroducto;
            }

            set
            {
                idpresentacion_poroducto = value;
            }
        }

        public string Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public string Utilidad
        {
            get
            {
                return utilidad;
            }

            set
            {
                utilidad = value;
            }
        }

        public string Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        private bool valida()
        {
            bool valido = false;
            error.Clear();
            string mensaje = "La cantidad no puede quedar a 0";

            if (txtCantidad.Value == 0)
            {
                valido = true;
                error.SetError(txtCantidad, mensaje);
            }

            return valido;
        }

        public string UtiliadM
        {
            get
            {
                return utiliadM;
            }

            set
            {
                utiliadM = value;
            }
        }

        private void productos_mas_presentaciones_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public string UtilidadD
        {
            get
            {
                return utilidadD;
            }

            set
            {
                utilidadD = value;
            }
        }

        private void tablaPres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtCantidad.Focus();
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!valida())
                {
                    if (!revisarExistencias())
                    {
                        presentacion = tablaPres.CurrentRow.Cells[0].Value.ToString();
                        idpresentacion_poroducto = tablaPres.CurrentRow.Cells[2].Value.ToString();
                        precio = tablaPres.CurrentRow.Cells[1].Value.ToString();
                        cantidad_interna = tablaPres.CurrentRow.Cells[3].Value.ToString();
                        Llenado = true;
                        calculos();
                        this.Close();
                    }
                }
            }
        }

        public string Presentacion
        {
            get
            {
                return presentacion;
            }

            set
            {
                presentacion = value;
            }
        }

        public string Cantidad_interna
        {
            get
            {
                return cantidad_interna;
            }

            set
            {
                cantidad_interna = value;
            }
        }

        public string Sucursal_producto
        {
            get
            {
                return sucursal_producto;
            }

            set
            {
                sucursal_producto = value;
            }
        }

        public bool Uti_detalle { get => uti_detalle; set => uti_detalle = value; }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productos_mas_presentaciones_Load(object sender, EventArgs e)
        {
            bus = new TextBox();
            tabla = new utilitarios.cargar_tablas(tablaPres, bus, conexiones_BD.clases.presentaciones_productos.presentacionesXproducto2(idsucursalProducto), "nombre_presentacion");
            tabla.cargarSinContadorRegistros();
            txtCantidad.Value = 1;
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            txtCantidad.Select(0, txtCantidad.Text.Length);
        }

        private bool revisarExistencias()
        {
            bool existencias = false;

            if (Convert.ToUInt32(lblExis.Text) < (Convert.ToInt32(txtCantidad.Value)*Convert.ToInt32(tablaPres.CurrentRow.Cells[3].Value.ToString())))
            {
                MessageBox.Show("No hay existencias suficientes", "No hay existencias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidad.Value = 0;
                existencias = true;
                tablaPres.Focus();
            }
            else
            {
                existencias = false;
            }

            return existencias;
        }

        private void calculos()
        {
            double cantidad = Convert.ToDouble(txtCantidad.Value.ToString());
            double preci = Convert.ToDouble(tablaPres.CurrentRow.Cells[1].Value.ToString());
            double tota = Math.Round((cantidad * preci),2, MidpointRounding.AwayFromZero);
            total = tota.ToString();

            if (tablaPres.CurrentRow.Cells[4].ToString().Equals("Detalle"))
            {
                double uti = 1-Convert.ToDouble(utilidadD);
                double utili = Math.Round((uti * preci), 2, MidpointRounding.AwayFromZero);
                utilidad = utili.ToString();
                uti_detalle = true;
            }
            else
            {
                double uti = 1-Convert.ToDouble(utiliadM);
                double utili = Math.Round((uti * preci),2, MidpointRounding.AwayFromZero);
                utilidad = utili.ToString();
            }
            
            
        }
    }
}
