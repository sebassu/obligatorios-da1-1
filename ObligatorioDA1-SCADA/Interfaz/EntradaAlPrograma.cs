using Persistencia;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Interfaz
{
    static class EntradaAlPrograma
    {
        private readonly static string nombreArchivoEstrategia = "EstrategiaActual.dat";

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IAccesoADatos modelo = new AccesoADatosBaseDeDatos("name=ContextoSCADA");
            CargarEstrategia(modelo);
            Application.Run(new VentanaPrincipal(modelo));
            AppDomain.CurrentDomain.ProcessExit += new EventHandler((s, e) => SerializarEstrategia(s, e, modelo));
        }

        private static void CargarEstrategia(IAccesoADatos sistemaActual)
        {
            if (File.Exists(nombreArchivoEstrategia))
            {
                try
                {
                    var stream = File.OpenRead(nombreArchivoEstrategia);
                    var formatter = new BinaryFormatter();
                    object aux = formatter.Deserialize(stream);
                    sistemaActual.ManejadorIncidentes = (EstrategiaGuardadoIncidentes)aux;
                    return;
                }
                catch (SerializationException)
                {
                    Console.WriteLine("Error al deserializar");
                }
            }
            sistemaActual.ManejadorIncidentes = new EstrategiaBaseDeDatos();
        }

        private static void SerializarEstrategia(object sender, EventArgs e, IAccesoADatos sistemaActual)
        {
            if (File.Exists(nombreArchivoEstrategia))
            {
                File.Delete(nombreArchivoEstrategia);
            }
            FileStream stream = File.Create(nombreArchivoEstrategia);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, sistemaActual.ManejadorIncidentes);
            stream.Close();
        }
    }
}
