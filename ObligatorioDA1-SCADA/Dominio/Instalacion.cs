using System.Collections;
using System.Collections.Generic;
using Excepciones;
using System;

namespace Dominio
{
    public class Instalacion : Componente
    {
        private List<Componente> dependencias;
        public override IList Dependencias
        {
            get
            {
                return dependencias.AsReadOnly();
            }
        }

        public override void AgregarDependencia(IElementoSCADA elementoAAgregar)
        {
            Componente elementoCasteado = elementoAAgregar as Componente;
            if (EsDependenciaValida(elementoCasteado))
            {
                dependencias.Add(elementoCasteado);
                dependencias.Sort();
                IncrementarAlarmas(elementoAAgregar.CantidadAlarmasActivas);
                IncrementarAdvertencias(elementoAAgregar.CantidadAdvertenciasActivas);
                elementoCasteado.ElementoPadre = this;
            }
            else
            {
                throw new ElementoSCADAExcepcion("Elemento inválido recibido.");
            }
        }

        public override void EliminarDependencia(IElementoSCADA elementoAEliminar)
        {
            Componente elementoCasteado = elementoAEliminar as Componente;
            if (EsDependenciaValida(elementoCasteado))
            {
                if (dependencias.Remove(elementoCasteado))
                {
                    DecrementarAlarmas(elementoAEliminar.CantidadAlarmasActivas);
                    DecrementarAdvertencias(elementoAEliminar.CantidadAdvertenciasActivas);
                }
                dependencias.Sort();
            }
            else
            {
                throw new ElementoSCADAExcepcion("Elemento inválido recibido.");
            }
        }

        private bool EsDependenciaValida(Componente unElemento)
        {
            return Auxiliar.NoEsNulo(unElemento) && !unElemento.Equals(this) && !unElemento.Equals(elementoPadre);
        }

        internal static Instalacion InstalacionInvalida()
        {
            return new Instalacion();
        }

        public static Instalacion ConstructorNombre(string unNombre)
        {
            return new Instalacion(unNombre);
        }

        private Instalacion()
        {
            nombre = "Instalación inválida.";
            dependencias = new List<Componente>();
            variables = new List<Variable>();
            id = Guid.NewGuid();
        }

        private Instalacion(string unNombre)
        {
            Nombre = unNombre;
            dependencias = new List<Componente>();
            variables = new List<Variable>();
            id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return nombre + " (I)";
        }
    }
}