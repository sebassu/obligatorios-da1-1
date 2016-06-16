using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    [Serializable]
    public class EstrategiaBaseDeDatos : EstrategiaGuardadoIncidentes
    {

        public override void Insertar(Incidente entidad)
        {
            using (ContextoSCADA contexto = new ContextoSCADA("name=ContextoSCADA"))
            {
                contexto.Incidentes.Add(entidad);
                contexto.SaveChanges();
            }
        }

        public override List<Incidente> Obtener()
        {
            using (ContextoSCADA contexto = new ContextoSCADA("name=ContextoSCADA"))
            {
                return contexto.Incidentes.ToList();
            }
        }
    }
}
