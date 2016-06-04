using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public abstract class IElementoSCADA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }

        public abstract string Nombre { get; set; }
        public abstract bool EnUso { get; set; }
        public abstract IElementoSCADA ElementoPadre { get; set; }
        public abstract uint CantidadAlarmasActivas { get; }
        public abstract uint CantidadAdvertenciasActivas { get; }

        [NotMapped]
        public abstract IList Dependencias { get; }
        public abstract void AgregarDependencia(IElementoSCADA elementoAAgregar);
        public abstract void EliminarDependencia(IElementoSCADA elementoAEliminar);
        public abstract void AgregarVariable(Variable unaVariable);
        public abstract void EliminarVariable(Variable unaVariable);
        internal abstract void IncrementarAlarmas(uint valor);
        internal abstract void DecrementarAlarmas(uint valor);
        internal abstract void IncrementarAdvertencias(uint valor);
        internal abstract void DecrementarAdvertencias(uint valor);
    }
}
