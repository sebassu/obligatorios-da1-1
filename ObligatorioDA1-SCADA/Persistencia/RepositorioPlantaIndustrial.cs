using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    internal class RepositorioPlantaIndustrial : Repositorio<PlantaIndustrial>
    {

        internal RepositorioPlantaIndustrial(ContextoSCADA unContexto) : base(unContexto) { }

        public override List<PlantaIndustrial> Obtener()
        {
            return coleccionEntidades.ToList();
        }

        public override void Insertar(PlantaIndustrial entidad)
        {
            coleccionEntidades.Add(entidad);
            contexto.SaveChanges();
        }
    }
}