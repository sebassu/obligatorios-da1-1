using Excepciones;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class ManejadorDependenciasConLista<T> : IManejadorDependencias<T> where T : ElementoSCADA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        private ElementoSCADA elementoAsociado;

        private List<T> hijos;
        public IList ElementosHijos
        {
            get
            {
                return hijos.AsReadOnly();
            }
        }

        internal ManejadorDependenciasConLista(ElementoSCADA unElemento)
        {
            elementoAsociado = unElemento;
            hijos = new List<T>();
        }

        public void AgregarDependencia(ElementoSCADA elementoAAgregar)
        {
            T nuevaDependencia = elementoAAgregar as T;
            ElementoSCADA padreElementoAsociado = elementoAsociado.ElementoPadre;
            ElementoSCADA elementoABuscar = (Auxiliar.NoEsNulo(padreElementoAsociado) ? padreElementoAsociado : elementoAsociado);
            if (EsDependenciaValida(nuevaDependencia, elementoABuscar))
            {
                EliminarDependenciaDelPadreAnterior(elementoAAgregar);
                hijos.Add(nuevaDependencia);
                nuevaDependencia.ElementoPadre = elementoAsociado;
                hijos.Sort();
                elementoAsociado.IncrementarAlarmas(elementoAAgregar.CantidadAlarmasActivas);
                elementoAsociado.IncrementarAdvertencias(elementoAAgregar.CantidadAdvertenciasActivas);
            }
            else
            {
                throw new ElementoSCADAExcepcion("Elemento inválido recibido.");
            }
        }

        private static void EliminarDependenciaDelPadreAnterior(ElementoSCADA elementoAAgregar)
        {
            ElementoSCADA padreAnterior = elementoAAgregar.ElementoPadre;
            if (Auxiliar.NoEsNulo(padreAnterior))
            {
                padreAnterior.EliminarDependencia(elementoAAgregar);
            }
        }

        public void EliminarDependencia(ElementoSCADA elementoAEliminar)
        {
            T elementoCasteado = elementoAEliminar as T;
            if (hijos.Remove(elementoCasteado))
            {
                elementoAsociado.DecrementarAlarmas(elementoAEliminar.CantidadAlarmasActivas);
                elementoAsociado.DecrementarAdvertencias(elementoAEliminar.CantidadAdvertenciasActivas);
                hijos.Sort();
            }
            else
            {
                throw new ElementoSCADAExcepcion("El elemento recibido no se encontró/fue removido de la lista.");
            }
        }

        private static bool EsDependenciaValida(ElementoSCADA elementoActual, ElementoSCADA elementoABuscar)
        {
            if (elementoActual == null || elementoActual.Equals(elementoABuscar))
            {
                return false;
            }
            else
            {
                bool retorno = true;
                foreach (ElementoSCADA elementoIteracion in elementoActual.Dependencias)
                {
                    retorno &= EsDependenciaValida(elementoIteracion, elementoABuscar);
                }
                return retorno;
            }
        }
    }
}