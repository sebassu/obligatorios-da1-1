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
            return coleccionEntidades.Include("Dependencias.Tipo").ToList();
        }

        public void ActualizarAgregacionDispositivo(Instalacion entidad, Dispositivo unDispositivo)
        {
            /*
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
                contexto.Entry(entidad.ElementoPadre).State = EntityState.Modified;
            }
            contexto.Dispositivos.Add(unDispositivo);*/
            contexto.Tipos.Attach(unDispositivo.Tipo);
            coleccionEntidades.Attach(entidad);
            contexto.Entry(entidad).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}