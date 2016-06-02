using System.Diagnostics.CodeAnalysis;
using Excepciones;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Tipo
    {
        private Guid id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        protected virtual Guid ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string nombre;
        public string Nombre
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

        private Tipo()
        {
            nombre = "Tipo inválido.";
            descripcion = "Descripción inválida.";
            id = Guid.NewGuid();
        }

        private Tipo(string unNombre, string unaDescripcion)
        {
            Nombre = unNombre;
            Descripcion = unaDescripcion;
            id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            Tipo tipoAComparar = obj as Tipo;
            if (Auxiliar.NoEsNulo(tipoAComparar))
            {
                return id == tipoAComparar.id;
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