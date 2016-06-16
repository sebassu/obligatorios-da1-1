using System.Collections.Generic;
using Dominio;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    class EstrategiaBaseDeDatos : EstrategiaGuardadoIncidentes
    {
        protected ContextoSCADA contexto;
        protected DbSet<Incidente> coleccionEntidades;

        internal EstrategiaBaseDeDatos(ContextoSCADA unContexto)
        {
            contexto = unContexto;
            coleccionEntidades = unContexto.Set<Incidente>();
        }

        public override void BorrarDatos()
        {
            coleccionEntidades.RemoveRange(coleccionEntidades);
            contexto.SaveChanges();
        }

        public override void Insertar(Incidente entidad)
        {
            coleccionEntidades.Add(entidad);
            contexto.SaveChanges();
        }

        public override List<Incidente> Obtener()
        {
            return coleccionEntidades.ToList();
        }
    }
}
