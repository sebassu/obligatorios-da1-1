using System.Diagnostics.CodeAnalysis;
using Excepciones;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Tipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Guid ID { get; set; }

        private string nombre;
        public virtual string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (Auxiliar.EsTextoValido(value))
                {
                    nombre = value.Trim();
                }
                else
                {
                    throw new TipoExcepcion("Nombre inválido.");
                }
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
                    throw new TipoExcepcion("Descripción inválida.");
                }
            }
        }

        internal static Tipo TipoInvalido()
        {
            return new Tipo();
        }

        public static Tipo NombreDescripcion(string unNombre, string unaDescripcion)
        {
            return new Tipo(unNombre, unaDescripcion);
        }

        private Tipo() : this("Tipo inválido.", "Descripción inválida.") { }

        private Tipo(string unNombre, string unaDescripcion)
        {
            Nombre = unNombre;
            Descripcion = unaDescripcion;
            ID = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            Tipo tipoAComparar = obj as Tipo;
            if (Auxiliar.NoEsNulo(tipoAComparar))
            {
                return ID.Equals(tipoAComparar.ID) || nombre == tipoAComparar.Nombre;
            }
            else
            {
                return false;
            }
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}