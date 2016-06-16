using System.Collections.Generic;
using Dominio;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    class StrategyBaseDeDatos : Strategy
    {
        protected ContextoSCADA contexto;
        protected DbSet<Incidente> manejadorIncidentes;

        internal StrategyBaseDeDatos(ContextoSCADA unContexto)
        {
            contexto = unContexto;
            manejadorIncidentes = unContexto.Set<Incidente>();
        }
        public override void Actualizar(Incidente entidadAActualizar)
        {
            manejadorIncidentes.Attach(entidadAActualizar);
            contexto.Entry(entidadAActualizar).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public override void Eliminar(Incidente entidadAEliminar)
        {
            manejadorIncidentes.Remove(entidadAEliminar);
            contexto.SaveChanges();
        }

        public override void Insertar(Incidente entidad)
        {
            manejadorIncidentes.Add(entidad);
            contexto.SaveChanges();
        }

        public override List<Incidente> Obtener()
        {
            return manejadorIncidentes.ToList();
        }
    }
}
