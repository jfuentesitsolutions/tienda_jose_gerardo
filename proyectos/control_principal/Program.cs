using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control_principal
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool nueva_instancia;
            using (Mutex mutex = new Mutex(true, Process.GetCurrentProcess().ProcessName, out nueva_instancia))
            {
                if (nueva_instancia)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new manejadorVentanas());
                }
                else
                {
                    MessageBox.Show("Hay una instancia del sistema ya inicializada","No se puede abrir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
                
        }
    }
}
