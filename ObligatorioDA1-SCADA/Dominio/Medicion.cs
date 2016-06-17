using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Medicion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid ID { get; set; }

        private DateTime fechaMedicion;
        private decimal valorMedicion;

        private Medicion()
        {
            fechaMedicion = DateTime.Now;
            valorMedicion = 0;
        }

        public static Medicion FechaValor(DateTime unaFecha, decimal unValor)
        {
            return new Medicion(unaFecha, unValor);
        }

        private Medicion(DateTime unaFecha, decimal unValor)
        {
            valorMedicion = unValor;
            fechaMedicion = unaFecha;
        }

        public virtual DateTime Fecha
        {
            get
            {
                return fechaMedicion;
            }
            protected set
            {
                fechaMedicion = value;
            }
        }

        public virtual decimal Valor
        {
            get
            {
                return valorMedicion;
            }
            protected set
            {
                valorMedicion = value;
            }
        }
    }
}
