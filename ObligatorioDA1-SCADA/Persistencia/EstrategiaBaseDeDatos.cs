using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    [Serializable]
    public class EstrategiaBaseDeDatos : EstrategiaGuardadoIncidentes
    {
        private string stringConexion;

        public EstrategiaBaseDeDatos(string nombreString)
        {
            stringConexion = nombreString;
        }

        public override void Insertar(Incidente entidad)
        {
            using (ContextoSCADA contexto = new ContextoSCADA(stringConexion))
            {
                contexto.Incidentes.Add(entidad);
                contexto.SaveChanges();
            }
        }

        public override List<Incidente> Obtener()
        {
            using (ContextoSCADA contexto = new ContextoSCADA(stringConexion))
            {
                return contexto.Incidentes.ToList();
            }
        }
    }
}
