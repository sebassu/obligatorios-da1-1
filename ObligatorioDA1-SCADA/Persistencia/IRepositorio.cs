using System.Collections.Generic;

namespace Persistencia
{
    public interface IRepositorio<T> where T : class
    {
        List<T> Obtener();
        void Insertar(T entidad);
        void Eliminar(T entidadAEliminar);
        void Actualizar(T entidadAActualizar);
    }
}
