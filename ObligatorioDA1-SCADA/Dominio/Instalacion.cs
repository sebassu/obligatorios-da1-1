using System;
using System.Collections;
using System.Collections.Generic;

namespace Dominio
{
    public class Instalacion : Componente
    {
        private static uint ProximaIdAAsignar;

        private List<Componente> dependencias;
        public override IList Dependencias
        {
            get
            {
                return dependencias.AsReadOnly();
            }
        }

        public override void AgregarComponente(Componente unComponente)
        {
            if (EsComponenteValido(unComponente))
            {
                dependencias.Add(unComponente);
                dependencias.Sort();
                unComponente.InstalacionPadre = this;
                uint cantidadDispositivosAVariar = 0;
                if (unComponente is Dispositivo)
                {
                    cantidadDispositivosAVariar = 1;
                }
                else if (unComponente is Instalacion)
                {
                    cantidadDispositivosAVariar = ((Instalacion)unComponente).CantidadDispositivosHijos;
                }
                cantidadDispositivosHijos += cantidadDispositivosAVariar;
                if (Auxiliar.NoEsNulo(instalacionPadre))
                {
                    instalacionPadre.cantidadDispositivosHijos += cantidadDispositivosAVariar;
                }
            }
            else
            {
                throw new ArgumentException("Componente inválido recibido.");
            }
        }

        public override void EliminarComponente(Componente unComponente)
        {
            if (EsComponenteValido(unComponente))
            {
                dependencias.Remove(unComponente);
                dependencias.Sort();
                uint cantidadDispositivosAVariar = 0;
                if (unComponente is Dispositivo)
                {
                    cantidadDispositivosAVariar = 1;
                }
                else if (unComponente is Instalacion)
                {
                    cantidadDispositivosAVariar = ((Instalacion)unComponente).CantidadDispositivosHijos;
                }
                cantidadDispositivosHijos -= cantidadDispositivosAVariar;
                if (Auxiliar.NoEsNulo(instalacionPadre))
                {
                    instalacionPadre.cantidadDispositivosHijos -= cantidadDispositivosAVariar;
                }
            }
            else
            {
                throw new ArgumentException("Componente inválido recibido.");
            }
        }

        private bool EsComponenteValido(Componente unComponente)
        {
            return Auxiliar.NoEsNulo(unComponente) && !unComponente.Equals(this);
        }

        public static Instalacion InstalacionInvalida()
        {
            return new Instalacion();
        }

        public static Instalacion ConstructorNombre(string unNombre)
        {
            return new Instalacion(unNombre);
        }

        protected override void IncrementarAlarmasPadre()
        {
            instalacionPadre.IncrementarAlarmas();
        }

        private Instalacion()
        {
            nombre = "Nombre inválido.";
            dependencias = new List<Componente>();
            variables = new List<Variable>();
            id = ProximaIdAAsignar++;
        }

        private Instalacion(string unNombre)
        {
            Nombre = unNombre;
            dependencias = new List<Componente>();
            variables = new List<Variable>();
            id = ProximaIdAAsignar++;
        }

        public override string ToString()
        {
            return nombre + " (I)";
        }

        private uint cantidadDispositivosHijos;
        public uint CantidadDispositivosHijos
        {
            get
            {
                return cantidadDispositivosHijos;
            }
        }
    }
}