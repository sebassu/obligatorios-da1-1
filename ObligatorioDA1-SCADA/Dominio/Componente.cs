﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Dominio
{
    public abstract class Componente : IComparable
    {
        protected uint id;

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
                    throw new ArgumentException("Nombre inválido.");
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
            }
        }

        public void AgregarVariable(Variable unaVariable)
        {
            if (Auxiliar.NoEsNulo(unaVariable))
            {
                variables.Add(unaVariable);
                unaVariable.ComponentePadre = this;
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
            if (Auxiliar.NoEsNulo(componenteAComparar))
            {
                return id == componenteAComparar.id;
            }
            else
            {
                return false;
            }
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
