using Excepciones;
using System;
using System.Collections;

namespace Dominio
{
    public class PlantaIndustrial : ElementoSCADA
    {
        private IManejadorDependencias<IElementoSCADA> dependencias;
        public override IList Dependencias
        {
            get
            {
                return dependencias.ElementosHijos;
            }
        }

        private string direccion;
        public string Direccion
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
        public string Ciudad
        {
            get
            {
                return ciudad;
            }
            set
            {
                if (Auxiliar.EsCiudadValida(value))
                {
                    ciudad = value.Trim();

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
            dependencias = new ManejadorDependenciasConLista<IElementoSCADA>(this);
        }

        public static PlantaIndustrial NombreDireccionCiudad(string unNombre, string unaDireccion, string unaCiudad)
        {
            return new PlantaIndustrial(unNombre, unaDireccion, unaCiudad);
        }

        private PlantaIndustrial(string unNombre, string unaDireccion, string unaCiudad) : base(unNombre)
        {
            Direccion = unaDireccion;
            Ciudad = unaCiudad;
            dependencias = new ManejadorDependenciasConLista<IElementoSCADA>(this);
        }

        public override void AgregarDependencia(IElementoSCADA elementoAAgregar)
        {
            dependencias.AgregarDependencia(elementoAAgregar);
        }

        public override void EliminarDependencia(IElementoSCADA elementoAEliminar)
        {
            dependencias.EliminarDependencia(elementoAEliminar);
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