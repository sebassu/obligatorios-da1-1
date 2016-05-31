using Excepciones;
using System.Collections;
using System.Collections.Generic;

namespace Dominio
{
    public class ManejadorDependenciasConLista<T> : IManejadorDependencias<T> where T : IElementoSCADA
    {
        private IElementoSCADA elementoAsociado;
        public IElementoSCADA ElementoAsociado
        {
            get
            {
                return elementoAsociado;
            }
        }

        private List<T> hijos;
        public IList ElementosHijos
        {
            get
            {
                return hijos.AsReadOnly();
            }
        }

        internal ManejadorDependenciasConLista(IElementoSCADA unElemento)
        {
            elementoAsociado = unElemento;
            hijos = new List<T>();
        }

        public void AgregarDependencia(IElementoSCADA elementoAAgregar)
        {
            T elementoCasteado = elementoAAgregar as T;
            if (EsDependenciaValida(elementoCasteado))
            {
                hijos.Add(elementoCasteado);
                elementoCasteado.ElementoPadre = elementoAsociado;
                hijos.Sort();
                elementoAsociado.IncrementarAlarmas(elementoAAgregar.CantidadAlarmasActivas);
                elementoAsociado.IncrementarAdvertencias(elementoAAgregar.CantidadAdvertenciasActivas);
            }
            else
            {
                throw new ElementoSCADAExcepcion("Elemento inválido recibido.");
            }
        }

        public void EliminarDependencia(IElementoSCADA elementoAEliminar)
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

        private bool EsDependenciaValida(T unElemento)
        {
            return Auxiliar.NoEsNulo(unElemento) && !unElemento.Equals(elementoAsociado) && !unElemento.Equals(elementoAsociado.ElementoPadre);
        }
    }
}