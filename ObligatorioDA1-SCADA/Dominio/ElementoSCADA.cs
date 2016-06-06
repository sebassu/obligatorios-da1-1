using Excepciones;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public abstract class ElementoSCADA : IComparable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }

        [NotMapped]
        public abstract IList Dependencias { get; }

        public abstract void AgregarDependencia(ElementoSCADA elementoAAgregar);
        public abstract void EliminarDependencia(ElementoSCADA elementoAEliminar);
        public abstract void AgregarVariable(Variable unaVariable);
        public abstract void EliminarVariable(Variable unaVariable);

        protected string nombre;
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
                    throw new ElementoSCADAExcepcion("Se recibió un nombre inválido.");
                }
            }
        }

        public virtual bool EnUso
        {
            get
            {
                return true;
            }
        }

        protected uint cantidadAlarmasActivas;
        public virtual uint CantidadAlarmasActivas
        {
            get
            {
                return cantidadAlarmasActivas;
            }
        }

        protected uint cantidadAdvertenciasActivas;
        public virtual uint CantidadAdvertenciasActivas
        {
            get
            {
                return cantidadAdvertenciasActivas;
            }
        }

        protected ElementoSCADA elementoPadre;
        public virtual ElementoSCADA ElementoPadre
        {
            get
            {
                return elementoPadre;
            }
            set
            {
                ElementoSCADA elementoCasteado = value as ElementoSCADA;
                if (Auxiliar.NoEsNulo(value) && value.Dependencias.Contains(this))
                {
                    elementoPadre = elementoCasteado;
                }
                else
                {
                    throw new ElementoSCADAExcepcion("El elemento recibido es inválido.");
                }
            }
        }

        internal virtual void IncrementarAlarmas(uint valor = 1)
        {
            cantidadAlarmasActivas += valor;
            if (Auxiliar.NoEsNulo(elementoPadre))
            {
                elementoPadre.IncrementarAlarmas(valor);
            }
        }

        internal virtual void DecrementarAlarmas(uint valor = 1)
        {
            if (cantidadAlarmasActivas < valor)
            {
                throw new ElementoSCADAExcepcion("La cantidad de alarmas activas resultaría negativa.");
            }
            else
            {
                cantidadAlarmasActivas -= valor;
                if (Auxiliar.NoEsNulo(elementoPadre))
                {
                    elementoPadre.DecrementarAlarmas(valor);
                }
            }
        }

        internal virtual void IncrementarAdvertencias(uint valor = 1)
        {
            cantidadAdvertenciasActivas += valor;
            if (Auxiliar.NoEsNulo(elementoPadre))
            {
                elementoPadre.IncrementarAdvertencias(valor);
            }
        }

        internal virtual void DecrementarAdvertencias(uint valor = 1)
        {
            if (cantidadAdvertenciasActivas < valor)
            {
                throw new ElementoSCADAExcepcion("La cantidad de alarmas activas resultaría negativa.");
            }
            else
            {
                cantidadAdvertenciasActivas -= valor;
                if (Auxiliar.NoEsNulo(elementoPadre))
                {
                    elementoPadre.DecrementarAdvertencias(valor);
                }
            }
        }

        public override bool Equals(object obj)
        {
            ElementoSCADA elementoAComparar = obj as ElementoSCADA;
            if (Auxiliar.NoEsNulo(elementoAComparar))
            {
                return ID == elementoAComparar.ID;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(object obj)
        {
            ElementoSCADA elementoAComparar = obj as ElementoSCADA;
            if (Auxiliar.NoEsNulo(elementoAComparar))
            {
                return nombre.CompareTo(elementoAComparar.Nombre);
            }
            else
            {
                throw new ElementoSCADAExcepcion("Comparación de tipos incompatibles.");
            }
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public abstract override string ToString();

        protected ElementoSCADA(string unNombre) : this()
        {
            Nombre = unNombre;
        }

        protected ElementoSCADA()
        {
            ID = Guid.NewGuid();
        }
    }
}
