using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    abstract class Strategy : IRepositorio<Incidente>
    {
        public abstract void Actualizar(Incidente entidadAActualizar);


        public abstract void Eliminar(Incidente entidadAEliminar);


        public abstract void Insertar(Incidente entidad);


        public abstract List<Incidente> Obtener();
      
    }
}
