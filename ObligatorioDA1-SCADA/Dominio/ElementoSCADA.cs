using Excepciones;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public abstract class ElementoSCADA : IElementoSCADA, IComparable
    {
        protected Guid id;

        protected string nombre;
        public override string Nombre
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

        public override bool EnUso
        {
            get
            {
                return true;
            }
            set
            {
                throw new ElementoSCADAExcepcion("No es posible desactivar al elemento.");
            }
        }

        protected uint cantidadAlarmasActivas;
        public override uint CantidadAlarmasActivas
        {
            get
            {
                return cantidadAlarmasActivas;
            }
        }

        protected uint cantidadAdvertenciasActivas;
        public override uint CantidadAdvertenciasActivas
        {
            get
            {
                return cantidadAdvertenciasActivas;
            }
        }

        protected IElementoSCADA elementoPadre;
        public override IElementoSCADA ElementoPadre
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

        internal override void IncrementarAlarmas(uint valor = 1)
        {
            cantidadAlarmasActivas += valor;
            if (Auxiliar.NoEsNulo(elementoPadre) && EnUso)
            {
                elementoPadre.IncrementarAlarmas(valor);
            }
        }

        internal override void DecrementarAlarmas(uint valor = 1)
        {
            if (cantidadAlarmasActivas < valor)
            {
                throw new ElementoSCADAExcepcion("La cantidad de alarmas activas resultaría negativa.");
            }
            else
            {
                cantidadAlarmasActivas -= valor;
                if (Auxiliar.NoEsNulo(elementoPadre) && EnUso)
                {
                    elementoPadre.DecrementarAlarmas(valor);
                }
            }
        }

        internal override void IncrementarAdvertencias(uint valor = 1)
        {
            cantidadAdvertenciasActivas += valor;
            if (Auxiliar.NoEsNulo(elementoPadre) && EnUso)
            {
                elementoPadre.IncrementarAdvertencias(valor);
            }
        }

        internal override void DecrementarAdvertencias(uint valor = 1)
        {
            if (cantidadAdvertenciasActivas < valor)
            {
                throw new ElementoSCADAExcepcion("La cantidad de alarmas activas resultaría negativa.");
            }
            else
            {
                cantidadAdvertenciasActivas -= valor;
                if (Auxiliar.NoEsNulo(elementoPadre) && EnUso)
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
                return id == elementoAComparar.id;
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
    }
}
