using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public abstract class ElementoSCADA : IComparable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Guid ID { get; set; }

        public abstract void AgregarDependencia(ElementoSCADA elementoAAgregar);
        public abstract void EliminarDependencia(ElementoSCADA elementoAEliminar);
        public abstract void AgregarVariable(Variable unaVariable);
        public abstract void EliminarVariable(Variable unaVariable);

        public virtual Tipo Tipo
        {
            get
            {
                return null;
            }
            set
            {
                return;
            }
        }

        public virtual List<ElementoSCADA> Dependencias
        {
            get
            {
                return new List<ElementoSCADA>();
            }
            protected set
            {
                return;
            }
        }

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

        [NotMapped]
        public virtual bool EnUso
        {
            get
            {
                return true;
            }
        }

        public virtual bool EsDePrimerNivel()
        {
            return elementoPadre == null;
        }

        protected uint cantidadAlarmasActivas;
        public virtual uint CantidadAlarmasActivas
        {
            get
            {
                return cantidadAlarmasActivas;
            }
            protected set
            {
                cantidadAdvertenciasActivas = value;
            }
        }

        protected uint cantidadAdvertenciasActivas;
        public virtual uint CantidadAdvertenciasActivas
        {
            get
            {
                return cantidadAdvertenciasActivas;
            }
            protected set
            {
                cantidadAdvertenciasActivas = value;
            }
        }

        protected ElementoSCADA elementoPadre;

        [InverseProperty("Dependencias")]
        public virtual ElementoSCADA ElementoPadre
        {
            get
            {
                return elementoPadre;
            }
            set
            {
                elementoPadre = value;
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

        protected ElementoSCADA(string unNombre) : this()
        {
            Nombre = unNombre;
        }

        protected ElementoSCADA()
        {
            ID = Guid.NewGuid();
        }

        public abstract override string ToString();
    }
}
