using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;

namespace conexiones_BD.clases
{
    public class presentaciones_productos : entidad
    {
        string idpresentacion_producto, idsucursal_producto,
            idpresentacion, cantidad_unidades, precio, tipo, prioridad, cod_producto, correla, estado, preci_estado;

        public string Idsucursal_producto
        {
            get
            {
                return idsucursal_producto;
            }

            set
            {
                idsucursal_producto = value;
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

        public string Idpresentacion
        {
            get
            {
                return idpresentacion;
            }

            set
            {
                idpresentacion = value;
            }
        }

        public string Cantidad_unidades
        {
            get
            {
                return cantidad_unidades;
            }

            set
            {
                cantidad_unidades = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string Prioridad
        {
            get
            {
                return prioridad;
            }

            set
            {
                prioridad = value;
            }
        }

        public string Cod_producto
        {
            get
            {
                return cod_producto;
            }

            set
            {
                cod_producto = value;
            }
        }

        public string Correla
        {
            get
            {
                return correla;
            }

            set
            {
                correla = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public string Idpresentacion_producto { get => idpresentacion_producto; set => idpresentacion_producto = value; }
        public string Preci_estado { get => preci_estado; set => preci_estado = value; }

        public presentaciones_productos() { }
        public presentaciones_productos(string idpresentacion_producto)
        {
            this.Idpresentacion_producto = idpresentacion_producto;
            base.cargarDatosEliminados("presentaciones_productos", idpresentacion_producto, "idpresentacion_producto");
        }

        public presentaciones_productos(string idpp, string precio)
        {
            this.Idpresentacion_producto = idpp;
            this.Precio = precio;
        }

        public presentaciones_productos(List<string> campos, List<string> valores)
        {
            base.busquedaDatos(campos, valores, "presentaciones_productos");
        }

        public presentaciones_productos(string idpresentacion_producto, 
            string idsucursal_producto, 
            string idpresentacion, 
            string cantidad_unidades, 
            string precio, 
            string tipo, 
            string pri, 
            string estado,
            string p_es)
        {
            this.Idpresentacion_producto = idpresentacion_producto;
            this.idsucursal_producto = idsucursal_producto;
            this.Idpresentacion = idpresentacion;
            this.Cantidad_unidades = cantidad_unidades;
            this.Precio = precio;
            this.Tipo = tipo;
            this.Prioridad = pri;
            this.Estado = estado;
            this.preci_estado = p_es;
            base.cargarDatosModificados(generarCampos(), generarValores(), "presentaciones_productos", idpresentacion_producto, "idpresentacion_producto");
        }

        public presentaciones_productos(string idsucursal_producto, 
            string idpresentacion, 
            string cantidad_unidades, 
            string precio, 
            string tipo, 
            string pri, 
            string estado,
            string p_esta)
        {
            this.idsucursal_producto = idsucursal_producto;
            this.Idpresentacion = idpresentacion;
            this.Cantidad_unidades = cantidad_unidades;
            this.Precio = precio;
            this.Tipo = tipo;
            this.Prioridad = pri;
            this.Estado = estado;
            this.preci_estado = p_esta;
            base.cargarDatos(generarCampos(), generarValores(), "presentaciones_productos");
        }

        public override List<string> generarCampos()
        {
            List<string> campos = new List<string>();
            campos.Add("idsucursal_producto");
            campos.Add("idpresentacion");
            campos.Add("cantidad_unidades");
            campos.Add("precio");
            campos.Add("tipo");
            campos.Add("prioridad");
            campos.Add("estado");
            campos.Add("tipo_precio");
            return campos;
        }

        public override List<string> generarValores()
        {
            List<string> valores = new List<string>();
            valores.Add(Idsucursal_producto);
            valores.Add(Idpresentacion);
            valores.Add(Cantidad_unidades);
            valores.Add(Precio);
            valores.Add(Tipo);
            valores.Add(Prioridad);
            valores.Add(estado);
            valores.Add(preci_estado);
            return valores;
        }

        public void cargarNevamente()
        {
            base.cargarDatos(generarCampos(), generarValores(), "presentaciones_productos");
        }

        public int consulta_modificar(bool cr)
        {
            int Datos = 0;
            String Consulta;
            Consulta = @"UPDATE presentaciones_productos SET idsucursal_producto='"+this.idsucursal_producto+"', " +
                "idpresentacion='"+this.idpresentacion+"', " +
                "cantidad_unidades='" + this.cantidad_unidades + "', " +
                "precio='" + this.precio + "', tipo='" + this.tipo + "', " +
                "prioridad='" + this.prioridad + "', estado='" + this.estado + "', " +
                "tipo_precio='" + this.preci_estado + "' "+
                "WHERE idpresentacion_producto='" + this.Idpresentacion_producto + "';";

            Console.WriteLine("Que suscede: "+Consulta);
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            oOperacion.Conexion_remota = cr;
            try
            {
                Datos = oOperacion.actualizar(Consulta);
            }
            catch
            {
                Datos = 0;
            }

            return Datos;
        }

        public static int inabilitarPresentacion(string id)
        {
            int Datos = 0;
            String Consulta;
            Consulta = "UPDATE presentaciones_productos SET estado = 2 WHERE (idpresentacion_producto = '"+ id + "')";
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            try
            {
                Datos = oOperacion.actualizar(Consulta);
            }
            catch
            {
                Datos = 0;
            }

            return Datos;
        }

        public static DataTable datosTabla()
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = "select * from presentaciones_productos where estado=1;";
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            try
            {
                Datos = oOperacion.Consultar(Consulta);
            }
            catch
            {
                Datos = new DataTable();
            }

            return Datos;
        }

        public static DataTable presentacionesXproducto(string idsuc_p, bool cr)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select pp.idpresentacion_producto, 
                        pp.idpresentacion, 
                        p.nombre_presentacion, 
                        pp.cantidad_unidades, 
                        pp.precio, 
                        pp.tipo, 
                        pp.prioridad, 
                        pp.estado,
                        pp.tipo_precio
                        from presentaciones_productos pp, sucursales_productos sp, presentaciones p
                        where pp.idsucursal_producto = sp.idsucursal_producto and pp.idpresentacion = p.idpresentacion and sp.idsucursal_producto = '"+idsuc_p+@"'
                        order by pp.prioridad asc
                        ; ";
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            oOperacion.Conexion_remota=cr;
            try
            {
                Datos = oOperacion.Consultar(Consulta);
            }
            catch
            {
                Datos = new DataTable();
            }

            return Datos;
        }

        public static DataTable PRESENTACIONES_INVENTARIO(bool cr)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"SELECT p.nombre_presentacion, pp.tipo, pp.precio, pp.cantidad_unidades, 
                        pp.estado, pp.idsucursal_producto
                        FROM presentaciones_productos pp
                        INNER JOIN presentaciones p on pp.idpresentacion=p.idpresentacion
                        INNER JOIN sucursales_productos sp on pp.idsucursal_producto=sp.idsucursal_producto
                        ;";
            operaciones oOperacion = new operaciones();
            oOperacion.Conexion_remota = cr;
            try
            {
                Datos = oOperacion.Consultar(Consulta);
            }
            catch
            {
                Datos = new DataTable();
            }

            return Datos;
        }

        public static DataTable presentacionesXproducto2(string idsuc_p)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select pp.idpresentacion_producto, pp.idpresentacion, p.nombre_presentacion, 
                        pp.cantidad_unidades, pp.precio, pp.tipo, pp.prioridad, pp.estado, 
                        concat(p.nombre_presentacion,'x',pp.cantidad_unidades) as nombre, pp.tipo_precio
                        from presentaciones_productos pp, sucursales_productos sp, presentaciones p
                        where pp.idsucursal_producto = sp.idsucursal_producto and pp.idpresentacion = p.idpresentacion and sp.idsucursal_producto = '" + idsuc_p + @"' and pp.estado=1
                        order by pp.prioridad asc
                        ; ";
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            try
            {
                Datos = oOperacion.Consultar(Consulta);
                Console.WriteLine("Numero de datos: "+Datos.Rows.Count);
            }
            catch
            {
                Datos = new DataTable();
            }

            return Datos;
        }

        public static DataTable presentaciones_producto(string idsuc_p)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select *
                        from presentaciones_productos pp
                        where pp.idsucursal_producto='"+idsuc_p+@" and pp.estado=1'
                        ; ";
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            try
            {
                Datos = oOperacion.Consultar(Consulta);
            }
            catch
            {
                Datos = new DataTable();
            }

            return Datos;
        }

        public static DataTable presentaciones_productoXCodigo(string codi)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select p.nombre_presentacion, p.idpresentacion, pp.precio, pp.idpresentacion_producto
                        from presentaciones_productos pp, presentaciones p, sucursales_productos sp
                        where pp.idpresentacion=p.idpresentacion and pp.idsucursal_producto=sp.idsucursal_producto
                        and pp.idsucursal_producto=(select sspp.idsucursal_producto from sucursales_productos sspp, 
                        productos p where sspp.idproducto=p.idproducto and p.cod_producto='" + codi+@"') and pp.estado=1;
                        ;";
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            try
            {
                Datos = oOperacion.Consultar(Consulta);
            }
            catch
            {
                Datos = new DataTable();
            }

            return Datos;
        }

        public static DataTable presentacionesXproductoXcantidad(string idsuc_p)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select pp.idsucursal_producto as idsp, concat(p.nombre_presentacion,'x',pp.cantidad_unidades) as nombre, pp.cantidad_unidades, pp.idpresentacion_producto
from presentaciones_productos pp, presentaciones p
where pp.idpresentacion = p.idpresentacion and pp.idsucursal_producto = '" + idsuc_p+@"' and pp.estado=1 order by pp.cantidad_unidades desc
    ; ";
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            try
            {
                Datos = oOperacion.Consultar(Consulta);
            }
            catch
            {
                Datos = new DataTable();
            }

            return Datos;
        }

        public static bool cambio_precio(string precioN, string idpresentacio_producto)
        {
            bool modificado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE presentaciones_productos SET precio='"+precioN+"' WHERE idpresentacion_producto='"+idpresentacio_producto+"';");
            Console.WriteLine(sentencia.ToString());
            conexiones_BD.operaciones op = new operaciones();
            if (op.actualizar(sentencia.ToString()) > 0)
            {
                modificado = true;
            }
            

            return modificado;
        }

        public StringBuilder cambio_precios()
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE presentaciones_productos SET precio='" + this.Precio + "' WHERE idpresentacion_producto='" + this.Idpresentacion_producto + "';");

            return sentencia;
        }

        public string modificar_presentacion_producto()
        {
            string sentencia= "UPDATE presentaciones_productos SET idpresentacion = '"+idpresentacion+"'," +
                " cantidad_unidades = '"+cantidad_unidades+"', precio = '"+precio+"', tipo = '"+tipo+"' WHERE (idpresentacion_producto = '"+idpresentacion_producto+"')";
            return sentencia;
        }

        public string modificar_prioridad()
        {
            string sentencia = "UPDATE presentaciones_productos SET prioridad = '"+prioridad+"' WHERE (idpresentacion_producto = '"+idpresentacion_producto+"')";
            return sentencia;
        }

        public string modificar_estado()
        {
            string sentencia = "UPDATE presentaciones_productos SET estado = '" + estado + "' WHERE (idpresentacion_producto = '" + idpresentacion_producto + "')";
            return sentencia;
        }

        public string modificar_tipo_precio()
        {
            string sentencia = "UPDATE presentaciones_productos SET tipo_precio = '" + preci_estado + "' WHERE (idpresentacion_producto = '" + idpresentacion_producto + "')";
            return sentencia;
        }

        public string presentaciones_productos_asce()
        {
            string sentencia = @"select p.nombre_presentacion, pp.cantidad_unidades, pp.idpresentacion_producto  
                                from presentaciones_productos pp, presentaciones p
                                where pp.idpresentacion = p.idpresentacion
                                and pp.idsucursal_producto = "+idsucursal_producto+@"
                                and pp.estado = 1
                                order by pp.cantidad_unidades desc; ";
            return sentencia;
        }

        /*No  utilizado*/

        public XmlNode creaPresentaPro(XmlDocument doc)
        {

            XmlNode prese_pro = doc.CreateElement("presentacion_pro");


            XmlElement e1 = doc.CreateElement("idsucursal_producto");
            e1.InnerText = idsucursal_producto;
            prese_pro.AppendChild(e1);


            XmlElement e2 = doc.CreateElement("idpresentacion");
            e2.InnerText = idpresentacion;
            prese_pro.AppendChild(e2);

            XmlElement e3 = doc.CreateElement("cantidad_unidades");
            e3.InnerText = cantidad_unidades;
            prese_pro.AppendChild(e3);

            XmlElement e4 = doc.CreateElement("precio");
            e4.InnerText = precio;
            prese_pro.AppendChild(e4);

            XmlElement e5 = doc.CreateElement("tipo");
            e5.InnerText = tipo;
            prese_pro.AppendChild(e5);

            XmlElement e6 = doc.CreateElement("pri");
            e6.InnerText = Prioridad;
            prese_pro.AppendChild(e6);

            XmlElement e7 = doc.CreateElement("codigo_productos");
            e7.InnerText = Cod_producto;
            prese_pro.AppendChild(e7);

            return prese_pro;
        }

        public XmlNode creaPresentaProTras(XmlDocument doc)
        {

            XmlNode prese_pro = doc.CreateElement("presentacion_pro");


            XmlElement e1 = doc.CreateElement("idsucursal_producto");
            e1.InnerText = idsucursal_producto;
            prese_pro.AppendChild(e1);


            XmlElement e2 = doc.CreateElement("idpresentacion");
            e2.InnerText = idpresentacion;
            prese_pro.AppendChild(e2);

            XmlElement e3 = doc.CreateElement("cantidad_unidades");
            e3.InnerText = cantidad_unidades;
            prese_pro.AppendChild(e3);

            XmlElement e4 = doc.CreateElement("precio");
            e4.InnerText = precio;
            prese_pro.AppendChild(e4);

            XmlElement e5 = doc.CreateElement("tipo");
            e5.InnerText = tipo;
            prese_pro.AppendChild(e5);

            XmlElement e6 = doc.CreateElement("pri");
            e6.InnerText = Prioridad;
            prese_pro.AppendChild(e6);

            XmlElement e7 = doc.CreateElement("codigo_productos");
            e7.InnerText = Cod_producto;
            prese_pro.AppendChild(e7);

            XmlElement e8 = doc.CreateElement("correlativo");
            e8.InnerText = correla;
            prese_pro.AppendChild(e8);

            return prese_pro;
        }


    }
}
