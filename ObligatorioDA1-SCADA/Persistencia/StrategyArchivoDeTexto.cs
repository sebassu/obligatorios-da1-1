using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    class StrategyArchivoDeTexto : Strategy
    {
        private List<Incidente> incidentes;
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
            throw new NotImplementedException();
        }

        public override List<Incidente> Obtener()
        {
            throw new NotImplementedException();
        }
    }
}
