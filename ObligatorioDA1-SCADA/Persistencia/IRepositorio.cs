using System;
using System.Collections.Generic;

namespace Persistencia
{
    interface IRepositorio<T> : IDisposable where T : class
    {
        List<T> Obtener();
        T RetornarPorId(object id);
        void Insertar(T entidad);
        void Eliminar(object id);
        void Eliminar(T entidadAEliminar);
        void Actualizar(T entidadAActualizar);
    }
}
