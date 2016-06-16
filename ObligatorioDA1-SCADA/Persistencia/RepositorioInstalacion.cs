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
            return coleccionEntidades.Include("ElementoPadre").Include("Dependencias.Tipo")
                .Include("Dependencias.Variables.Historico").Include("Variables.Historico").ToList();
        }

        public void ActualizarAgregacionDispositivo(Instalacion entidad, Dispositivo unDispositivo)
        {
            contexto.Tipos.Attach(unDispositivo.Tipo);
            coleccionEntidades.Attach(entidad);
            contexto.Entry(entidad).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}