using System;
using System.Collections;
using System.Collections.Generic;

namespace Dominio
{
    public class Instalacion : Componente
    {
        private static uint proximaIdAAsignar;

        private List<Componente> dependencias;
        public IList Dependencias
        {
            get
            {
                return dependencias.AsReadOnly();
            }
        }

        public void AgregarComponente(Componente unComponente)
        {
            if (Auxiliar.NoEsNulo(unComponente))
            {
                dependencias.Add(unComponente);
                unComponente.InstalacionPadre = this;
            }
            else
            {
                throw new ArgumentException("Componente inválido recibido.");
            }
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
            id = proximaIdAAsignar++;
        }

        private Instalacion(string unNombre)
        {
            Nombre = unNombre;
            dependencias = new List<Componente>();
            variables = new List<Variable>();
            id = proximaIdAAsignar++;
        }
    }
}