using Dominio;
using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;

namespace Persistencia
{
    [Serializable]
    public class EstrategiaArchivoDeTexto : EstrategiaGuardadoIncidentes
    {
        [NonSerialized]
        private List<Incidente> incidentesRegistrados;
        private string ruta = "HistorialIncidentes.txt";
        private char separador = '^';

        public EstrategiaArchivoDeTexto()
        {
            incidentesRegistrados = new List<Incidente>();
            if (!File.Exists(ruta))
            {
                try
                {
                    File.Create(ruta);
                }
                catch (Exception)
                {
                    throw new AccesoADatosExcepcion("Error al crear el archivo de texto.");
                }
            }
            else
            {
                CargarDatosDeArchivo();
            }
        }

        private void CargarDatosDeArchivo()
        {
            try
            {
                string[] lineasLeidas = File.ReadAllLines(ruta);
                foreach (string linea in lineasLeidas)
                {
                    incidentesRegistrados.Add(RecomponerIncidenteDeAtributos(linea));
                }
            }
            catch (Exception)
            {
                throw new AccesoADatosExcepcion("Error al leer el archivo de texto.");
            }
        }

        private Incidente RecomponerIncidenteDeAtributos(string linea)
        {
            try
            {
                string[] atributos = linea.Split(separador);
                Guid idElementoAsociado = Guid.Parse(atributos[0]);
                DateTime fecha = DateTime.Parse(atributos[1]);
                byte nivelDeGravedad = byte.Parse(atributos[2]);
                string descripcion = atributos[3];
                return Incidente.IDElementoDescripcionFechaGravedad(idElementoAsociado, descripcion, fecha, nivelDeGravedad);
            }
            catch (Exception)
            {
                throw new AccesoADatosExcepcion("Error al recomponer un incidente.");
            }
        }

        public override void Insertar(Incidente entidad)
        {
            try
            {
                string linea = string.Format("{0}" + separador + "{1}" + separador + "{2}" + separador + "{3}", entidad.IdElementoAsociado,
                    entidad.Fecha, entidad.NivelGravedad, entidad.Descripcion) + Environment.NewLine;
                File.AppendAllText(ruta, linea);
            }
            catch (Exception)
            {
                throw new AccesoADatosExcepcion("Error al guardar en archivo.");
            }
            incidentesRegistrados.Add(entidad);
        }

        public override List<Incidente> Obtener()
        {
            if (incidentesRegistrados == null)
            {
                incidentesRegistrados = new List<Incidente>();
                CargarDatosDeArchivo();
            }
            return incidentesRegistrados;
        }
    }
}