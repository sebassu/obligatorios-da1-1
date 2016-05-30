using System.Collections;

namespace Dominio
{
    public abstract class IElementoSCADA
    {
        public abstract string Nombre { get; set; }
        public abstract bool EnUso { get; set; }
        public abstract IElementoSCADA ElementoPadre { get; set; }
        public abstract uint CantidadAlarmasActivas { get; }
        public abstract uint CantidadAdvertenciasActivas { get; }
        public abstract IList Dependencias { get; }
        public abstract void AgregarDependencia(IElementoSCADA elementoAAgregar);
        public abstract void EliminarDependencia(IElementoSCADA elementoAEliminar);
        public abstract void AgregarVariable(Variable unaVariable);
        public abstract void EliminarVariable(Variable unaVariable);
    }
}
