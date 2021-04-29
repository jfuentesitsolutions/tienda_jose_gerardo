using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace conexiones_BD.clases
{
    public class productos: entidad 
    {
        string idproducto, nom_producto, fecha_ingreso, idcategoria, idmarca, idestante;

        public productos()
        {

        }
        public string Idproducto { get => idproducto; set => idproducto = value; }
        public string Nom_producto { get => nom_producto; set => nom_producto = value; }
        public string Fecha_ingreso { get => fecha_ingreso; set => fecha_ingreso = value; }
        public string Idcategoria { get => idcategoria; set => idcategoria = value; }
        public string Idmarca { get => idmarca; set => idmarca = value; }
        public string Idestante { get => idestante; set => idestante = value; }

        public productos(string np, string fp, string ic, string idm)
        {
            this.Nom_producto = np;
            this.Fecha_ingreso = fp;
            this.Idcategoria = ic;
            this.Idmarca = idm;

            base.cargarDatos(generarCampos(), generarValores(), "productos");
            
        }

        public productos(string id, string np)
        {
            this.Nom_producto = np;
            this.Idproducto = id;
        }

        public productos(string np, string fp, string ic, string idm, string id)
        {
            this.Nom_producto = np;
            this.Fecha_ingreso = fp;
            this.Idcategoria = ic;
            this.Idmarca = idm;
            this.Idproducto = id;

            base.cargarDatosModificados(generarCampos(), generarValores(), "productos", Idproducto, "idproducto");

        }

        public productos(string id)
        {
            this.Idproducto = id;
            base.cargarDatosEliminados("productos", this.Idproducto, "idproducto");
        }

        public productos(List<String> c, List<String> v)
        {
            base.busquedaDatos(c, v, "productos");
        }

        public static DataTable CARGAR_TABLA_PRODUCTOS_X_SUCURSAL(string idsuc)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select sp.idsucursal_producto as idSp, p.idproducto as idP ,p.cod_producto as codP,p.nom_producto as nombreP,
                        c.idcategoria as idC, c.nombre_categoria as nombreC, m.idmarca as idM, m.nombre as nombreM,
                        s.idsucursal as idS, s.numero_de_sucursal as numeroS, e.idestante as idE, e.nombre as nombreE,
                        p.fecha_ingreso as fechaI, ucc.idtipo_compra as idUtiM, ucc.nombre as UtiM, ucc.porcentaje as PUtiM,
                        uc.idutilidad_compra as idUtiD, uc.nombre as UtiD, uc.porcentaje as PUtiD,
                        sp.precio_compraM as precioCM, sp.precio_compra as precioCD, sp.precio_ventaM as precioVM, sp.precio_venta as precioVD, sp.existencias as exis, sp.kardex
                        from sucursales_productos sp, sucursales s, productos p, utilidades_compras uc, utilidades_compras ucc ,estantes e, categorias c, marcas m
                        where sp.idsucursal=s.idsucursal 
                        and sp.idproducto=p.idproducto 
                        and sp.idutilidadDetalles=uc.idutilidad_compra 
                        and sp.idutilidadMayoreo=ucc.idutilidad_compra
                        and sp.idestante=e.idestante and sp.idsucursal='" + idsuc+@"'
                        and p.idcategoria=c.idcategoria
                        and p.idmarca=m.idmarca
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

        //MUESTRA LOS PRODUCTOS AUN SIN PRESENTACION
        public static DataTable CARGAR_TABLA_PRODUCTOS()
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select sp.idsucursal_producto as idSp, 
                            p.idproducto as idP,
                            codi.codigo as codP, 
                            p.nom_producto as nombreP,
                            c.idcategoria as idC, 
                            c.nombre_categoria as nombreC, 
                            m.idmarca as idM, 
                            m.nombre as nombreM,
                            s.idsucursal as idS, 
                            s.numero_de_sucursal as numeroS, 
                            e.idestante as idE, 
                            e.nombre as nombreE,
                            p.fecha_ingreso as fechaI, 
                            ucc.idutilidad_compra as idUtiM, 
                            ucc.nombre as UtiM, 
                            ucc.porcentaje as PUtiM,
                            uc.idutilidad_compra as idUtiD, 
                            uc.nombre as UtiD, uc.porcentaje as PUtiD,
                            sp.precio_compraM as precioCM, 
                            sp.precio_compra as precioCD, 
                            sp.precio_ventaM as precioVM, 
                            sp.precio_venta as precioVD, 
                            sp.existencias as exis, 
                            sp.kardex
                            from sucursales_productos sp, sucursales s, productos p, utilidades_compras uc, utilidades_compras ucc ,estantes e, categorias c, marcas m, codigos codi, productos_codigos proco
                            where sp.idsucursal=s.idsucursal 
                            and proco.idproducto=p.idproducto
                            and proco.idcodigo=codi.idcodigo
                            and sp.idproducto=p.idproducto 
                            and sp.idutilidadDetalles=uc.idutilidad_compra 
                            and sp.idutilidadMayoreo=ucc.idutilidad_compra
                            and sp.idestante=e.idestante
                            and p.idcategoria=c.idcategoria
                            and p.idmarca=m.idmarca
                            group by nombreP
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

        public override List<string> generarCampos()
        {
            List<String> nombre_campos = new List<string>();
            nombre_campos.Add("nom_producto");
            nombre_campos.Add("fecha_ingreso");
            nombre_campos.Add("idcategoria");
            nombre_campos.Add("idmarca");

            return nombre_campos;
        }

        public override List<string> generarValores()
        {
            List<String> valor = new List<string>();
            valor.Add(this.Nom_producto);
            valor.Add(this.Fecha_ingreso);
            valor.Add(this.Idcategoria);
            valor.Add(this.Idmarca);

            return valor;
        }

        public StringBuilder sentenciaModi()
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE productos SET nom_producto='"+Nom_producto+"', fecha_ingreso='"+Fecha_ingreso+"', idcategoria='"+Idcategoria+"', idmarca='"+Idmarca+"' WHERE idproducto='"+Idproducto+"';");
            return sentencia;
        }

        public StringBuilder sentenciaElim()
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM productos WHERE idproducto='"+Idproducto+"';");
            return sentencia;
        }

        public static DataTable CARGAR_TABLA_PRODUCTOS_X_SUCURSAL_VENTA()
        {
            
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select pp.idsucursal_producto as idsp ,codi.codigo as codigo, 
                            pr.nom_producto as nombre, count(*) as cantipre, concat(codi.codigo,' < -|-> ',
                            pr.nom_producto) as productoCod,
                            pp.precio, sp.existencias, p.nombre_presentacion as prese, 
                            pp.idpresentacion_producto as prepro, u.porcentaje as ud, uu.porcentaje as um,
                            pp.tipo, concat('$',pp.precio) as pre, u.idutilidad_compra as idud, 
                            uu.idutilidad_compra as idum, pp.tipo_precio
                            from presentaciones_productos pp, sucursales_productos sp, presentaciones p, productos pr, utilidades_compras u, utilidades_compras uu, codigos codi, productos_codigos proco
                            where pp.idsucursal_producto = sp.idsucursal_producto 
                            and proco.idproducto=pr.idproducto
                            and proco.idcodigo=codi.idcodigo
                            and pp.idpresentacion = p.idpresentacion 
                            and sp.idproducto = pr.idproducto
                            and sp.idutilidadDetalles = u.idutilidad_compra 
                            and sp.idutilidadMayoreo = uu.idutilidad_compra
                            and codi.estado=1
                            and pp.estado=1
                            and sp.estado=1
                            group by codi.codigo
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

        public static DataTable CARGAR_TABLA_PRODUCTOS_COMPRA()
        {

            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select sp.idsucursal_producto as idsp ,codi.codigo as codigo, pr.nom_producto as nombre, concat(codi.codigo,' < -|-> ',pr.nom_producto) as productoCod,
                        u.porcentaje as ud, uu.porcentaje as um, u.idutilidad_compra as idud, uu.idutilidad_compra as idum, u.nombre, uu.nombre,
                        (select count(idsucursal_producto) from presentaciones_productos where idsucursal_producto=sp.idsucursal_producto) as NPre
                        from sucursales_productos sp, productos pr, utilidades_compras u, utilidades_compras uu, codigos codi, productos_codigos proco
                        where proco.idproducto=pr.idproducto
                        and proco.idcodigo=codi.idcodigo
                        and sp.idproducto = pr.idproducto
                        and sp.idutilidadDetalles = u.idutilidad_compra 
                        and sp.idutilidadMayoreo = uu.idutilidad_compra
                        and codi.estado=1
                        and sp.estado=1
                        group by codi.codigo;";
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

        //MUESTRA LOS PRODCUCTOS CON PRESENTACIONES ACTIVAS
        public static DataTable CARGAR_TABLA_PRODUCTOS_VENT(bool cr)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select pp.idsucursal_producto as idsp ,codi.codigo as codigo, pr.nom_producto as nombre, count(*) as cantipre, concat(codi.codigo,' < -|-> ',pr.nom_producto) as productoCod,
                            pp.precio, sp.existencias, p.nombre_presentacion as prese, pp.idpresentacion_producto as prepro, u.porcentaje as ud, uu.porcentaje as um,
                            pp.tipo, concat('$',pp.precio) as pre, u.idutilidad_compra as idud, uu.idutilidad_compra as idum, pr.idproducto, pr.idmarca, pr.idcategoria, sp.idestante, sp.kardex, pr.fecha_ingreso,
                            sp.idutilidadMayoreo, sp.idutilidadDetalles, sp.precio_venta, sp.precio_compra, sp.precio_ventaM, sp.precio_compraM, sp.estado
                            from presentaciones_productos pp, sucursales_productos sp, presentaciones p, productos pr, utilidades_compras u, utilidades_compras uu, codigos codi, productos_codigos proco
                            where pp.idsucursal_producto = sp.idsucursal_producto 
                            and proco.idproducto=pr.idproducto
                            and proco.idcodigo=codi.idcodigo
                            and pp.idpresentacion = p.idpresentacion 
                            and sp.idproducto = pr.idproducto
                            and sp.idutilidadDetalles = u.idutilidad_compra 
                            and sp.idutilidadMayoreo = uu.idutilidad_compra
                            group by pr.nom_producto
                            ; ";
            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();
            
                try
                {
                    if (!cr)
                    {
                        Datos = oOperacion.Consultar(Consulta);
                    }
                    else
                    {
                        oOperacion.Conexion_remota = true;
                        Datos = oOperacion.Consultar(Consulta);
                    }

                }
                catch
                {
                    Datos = new DataTable();
                }
            
                

            return Datos;
        }

        public static DataTable PRODUCTOS_REPORTE_INVENTARIO(bool cr)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"SELECT p.idproducto, c.codigo, p.nom_producto, ca.nombre_categoria as categoria, 
                        ma.nombre as marca, es.nombre as estante, sp.existencias as exis_sistema, sp.idsucursal_producto as suc_pro
                        FROM productos_codigos pc
                        INNER JOIN codigos c on pc.idcodigo=c.idcodigo
                        INNER JOIN productos p on pc.idproducto=p.idproducto
                        INNER JOIN sucursales_productos sp on pc.idproducto=sp.idproducto
                        INNER JOIN categorias ca on p.idcategoria=ca.idcategoria
                        INNER JOIN marcas ma on p.idmarca=ma.idmarca
                        INNER JOIN estantes es on p.idestante=es.idestante
                        WHERE c.estado=1
                        GROUP BY p.nom_producto
                        ;";
            operaciones oOperacion = new operaciones();
            try
            {
                if (!cr)
                {
                    Datos = oOperacion.Consultar(Consulta);
                }
                else
                {
                    oOperacion.Conexion_remota = true;
                    Datos = oOperacion.Consultar(Consulta);
                }

            }
            catch
            {
                Datos = new DataTable();
            }



            return Datos;
        }

        public static DataTable CARGAR_TABLA_PRODUCTOS_PARA_MODIFICACIÓN(bool cr)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select  pr.idproducto, pp.idsucursal_producto as idsp ,codi.codigo as codigo, pr.nom_producto as nombre, count(*) as cantipre, concat(codi.codigo,' < -|-> ',pr.nom_producto) as productoCod,
sp.existencias, u.idutilidad_compra as idud, uu.idutilidad_compra as idum, pr.idmarca, pr.idcategoria, sp.idestante, sp.kardex, pr.fecha_ingreso, sp.precio_venta, 
sp.precio_compra, sp.precio_ventaM, sp.precio_compraM, sp.estado, (select count(pre_pro.idproveedor) from proveedores_productos pre_pro where pre_pro.idproducto=pr.idproducto) as num_provedores
from presentaciones_productos pp, sucursales_productos sp, presentaciones p, 
productos pr, utilidades_compras u, utilidades_compras uu, codigos codi, 
productos_codigos proco
where pp.idsucursal_producto = sp.idsucursal_producto 
and proco.idproducto=pr.idproducto
and proco.idcodigo=codi.idcodigo
and pp.idpresentacion = p.idpresentacion 
and sp.idproducto = pr.idproducto
and sp.idutilidadDetalles = u.idutilidad_compra 
and sp.idutilidadMayoreo = uu.idutilidad_compra
group by pr.nom_producto order by pr.nom_producto";

            conexiones_BD.operaciones oOperacion = new conexiones_BD.operaciones();

            try
            {
                if (!cr)
                {
                    Datos = oOperacion.Consultar(Consulta);
                }
                else
                {
                    oOperacion.Conexion_remota = true;
                    Datos = oOperacion.Consultar(Consulta);
                }

            }
            catch
            {
                Datos = new DataTable();
            }



            return Datos;
        }

        public static DataTable CARGAR_TABLA_PRODUCTOS_X_PRESENTACION_X_SUCURSAL_VENTA(string idsuc)
        {

            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select pp.idsucursal_producto as idsp ,codi.codigo as codigo, pr.nom_producto as nombre,
                            pp.precio, sp.existencias, p.nombre_presentacion as prese, pp.idpresentacion_producto as prepro, u.porcentaje as ud, uu.porcentaje as um,
                            pp.tipo, pp.cantidad_unidades as cin
                            from presentaciones_productos pp, sucursales_productos sp, presentaciones p, productos pr, utilidades_compras u, utilidades_compras uu, codigos codi, productos_codigos proco
                            where pp.idsucursal_producto=sp.idsucursal_producto 
                            and proco.idproducto=pr.idproducto
                            and proco.idcodigo=codi.idcodigo
                            and pp.idpresentacion=p.idpresentacion 
                            and sp.idproducto=pr.idproducto
                            and sp.idutilidadDetalles=u.idutilidad_compra 
                            and sp.idutilidadMayoreo=uu.idutilidad_compra
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

        public static DataTable CARGAR_TABLA_PRODUCTOS_VENT_X_PRESENTACION()
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select pp.idsucursal_producto as idsp ,pr.cod_producto as codigo, pr.nom_producto as nombre,
                        pp.precio, sp.existencias, p.nombre_presentacion as prese, pp.idpresentacion_producto as prepro, u.porcentaje as ud, uu.porcentaje as um,
                        pp.tipo, pp.cantidad_unidades as cin
                        from presentaciones_productos pp, sucursales_productos sp, presentaciones p, productos pr, utilidades_compras u, utilidades_compras uu
                        where pp.idsucursal_producto=sp.idsucursal_producto and pp.idpresentacion=p.idpresentacion and sp.idproducto=pr.idproducto
                        and sp.idutilidadDetalles=u.idutilidad_compra and sp.idutilidadMayoreo=uu.idutilidad_compra
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

        public static DataTable EXISTENCIAS_PRODUCTOS_X_IDVENTA(string idventa)
        {
            DataTable Datos = new DataTable();
            String Consulta;
            Consulta = @"select sp.existencias, sp.idsucursal_producto, dvt.cantidad
                            from ventas v, detalles_ventas_ticket dvt, sucursales_productos sp
                            where v.idventa_ticket=dvt.idventa_ticket
                            and dvt.idsucursal_producto=sp.idsucursal_producto
                            and v.anulacion=1
                            and v.idventa='"+idventa+@"'
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

        public string modificando_nombre()
        {
            String Consulta;
            Consulta = "UPDATE productos SET nom_producto = '"+Nom_producto+"' WHERE idproducto = '"+Idproducto+"'";
            return Consulta;
        }

        public string modificando_marca()
        {
            String Consulta;
            Consulta = "UPDATE productos SET idmarca = '"+Idmarca+"' WHERE (idproducto = '"+Idproducto+"');";
            return Consulta;
        }

        public string modificando_categoria()
        {
            String Consulta;
            Consulta = "UPDATE productos SET idcategoria = '" + Idcategoria + "' WHERE (idproducto = '" + Idproducto + "');";
            return Consulta;
        }

        public string modificando_estante()
        {
            String Consulta;
            Consulta = "UPDATE productos SET idestante = '" + Idestante + "' WHERE (idproducto = '" + Idproducto + "');";
            return Consulta;
        }
    }
}
