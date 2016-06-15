using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Persistencia;
using System.Data.Entity;

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
            throw new NotImplementedException();
        }

        public override void Eliminar(Incidente entidadAEliminar)
        {
            throw new NotImplementedException();
        }

        public override void Insertar(Incidente entidad)
        {

        }

        public override List<Incidente> Obtener()
        {
            throw new NotImplementedException();
        }
    }
}
