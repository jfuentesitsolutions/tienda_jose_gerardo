using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace conexiones_BD.clases
{
    public class sucursales_productos: entidad
    {
        string idsucursal_producto, idsucursal, idproducto, idutilidadMayoreo, idutilidadDetalles, idestante, existencias, precio_ventaD, precio_compraD, precio_ventaM, precio_compraM, kardex, estado;

        public string Idproducto
        {
            get
            {
                return idproducto;
            }

            set
            {
                idproducto = value;
            }
        }

        public string Idsucursal_producto { get => idsucursal_producto; set => idsucursal_producto = value; }
        public string Idestante { get => idestante; set => idestante = value; }
        public string Kardex { get => kardex; set => kardex = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Existencias { get => existencias; set => existencias = value; }

        public sucursales_productos() { }
        public sucursales_productos(string idsucursal_producto, string idsucursal, string idproducto, 
            string idutilidadMayoreo, string idutilidadDetalle, string idestante, string existencias, 
            string precio_ventaD, string precio_compraD, string precio_ventaM, string precio_compraM, 
            string k, string estado)
        {
            this.Idsucursal_producto = idsucursal_producto;
            this.idsucursal = idsucursal;
            this.Idproducto = idproducto;
            this.idutilidadMayoreo = idutilidadMayoreo;
            this.idutilidadDetalles = idutilidadDetalle;
            this.Idestante = idestante;
            this.Existencias = existencias;
            this.precio_ventaD = precio_ventaD;
            this.precio_compraD = precio_compraD;
            this.precio_ventaM = precio_ventaM;
            this.precio_compraM = precio_compraM;
            this.Kardex = k;
            this.Estado = estado;
            base.cargarDatosModificados(generarCampos(), generarValores(), "sucursales_productos", idsucursal_producto, "idsucursal_producto");
        }

        public sucursales_productos(string idsucursal_producto, string idutilidadMayoreo, string idutilidadDetalle, 
            string precio_ventaD, string precio_compraD, string precio_ventaM, string precio_compraM, string estado)
        {
            this.Idsucursal_producto = idsucursal_producto;
            this.idutilidadMayoreo = idutilidadMayoreo;
            this.idutilidadDetalles = idutilidadDetalle;
            this.precio_ventaD = precio_ventaD;
            this.precio_compraD = precio_compraD;
            this.precio_ventaM = precio_ventaM;
            this.precio_compraM = precio_compraM;
            this.Estado = estado;     
        }

        public sucursales_productos(string idsucursal, string idproducto, string idutilidadMayoreo, 
            string idutilidadDetalle, string idestante, string existencias, string precio_ventaD, 
            string precio_compraD, string precio_ventaM, string precio_compraM, string k, string estado)
        {
            this.idsucursal = idsucursal;
            this.Idproducto = idproducto;
            this.idutilidadMayoreo = idutilidadMayoreo;
            this.idutilidadDetalles = idutilidadDetalle;
            this.Idestante = idestante;
            this.Existencias = existencias;
            this.precio_ventaD = precio_ventaD;
            this.precio_compraD = precio_compraD;
            this.precio_ventaM = precio_ventaM;
            this.precio_compraM = precio_compraM;
            this.Kardex = k;
            this.Estado = estado;
            base.cargarDatos(generarCampos(), generarValores(), "sucursales_productos");
        }

        public sucursales_productos(string idsucursal_producto)
        {
            this.Idsucursal_producto = idsucursal_producto;
            base.cargarDatosEliminados("sucursales_productos", idsucursal_producto, "idsucursal_producto");
        }

        public sucursales_productos(string idsu, string cantidadN, string estado)
        {
            this.Idsucursal_producto = idsu;
            Existencias = cantidadN;
            this.Estado = estado;
        }

        public sucursales_productos(List<string> campos, List<string> valores)
        {
            base.busquedaDatos(campos, valores, "sucursales_productos");
        }

        public override List<string> generarCampos()
        {
            List<string> campos = new List<string>();
            campos.Add("idsucursal");
            campos.Add("idproducto");
            campos.Add("idutilidadMayoreo");
            campos.Add("idutilidadDetalles");
            campos.Add("idestante");
            campos.Add("existencias");
            campos.Add("precio_venta");
            campos.Add("precio_compra");
            campos.Add("precio_ventaM");
            campos.Add("precio_compraM");
            campos.Add("kardex");
            campos.Add("estado");
            return campos;
        }

        public override List<string> generarValores()
        {
            List<string> valores = new List<string>();
            valores.Add(idsucursal);
            valores.Add(Idproducto);
            valores.Add(idutilidadMayoreo);
            valores.Add(idutilidadDetalles);
            valores.Add(Idestante);
            valores.Add(Existencias);
            valores.Add(precio_ventaD);
            valores.Add(precio_compraD);
            valores.Add(precio_ventaM);
            valores.Add(precio_compraM);
            valores.Add(Kardex);
            valores.Add(Estado);
            return valores;     
        }

        public void cargarNevamente()
        {
            base.cargarDatos(generarCampos(), generarValores(), "sucursales_productos");
        }

        public StringBuilder sentenciaModi()
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE sucursales_productos SET idsucursal='"+idsucursal+"', idproducto='"+idproducto+"', idutilidadMayoreo='"+idutilidadMayoreo+"', idutilidadDetalles='"+idutilidadDetalles+"', idestante='"+Idestante+"', existencias='"+Existencias+"', precio_venta='"+precio_ventaD+"', precio_compra='"+precio_compraD+"', precio_ventaM='"+precio_ventaM+"', precio_compraM='"+precio_compraM+ "', kardex='" + Kardex + "', estado='"+Estado+"' WHERE idsucursal_producto='" + Idsucursal_producto+"';");
            return sentencia;
        }

        public StringBuilder sentenciaElim()
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM sucursales_productos WHERE idsucursal_producto='"+Idsucursal_producto+"';");
            return sentencia;
        }

        public StringBuilder modificarExistenciaProducto()
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE sucursales_productos SET existencias='" + Existencias + "' WHERE idsucursal_producto='" + Idsucursal_producto + "';");
            return sentencia;
        }

        public string modificarUtilidadesProducto()
        {
            string sentencia = @"UPDATE sucursales_productos SET idutilidadMayoreo = '"+idutilidadMayoreo+@"', 
            idutilidadDetalles = '"+idutilidadDetalles+ @"', 
            precio_venta = '" + precio_ventaD + @"', 
            precio_compra = '" + precio_compraD + @"', 
            precio_ventaM = '" + precio_ventaM + @"', 
            precio_compraM = '" + precio_compraM + @"' WHERE idsucursal_producto = '" + Idsucursal_producto + "';";
            return sentencia;
        }

        public string modificar_estado()
        {
            string sentencia;
            sentencia="UPDATE sucursales_productos SET estado='" + Estado + "' WHERE idsucursal_producto='" + Idsucursal_producto + "';";
            return sentencia;
        }

        public string modificando_estante()
        {
            String Consulta;
            Consulta = "UPDATE sucursales_productos SET idestante = '" + Idestante + "' WHERE (idsucursal_producto = '" + Idsucursal_producto + "');";
            return Consulta;
        }

        public string modificando_kardex()
        {
            String Consulta;
            Consulta = "UPDATE sucursales_productos SET kardex = '" + Kardex + "' WHERE (idsucursal_producto = '" + Idsucursal_producto + "');";
            return Consulta;
        }

    }
}
