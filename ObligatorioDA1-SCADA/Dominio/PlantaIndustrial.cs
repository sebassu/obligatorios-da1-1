using Excepciones;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dominio
{
    public class PlantaIndustrial : ElementoSCADA
    {
        private List<IElementoSCADA> dependencias;
        public override IList Dependencias
        {
            get
            {
                return dependencias.AsReadOnly();
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

        private PlantaIndustrial()
        {
            nombre = "Planta industrial inválida.";
            direccion = "Dirección inválida.";
            ciudad = "Ciudad inválida.";
            dependencias = new List<IElementoSCADA>();
            id = Guid.NewGuid();
        }

        public static PlantaIndustrial NombreDireccionCiudad(string unNombre, string unaDireccion, string unaCiudad)
        {
            return new PlantaIndustrial(unNombre, unaDireccion, unaCiudad);
        }

        private PlantaIndustrial(string unNombre, string unaDireccion, string unaCiudad)
        {
            Nombre = unNombre;
            Direccion = unaDireccion;
            Ciudad = unaCiudad;
            dependencias = new List<IElementoSCADA>();
            id = Guid.NewGuid();
        }

        public override void AgregarDependencia(IElementoSCADA elementoAAgregar)
        {
            if (EsDependenciaValida(elementoAAgregar))
            {
                dependencias.Add(elementoAAgregar);
                dependencias.Sort();
                elementoAAgregar.ElementoPadre = this;
            }
            else
            {
                throw new ElementoSCADAExcepcion("Elemento inválido recibido.");
            }
        }

        public override void EliminarDependencia(IElementoSCADA elementoAEliminar)
        {
            if (EsDependenciaValida(elementoAEliminar))
            {
                dependencias.Remove(elementoAEliminar);
                dependencias.Sort();
            }
            else
            {
                throw new ElementoSCADAExcepcion("Elemento inválido recibido.");
            }
        }

        private bool EsDependenciaValida(IElementoSCADA unElemento)
        {
            return Auxiliar.NoEsNulo(unElemento) && !unElemento.Equals(this) && !unElemento.Equals(elementoPadre);
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