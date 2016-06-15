using Dominio;
using System.Collections.Generic;
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
            contexto.Tipos.Attach(unDispositivo.Tipo);
            base.Actualizar(entidad);
        }
    }
}