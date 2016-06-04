using System;
using Dominio;
using System.Collections;
using Excepciones;

namespace Persistencia
{
    public class AccesoADatosBaseDeDatos : IAccesoADatos
    {
        private RepositorioElementosSCADA manejadorElementosPrimerNivel;
        private Repositorio<Tipo> manejadorTipos;

        public AccesoADatosBaseDeDatos()
        {
            manejadorTipos = new Repositorio<Tipo>(new ContextoSCADA());
            manejadorElementosPrimerNivel = new RepositorioElementosSCADA(new ContextoSCADA());
        }

        public IList ElementosPrimarios
        {
            get
            {
                return manejadorElementosPrimerNivel.Obtener().AsReadOnly();
            }
        }

        public void EliminarDatos()
        {
            ContextoSCADA contexto = new ContextoSCADA();
            contexto.EliminarDatos();
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
                return manejadorTipos.Obtener().AsReadOnly();
            }
        }

        public void EliminarElemento(IElementoSCADA unElemento)
        {
            manejadorElementosPrimerNivel.Eliminar(unElemento);
        }

        public void EliminarIncidente(Incidente unIncidente)
        {
            throw new NotImplementedException();
        }

        public void EliminarTipo(Tipo unTipo)
        {
            manejadorTipos.Eliminar(unTipo);
        }

        public bool ExistenTipos()
        {
            return manejadorTipos.Obtener().Count != 0;
        }

        public void RegistrarElemento(IElementoSCADA unElemento)
        {
            if (Auxiliar.NoEsNulo(unElemento))
            {
                manejadorElementosPrimerNivel.Insertar(unElemento);
            }
            else
            {
                throw new AccesoADatosExcepcion("Elemento nulo recibido.");
            }
        }

        public void RegistrarIncidente(IElementoSCADA unElemento, Incidente incidenteARegistrar)
        {
            throw new NotImplementedException();
        }

        public void RegistrarTipo(Tipo unTipo)
        {
            if (Auxiliar.NoEsNulo(unTipo))
            {
                manejadorTipos.Insertar(unTipo);
            }
            else
            {
                throw new AccesoADatosExcepcion("Tipo nulo recibido.");
            }
        }
    }
}