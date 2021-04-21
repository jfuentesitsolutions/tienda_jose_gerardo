using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces.Reportes.Interfaz
{
    public partial class reporte_productos : Form
    {
        DataSet datos = new DataSet();
        DataTable dato1, dato2, dato3;
        public reporte_productos()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            gadgets.movimimientos mov = new gadgets.movimimientos();
            mov.moverFormulario(sender, e, this);
        }

        private void btnReporteInventario_Click(object sender, EventArgs e)
        {


            Diseño.reporte_sencillo_productos repo = new Diseño.reporte_sencillo_productos();
            repo.SetDataSource(datos);

            repo.Database.Tables["reporte_inventario_productos"].SetDataSource(datos.Tables[0]);
            repo.Subreports[0].Database.Tables["reporte_presentaciones"].SetDataSource(datos.Tables[2]);

            reporte.ReportSource = repo;

        }

        private void btnReporCompleto_Click(object sender, EventArgs e)
        {
            Diseño.productos_inventario repo = new Diseño.productos_inventario();
            repo.SetDataSource(datos);

            repo.Database.Tables["reporte_inventario_productos"].SetDataSource(datos.Tables[0]);
            repo.Subreports[0].Database.Tables["codigos_producto"].SetDataSource(datos.Tables[1]);
            repo.Subreports[1].Database.Tables["reporte_presentaciones"].SetDataSource(datos.Tables[2]);
            reporte.ReportSource = repo;
        }

        private void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFiltro.Selected)
            {
                switch (comboFiltro.SelectedIndex)
                {
                    case 0:
                        {
                            MessageBox.Show("Tienes que seleccionar una opción de filtrado", "No hay opciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    case 1:
                        {
                            auxiliares.tipos_categorias cate = new auxiliares.tipos_categorias();
                            cate.ShowDialog();
                            if (!cate.Cancelado)
                            {
                                Console.WriteLine("nombre_categoria: " + cate.Nombre_categoria);
                                busqueda_categoria(cate.Nombre_categoria, cate.Reporte_sencillo, "categoria");
                            }                         
                            break;
                        }
                    case 2:
                        {
                            auxiliares.tipos_estantes esta = new auxiliares.tipos_estantes();
                            esta.ShowDialog();
                            if (!esta.Cancelado)
                            {
                                Console.WriteLine("nombre_categoria: " + esta.Nombre_estante);
                                busqueda_categoria(esta.Nombre_estante, esta.Reporte_sencillo, "estante");
                            } 
                            break;
                        }
                    case 3:
                        {
                            auxiliares.tipos_marcas marc = new auxiliares.tipos_marcas();
                            marc.ShowDialog();
                            if (!marc.Cancelado)
                            {
                                busqueda_categoria(marc.Nombre_marca, marc.Reporte_sencillo, "marca");
                            }
                            break;
                        }
                }
                    
                

                
            }
        }

        private void busqueda_categoria(string nombre, bool sencillo, string campo)
        {
                DataTable prueba = datos.Tables[0];
                IEnumerable<DataRow> productsQuery =
    from product in prueba.AsEnumerable()
    select product;

                IEnumerable<DataRow> largeProducts =
    productsQuery.Where(p => p.Field<string>(campo) == nombre);


            if (datos.Tables.Count == 3)
            {
                datos.Tables.Add(largeProducts.CopyToDataTable<DataRow>());
            }
            else
            {
                datos.Tables.RemoveAt(3);
                datos.Tables.Add(largeProducts.CopyToDataTable<DataRow>());
            } 

            if (sencillo)
            {
                Diseño.reporte_sencillo_productos repo = new Diseño.reporte_sencillo_productos();
                repo.SetDataSource(datos);
                repo.Database.Tables["reporte_inventario_productos"].SetDataSource(datos.Tables[3]);
                repo.Subreports[0].Database.Tables["reporte_presentaciones"].SetDataSource(datos.Tables[2]);

                reporte.ReportSource = repo;
            }
            else
            {
                Diseño.productos_inventario repo = new Diseño.productos_inventario();
                repo.SetDataSource(datos);
                repo.Database.Tables["reporte_inventario_productos"].SetDataSource(datos.Tables[3]);
                repo.Subreports[0].Database.Tables["codigos_producto"].SetDataSource(datos.Tables[1]);
                repo.Subreports[1].Database.Tables["reporte_presentaciones"].SetDataSource(datos.Tables[2]);
                reporte.ReportSource = repo;
            }  
        }

        private void busqueda_nombre(string nombre, bool sencillo, string campo)
        {
            DataTable prueba = datos.Tables[0];
            IEnumerable<DataRow> productsQuery =
from product in prueba.AsEnumerable()
select product;

            IEnumerable<DataRow> largeProducts =
productsQuery.Where(p => p.Field<string>(campo).Contains(nombre.ToUpper()));

            Console.WriteLine("Conteo de productos: "+largeProducts.Count());

            if (datos.Tables.Count == 3)
            {
                try
                {
                    datos.Tables.Add(largeProducts.CopyToDataTable<DataRow>());
                    generar_reporte(sencillo);
                }
                catch(Exception e)
                {
                    if(e.HResult == -2146233079)
                    {
                        MessageBox.Show("No se encontrarón productos con ese nombre", "No hay coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }   
            }
            else
            {
                try
                {
                datos.Tables.RemoveAt(3);
                datos.Tables.Add(largeProducts.CopyToDataTable<DataRow>());
                    generar_reporte(sencillo);
                }catch(Exception e){
                    if (e.HResult == -2146233079)
                    {
                        MessageBox.Show("No se encontrarón productos con ese nombre", "No hay coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        private void generar_reporte(bool tipo)
        {
            if (tipo)
            {
                Diseño.reporte_sencillo_productos repo = new Diseño.reporte_sencillo_productos();
                repo.SetDataSource(datos);
                repo.Database.Tables["reporte_inventario_productos"].SetDataSource(datos.Tables[3]);
                repo.Subreports[0].Database.Tables["reporte_presentaciones"].SetDataSource(datos.Tables[2]);

                reporte.ReportSource = repo;
            }
            else
            {
                Diseño.productos_inventario repo = new Diseño.productos_inventario();
                repo.SetDataSource(datos);
                repo.Database.Tables["reporte_inventario_productos"].SetDataSource(datos.Tables[3]);
                repo.Subreports[0].Database.Tables["codigos_producto"].SetDataSource(datos.Tables[1]);
                repo.Subreports[1].Database.Tables["reporte_presentaciones"].SetDataSource(datos.Tables[2]);
                reporte.ReportSource = repo;
            }
        }
        private void btnCampoBuscar_Click(object sender, EventArgs e)
        {
            if (txtCampoBuscar.TextLength != 0)
            {
                if (MessageBox.Show("¿Deseas imprimir un reporte sencillo?", "Tipo de reporte", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    busqueda_nombre(txtCampoBuscar.Text, true, "nom_producto");
                }
                else
                {
                    busqueda_nombre(txtCampoBuscar.Text, false, "nom_producto");
                }
            }
            else
            {
                MessageBox.Show("Escribe el nombre del producto a consultar", "No hay criterio de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporte_productos_Load(object sender, EventArgs e)
        {
            gadgets.horientaciones_textos.colocarTitulo(panelTitulo, lblEncanezado);
            cargar_reporte();
            comboFiltro.SelectedIndex = 0;
        }


        private void cargar_reporte()
        {
            dato1 = conexiones_BD.clases.productos.PRODUCTOS_REPORTE_INVENTARIO(false);
            dato2 = conexiones_BD.clases.codigos.CODIGOS_REPORTE_INVENTARIO(false);
            dato3 = conexiones_BD.clases.presentaciones_productos.PRESENTACIONES_INVENTARIO(false);

            datos.Tables.Add(dato1);
            datos.Tables.Add(dato2);
            datos.Tables.Add(dato3);

            Diseño.productos_inventario repo = new Diseño.productos_inventario();
            repo.SetDataSource(datos);
            

            repo.Database.Tables["reporte_inventario_productos"].SetDataSource(datos.Tables[0]);
            repo.Subreports[0].Database.Tables["codigos_producto"].SetDataSource(datos.Tables[1]);
            repo.Subreports[1].Database.Tables["reporte_presentaciones"].SetDataSource(datos.Tables[2]);
            
   
            reporte.ReportSource = repo;
        }
       
    }
}
