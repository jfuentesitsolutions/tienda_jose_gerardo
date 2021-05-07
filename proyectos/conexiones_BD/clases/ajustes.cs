using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexiones_BD.clases
{
    public class ajustes: entidad
    {

        public string idajuste { get; set; }
        public string idusuario { get; set; }
        public string idpre_pro { get; set; }
        public string justificacion { get; set; }
        public string cantidad { get; set; }
        public string tipo_ajuste { get; set; }
        public string fecha_ajuste { get; set; }

        public void cargar_datos_para_envio()
        {
            base.cargarDatos(generarCampos(), generarValores(), "ajustes");
        }

        public override List<string> generarCampos()
        {
            List<string> campos = new List<string>();
            campos.Add("idusuario");
            campos.Add("idpre_pro");
            campos.Add("justificacion");
            campos.Add("cantidad");
            campos.Add("tipo_ajuste");
            campos.Add("fecha_ajuste");
            return campos;
        }

        public override List<string> generarValores()
        {
            List<string> valores = new List<string>();
            valores.Add(idusuario);
            valores.Add(idpre_pro);
            valores.Add(justificacion);
            valores.Add(cantidad);
            valores.Add(tipo_ajuste);
            valores.Add(fecha_ajuste);
            return valores;
        }
    }
}
