using Dominio;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    static class EntradaAlPrograma
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IAccesoADatos modelo = new AccesoADatosEnMemoria();
            Application.Run(new VentanaPrincipal(modelo));
        }
    }
}
