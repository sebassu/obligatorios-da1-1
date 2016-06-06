using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public override void AgregarDependencia(ElementoSCADA elementoAAgregar)
        {
            dependencias.AgregarDependencia(elementoAAgregar);
        }

        public override void EliminarDependencia(ElementoSCADA elementoAEliminar)
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

        // A efectos del buen funcionamiento de Entity Framework.
        [Required]
        protected virtual IManejadorDependencias<Componente> DependenciasAux
        {
            get
            {
                return dependencias;
            }
            set
            {
                dependencias = value;
            }
        }
    }
}