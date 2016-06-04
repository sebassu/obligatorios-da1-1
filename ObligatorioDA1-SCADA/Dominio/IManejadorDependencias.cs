using System.Collections;

namespace Dominio
{
    public interface IManejadorDependencias<T> where T : IElementoSCADA
    {
        IList ElementosHijos { get; }
        void AgregarDependencia(IElementoSCADA elementoAAgregar);
        void EliminarDependencia(IElementoSCADA elementoAEliminar);
    }
}