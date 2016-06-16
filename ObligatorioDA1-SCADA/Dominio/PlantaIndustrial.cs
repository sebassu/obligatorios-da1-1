using Excepciones;
using System.Collections.Generic;

namespace Dominio
{
    public class PlantaIndustrial : ElementoSCADA
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

        private string direccion;
        public virtual string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                string direccionASetear = value.Trim();
                if (Auxiliar.EsDireccionValida(direccionASetear))
                {
                    direccion = direccionASetear;

                }
                else
                {
                    throw new ElementoSCADAExcepcion("Se recibió una dirección inválida.");
                }
            }
        }

        private string ciudad;
        public virtual string Ciudad
        {
            get
            {
                return ciudad;
            }
            set
            {
                string ciudadASetear = value.Trim();
                if (Auxiliar.EsCiudadValida(value))
                {
                    ciudad = ciudadASetear;
                }
                else
                {
                    throw new ElementoSCADAExcepcion("Se recibió una ciudad inválida.");
                }
            }
        }

        internal static PlantaIndustrial PlantaIndustrialInvalida()
        {
            return new PlantaIndustrial();
        }

        private PlantaIndustrial() : base()
        {
            nombre = "Planta industrial inválida.";
            direccion = "Dirección inválida.";
            ciudad = "Ciudad inválida.";
            dependencias = new List<ElementoSCADA>();
        }

        public static PlantaIndustrial NombreDireccionCiudad(string unNombre, string unaDireccion, string unaCiudad)
        {
            return new PlantaIndustrial(unNombre, unaDireccion, unaCiudad);
        }

        private PlantaIndustrial(string unNombre, string unaDireccion, string unaCiudad) : base(unNombre)
        {
            Direccion = unaDireccion;
            Ciudad = unaCiudad;
            dependencias = new List<ElementoSCADA>();
        }

        public override void AgregarDependencia(ElementoSCADA elementoAAgregar)
        {
            ManejadorDependenciasConLista<ElementoSCADA>.AgregarDependencia(elementoAAgregar, dependencias, this);
        }

        public override void EliminarDependencia(ElementoSCADA elementoAEliminar)
        {
            ManejadorDependenciasConLista<ElementoSCADA>.EliminarDependencia(elementoAEliminar, dependencias, this);
        }

        public override void AgregarVariable(Variable unaVariable)
        {
            throw new ElementoSCADAExcepcion("No es posible asignarle variables a Plantas Industriales.");
        }

        public override void EliminarVariable(Variable unaVariable)
        {
            throw new ElementoSCADAExcepcion("No es posible asignarle variables a Plantas Industriales (ni eliminarlas por tanto).");
        }

        public override string ToString()
        {
            return nombre + " (P)";
        }
    }
}