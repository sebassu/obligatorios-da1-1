using Excepciones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PruebasUnitarias")]
[assembly: AssemblyVersion("1.0")]
namespace Dominio
{
    public abstract class Componente : IComparable
    {
        protected uint id;

        public abstract IList Dependencias { get; }

        public abstract void AgregarComponente(Componente unComponente);

        public abstract void EliminarComponente(Componente unComponente);

        public virtual bool EnUso
        {
            get
            {
                return true;
            }
            set
            {
                throw new ComponenteExcepcion("No es posible desactivar al componente.");
            }
        }

        protected string nombre;
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
                    throw new ComponenteExcepcion("Se ingresó un nombre inválido.");
                }
            }
        }

        protected List<Variable> variables;
        public IList Variables
        {
            get
            {
                return variables.AsReadOnly();
            }
        }

        protected uint cantidadAlarmasActivas;
        public uint CantidadAlarmasActivas
        {
            get
            {
                return cantidadAlarmasActivas;
            }
        }

        protected uint cantidadAdvertenciasActivas;
        public uint CantidadAdvertenciasActivas
        {
            get
            {
                return cantidadAdvertenciasActivas;
            }
        }

        internal virtual void IncrementarAlarmas(uint valor = 1)
        {
            cantidadAlarmasActivas += valor;
            if (Auxiliar.NoEsNulo(instalacionPadre) && EnUso)
            {
                instalacionPadre.IncrementarAlarmas(valor);
            }
        }

        internal void DecrementarAlarmas(uint valor = 1)
        {
            if (cantidadAlarmasActivas < valor)
            {
                throw new ComponenteExcepcion("La cantidad de alarmas activas resultaría negativa.");
            }
            else
            {
                cantidadAlarmasActivas -= valor;
                if (Auxiliar.NoEsNulo(instalacionPadre) && EnUso)
                {
                    instalacionPadre.DecrementarAlarmas(valor);
                }
            }
        }

        internal virtual void IncrementarAdvertencias(uint valor = 1)
        {
            cantidadAdvertenciasActivas += valor;
            if (Auxiliar.NoEsNulo(instalacionPadre) && EnUso)
            {
                instalacionPadre.IncrementarAdvertencias(valor);
            }
        }

        internal void DecrementarAdvertencias(uint valor = 1)
        {
            if (cantidadAdvertenciasActivas < valor)
            {
                throw new ComponenteExcepcion("La cantidad de alarmas activas resultaría negativa.");
            }
            else
            {
                cantidadAdvertenciasActivas -= valor;
                if (Auxiliar.NoEsNulo(instalacionPadre) && EnUso)
                {
                    instalacionPadre.DecrementarAdvertencias(valor);
                }
            }
        }

        public void AgregarVariable(Variable unaVariable)
        {
            if (Auxiliar.NoEsNulo(unaVariable))
            {
                variables.Add(unaVariable);
                variables.Sort();
                unaVariable.ComponentePadre = this;
            }
            else
            {
                throw new ComponenteExcepcion("Variable nula recibida.");
            }
        }

        public void EliminarVariable(Variable unaVariable)
        {
            if (Auxiliar.NoEsNulo(unaVariable))
            {
                variables.Remove(unaVariable);
                variables.Sort();
            }
            else
            {
                throw new ComponenteExcepcion("Variable nula recibida.");
            }
        }

        protected Instalacion instalacionPadre;
        public Instalacion InstalacionPadre
        {
            get
            {
                return instalacionPadre;
            }
            set
            {
                if (Auxiliar.NoEsNulo(value) && value.Dependencias.Contains(this))
                {
                    instalacionPadre = value;
                }
                else
                {
                    throw new ComponenteExcepcion("La instalación a asignar no contiene al componente.");
                }
            }
        }

        public override bool Equals(object unObjeto)
        {
            Componente componenteAComparar = unObjeto as Componente;
            if (Auxiliar.NoEsNulo(componenteAComparar) && SonDeTiposIguales(componenteAComparar))
            {
                return id == componenteAComparar.id;
            }
            else
            {
                return false;
            }
        }

        private bool SonDeTiposIguales(object componenteAComparar)
        {
            return GetType().Equals(componenteAComparar.GetType());
        }

        public int CompareTo(object unObjeto)
        {
            Componente componenteAComparar = unObjeto as Componente;
            if (Auxiliar.NoEsNulo(componenteAComparar))
            {
                return nombre.CompareTo(componenteAComparar.Nombre);
            }
            else
            {
                throw new ComponenteExcepcion("Comparación de tipos incompatibles.");
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
