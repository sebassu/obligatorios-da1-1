using Dominio;
using System.Collections.Generic;

namespace Persistencia
{
    public abstract class EstrategiaGuardadoIncidentes
    {
        public abstract void Insertar(Incidente entidad);
        public abstract List<Incidente> Obtener();
        public abstract void BorrarDatos();
    }
}
