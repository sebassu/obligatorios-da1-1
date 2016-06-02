using System;
using Dominio;
using System.Collections;

namespace Persistencia
{
    public class AccesoADatosBaseDeDatos : IAccesoADatos
    {
        private Repositorio<Tipo> manejadorTipos;

        public AccesoADatosBaseDeDatos()
        {
            manejadorTipos = new Repositorio<Tipo>(new ContextoSCADA());
        }

        public IList ElementosPrimarios
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList Incidentes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList Tipos
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool EliminarElemento(IElementoSCADA unElemento)
        {
            throw new NotImplementedException();
        }

        public void EliminarIncidente(Incidente unIncidente)
        {
            throw new NotImplementedException();
        }

        public bool EliminarTipo(Tipo unTipo)
        {
            throw new NotImplementedException();
        }

        public bool ExistenTipos()
        {
            return manejadorTipos.Obtener().Count != 0;
        }

        public void RegistrarElemento(IElementoSCADA unElemento)
        {
            throw new NotImplementedException();
        }

        public void RegistrarIncidente(IElementoSCADA unElemento, Incidente incidenteARegistrar)
        {
            throw new NotImplementedException();
        }

        public void RegistrarTipo(Tipo unTipo)
        {
            manejadorTipos.Insertar(unTipo);
        }
    }
}