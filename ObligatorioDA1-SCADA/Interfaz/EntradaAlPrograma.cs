using Persistencia;
using System;
using System.Windows.Forms;
using Dominio;

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
            IAccesoADatos modelo = new AccesoADatosBaseDeDatos();
            //modelo.EliminarDatos();
            Application.Run(new VentanaPrincipal(modelo));
        }
    }
}
