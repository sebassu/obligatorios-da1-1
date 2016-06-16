using Excepciones;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Incidente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid ID { get; set; }

        [ForeignKey("ElementoSCADA")]
        private Guid idElementoAsociado;
        public virtual Guid IdElementoAsociado
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

        public static Incidente IDElementoDescripcionFechaGravedad(Guid idElementoSCADA, string unaDescripcion,
            DateTime unaFecha, byte unNivelDeGravedad)
        {
            return new Incidente(idElementoSCADA, unaDescripcion, unaFecha, unNivelDeGravedad);
        }

        private Incidente(Guid idElementoSCADA, string unaDescripcion, DateTime unaFecha, byte unNivelDeGravedad)
        {
            idElementoAsociado = idElementoSCADA;
            Descripcion = unaDescripcion;
            Fecha = unaFecha;
            NivelGravedad = unNivelDeGravedad;
        }
    }
}