using Dominio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    internal class RepositorioInstalacion : Repositorio<Instalacion>
    {
        internal RepositorioInstalacion(ContextoSCADA unContexto) : base(unContexto) { }

        public override List<Instalacion> Obtener()
        {
            return coleccionEntidades.Include("Dependencias").ToList();
        }

        public void ActualizarAgregacionDispositivo(Instalacion entidad, Dispositivo unDispositivo)
        {
            contexto = new ContextoSCADA("name=ContextoSCADA");
            if (contexto.Entry(entidad.ElementoPadre).State == EntityState.Detached)
            {
                PlantaIndustrial aux = entidad.ElementoPadre as PlantaIndustrial;
                if (Auxiliar.NoEsNulo(aux))
                {
                    contexto.Plantas.Attach(aux);
                }
                else {
                    contexto.Instalaciones.Attach((Instalacion)entidad.ElementoPadre);
                }
            }
            contexto.Dispositivos.Add(unDispositivo);
            contexto.Tipos.Attach(unDispositivo.Tipo);
            base.Actualizar(entidad);
        }
    }
}