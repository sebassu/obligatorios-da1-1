using System.Collections;

namespace Dominio
{
    internal interface IManejadorDependencias<T> where T : IElementoSCADA
    {
        IElementoSCADA ElementoAsociado { get; }
        IList ElementosHijos { get; }
        void AgregarDependencia(IElementoSCADA elementoAAgregar);
        void EliminarDependencia(IElementoSCADA elementoAEliminar);
    }
}