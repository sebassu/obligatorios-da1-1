using System.Collections;

namespace Dominio
{
    public interface IManejadorDependencias<T> where T : ElementoSCADA
    {
        IList ElementosHijos { get; }
        void AgregarDependencia(ElementoSCADA elementoAAgregar);
        void EliminarDependencia(ElementoSCADA elementoAEliminar);
    }
}