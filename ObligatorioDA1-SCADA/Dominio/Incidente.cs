using Excepciones;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Incidente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Guid ID { get; set; }

        private Guid idElementoAsociado;
        internal virtual Guid IdElementoAsociado
        {
            get
            {
                return idElementoAsociado;
            }
            set
            {
                idElementoAsociado = value;
            }
        }

        private string descripcion;
        public virtual string Descripcion
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
        public virtual DateTime Fecha
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
        public virtual byte NivelGravedad
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

        public static Incidente ElementoDescripcionFechaGravedad(ElementoSCADA unElementoSCADA, string unaDescripcion,
            DateTime unaFecha, byte unNivelDeGravedad)
        {
            return new Incidente(unElementoSCADA, unaDescripcion, unaFecha, unNivelDeGravedad);
        }

        private Incidente(ElementoSCADA unElementoSCADA, string unaDescripcion, DateTime unaFecha, byte unNivelDeGravedad)
        {
            idElementoAsociado = unElementoSCADA.ID;
            Descripcion = unaDescripcion;
            Fecha = unaFecha;
            NivelGravedad = unNivelDeGravedad;
        }
    }
}