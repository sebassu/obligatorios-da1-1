using System.Collections.Generic;

namespace Dominio
{
    public class Instalacion : Componente
    {
        private List<ElementoSCADA> dependencias;
        public override List<ElementoSCADA> Dependencias
        {
            get
            {
                return dependencias;
            }
            protected set
            {
                dependencias = value;
            }
        }

        public override void AgregarDependencia(ElementoSCADA elementoAAgregar)
        {
            ManejadorDependenciasConLista<Componente>.AgregarDependencia(elementoAAgregar, dependencias, this);
        }

        public override void EliminarDependencia(ElementoSCADA elementoAEliminar)
        {
            ManejadorDependenciasConLista<Componente>.EliminarDependencia(elementoAEliminar, dependencias, this);
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
            dependencias = new List<ElementoSCADA>();
        }

        private Instalacion(string unNombre) : base(unNombre)
        {
            dependencias = new List<ElementoSCADA>();
        }

        public override string ToString()
        {
            return nombre + " (I)";
        }
    }
}