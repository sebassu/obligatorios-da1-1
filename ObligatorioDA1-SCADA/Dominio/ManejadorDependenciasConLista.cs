using Excepciones;
using System.Collections.Generic;

namespace Dominio
{
    public static class ManejadorDependenciasConLista<T> where T : ElementoSCADA
    {

        public static void AgregarDependencia(ElementoSCADA elementoAAgregar, List<ElementoSCADA> hijos, ElementoSCADA elementoAsociado)
        {
            T nuevaDependencia = elementoAAgregar as T;
            ElementoSCADA padreElementoAsociado = elementoAsociado.ElementoPadre;
            ElementoSCADA elementoABuscar = (Auxiliar.NoEsNulo(padreElementoAsociado) ? padreElementoAsociado : elementoAsociado);
            if (EsDependenciaValida(nuevaDependencia, elementoABuscar))
            {
                EliminarDependenciaDelPadreAnterior(elementoAAgregar, hijos, elementoAsociado);
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

        private static void EliminarDependenciaDelPadreAnterior(ElementoSCADA elementoAEliminar, List<ElementoSCADA> hijos, ElementoSCADA elementoAsociado)
        {
            ElementoSCADA padreAnterior = elementoAEliminar.ElementoPadre;
            if (Auxiliar.NoEsNulo(padreAnterior))
            {
                padreAnterior.EliminarDependencia(elementoAEliminar);
            }
        }

        public static void EliminarDependencia(ElementoSCADA elementoAEliminar, List<ElementoSCADA> hijos, ElementoSCADA elementoAsociado)
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