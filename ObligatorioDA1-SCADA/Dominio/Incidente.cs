using Excepciones;
using System;

namespace Dominio
{
    public class Incidente
    {
        private string descripcion;
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                if (Auxiliar.EsTextoValido(value))
                {
                    descripcion = value.Trim();
                }
                else
                {
                    throw new IncidenteExcepcion("Descripción inválida.");
                }
            }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }

        private byte nivelGravedad;
        public byte NivelGravedad
        {
            get
            {
                return nivelGravedad;
            }
            set
            {
                if (Auxiliar.EsNivelDeGravedadValido(value))
                {
                    nivelGravedad = value;
                }
                else
                {
                    throw new IncidenteExcepcion("Nivel de gravedad inválido.");
                }
            }
        }

        public static Incidente IncidenteInvalido()
        {
            return new Incidente();
        }

        private Incidente()
        {
            fecha = default(DateTime);
            nivelGravedad = 0;
            descripcion = "Descripción inválida.";
        }
    }
}