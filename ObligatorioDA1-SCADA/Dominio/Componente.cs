using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public abstract class Componente : IComparable
    {
        protected uint id;

        public abstract IList Dependencias { get; }

        public abstract void AgregarComponente(Componente unComponente);

        public abstract void EliminarComponente(Componente unComponente);

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
                    throw new ArgumentException("Se ingresó un nombre inválido.");
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

        public virtual void IncrementarAlarmas()
        {
            cantidadAlarmasActivas = cantidadAlarmasActivas + 1;
            if (Auxiliar.NoEsNulo(instalacionPadre))
            {
                IncrementarAlarmasPadre();
            }
        }

        protected abstract void IncrementarAlarmasPadre();

        public void DecrementarAlarmas()
        {
            if (cantidadAlarmasActivas == 0)
            {
                throw new InvalidOperationException("La cantidad de alarmas activas es cero.");
            }
            else
            {
                cantidadAlarmasActivas = cantidadAlarmasActivas - 1;
                if (Auxiliar.NoEsNulo(instalacionPadre))
                {
                    instalacionPadre.DecrementarAlarmas();
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
                throw new ArgumentException("Variable nula recibida.");
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
                throw new ArgumentException("Variable nula recibida.");
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
                    throw new ArgumentException("La instalación a asignar no contiene al componente.");
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
                throw new ArgumentException("Comparación de tipos incompatibles.");
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
