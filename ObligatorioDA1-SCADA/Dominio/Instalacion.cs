using System.Collections;
using System.Collections.Generic;
using System;

namespace Dominio
{
    public class Instalacion : Componente
    {
        private IManejadorDependencias<Componente> dependencias;
        public override IList Dependencias
        {
            get
            {
                return dependencias.ElementosHijos;
            }
        }

        public override void AgregarDependencia(IElementoSCADA elementoAAgregar)
        {
            dependencias.AgregarDependencia(elementoAAgregar);
        }

        public override void EliminarDependencia(IElementoSCADA elementoAEliminar)
        {
            dependencias.EliminarDependencia(elementoAEliminar);
        }

        internal static Instalacion InstalacionInvalida()
        {
            return new Instalacion();
        }

        public static Instalacion ConstructorNombre(string unNombre)
        {
            return new Instalacion(unNombre);
        }

        private Instalacion() : base()
        {
            nombre = "Instalación inválida.";
            dependencias = new ManejadorDependenciasConLista<Componente>(this);
        }

        private Instalacion(string unNombre) : base(unNombre)
        {
            dependencias = new ManejadorDependenciasConLista<Componente>(this);
        }

        public override string ToString()
        {
            return nombre + " (I)";
        }
    }
}