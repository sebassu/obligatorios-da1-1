using Dominio;
using System;
using System.Collections.Generic;

namespace Persistencia
{
    [Serializable]
    public abstract class EstrategiaGuardadoIncidentes
    {
        public abstract void Insertar(Incidente entidad);
        public abstract List<Incidente> Obtener();
    }
}
