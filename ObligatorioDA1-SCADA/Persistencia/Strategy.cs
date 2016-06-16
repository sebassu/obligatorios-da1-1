using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public abstract class Strategy : IRepositorio<Incidente>
    {
        public abstract void Actualizar(Incidente entidadAActualizar);
        public abstract void Eliminar(Incidente entidadAEliminar);
        public abstract void Insertar(Incidente entidad);
        public abstract List<Incidente> Obtener();
    }
}
